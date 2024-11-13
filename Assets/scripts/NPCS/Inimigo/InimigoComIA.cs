using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class InimigoComIA : InimigoBase
{
    [SerializeField] int UltimaDirecao = 1;

    [Header("Coisas referentes ao Field of View")]
    [Tooltip("Check as layers a serem ignoradas pelo FOVRaycast")]
    [SerializeField] Vector2 MinMax = new Vector2(-1f, 1f);
    public LayerMask FovLayerMask;

    [Tooltip("Transform da cabeça do inimigo, se deixado em branco, será o transform do inimigo")]
    [SerializeField] Transform Head;

    [SerializeField] float FOVDistance = 10;

    [SerializeField] float RayVelocity = 8;

    public Transform[] Pontos;
    public int PontoAtual;

    public bool TaVendoBidu = false;
    public bool ChegouNoPonto = false;

    public AIDestinationSetter Destino;
    public GameObject Inimigo;

    public float Timer;

    public float VelocidadePadrao, VelocidadePerseguicao;

    AIPath aIPath;
   

    private void Awake()
    {
        if (Head == null)
        {
            Head = transform;
        }

        Destino = GetComponent<AIDestinationSetter>();

        aIPath = GetComponent<AIPath>();


        
    }

    private void Start()
    {
        FovLayerMask = ~FovLayerMask;
        StartCoroutine (FOV());
    }

    public void Update()
    {

        if (TaVendoBidu == true)
        {
            Timer = 0;
        }
       

        if ( Timer > 3)
        {
            Patrulha();
            Destino.target = Pontos[PontoAtual];
        }
        else
        {
            Timer += Time.deltaTime;
        }


    }
        void Patrulha()
        {
            aIPath.maxSpeed = VelocidadePadrao;
            if(Vector3.Distance(transform.position, Pontos[PontoAtual].position) < 0.4)
        {
            PontoAtual++;
            if(PontoAtual > Pontos.Length - 1)
            {
                PontoAtual = 0;
            }

            Destino.target = Pontos[PontoAtual];
        }

        

        

    }

   public void FalhouPuzzle()

    {
          
    }
                
   

    IEnumerator FOV()
    {

        float CurrentRayAngle = 0;

        Vector2 raycastPosition;
       
       

        while (true)
        {
             


            if (transform.position.x > Destino.target.position.x)
            {
                Vector3 theScale = transform.localScale;
                theScale.x = -1;
                transform.localScale = theScale;
                Debug.Log("a direita");
            }

            else
            {
                Vector3 theScale = transform.localScale;
                theScale.x = 1;
                transform.localScale = theScale;
                Debug.Log("a esquerda");
            }

            raycastPosition = Head.transform.position;
            RaycastHit2D hit = Physics2D.Raycast(raycastPosition, new Vector2(Mathf.Cos(CurrentRayAngle), Mathf.Sin(CurrentRayAngle)), FOVDistance * transform.localScale.x, FovLayerMask);
            //Debug.Log(hit.collider.gameObject);
           
            CurrentRayAngle += 0.01f * RayVelocity;
            if (CurrentRayAngle > MinMax.y || CurrentRayAngle < MinMax.x)
            {
                RayVelocity *= -1;
            }

            if (hit.collider != null)
            {
                Debug.Log("rasdasd");
                Debug.DrawRay(raycastPosition, new Vector2(Mathf.Cos(CurrentRayAngle), Mathf.Sin(CurrentRayAngle)) * Vector2.Distance(raycastPosition, hit.point) * transform.localScale.x, Color.green);
                Debug.Log(hit.transform.gameObject.name);


            }
            else
            {
                Debug.Log("rasdasd");
                Debug.DrawRay(raycastPosition, new Vector2(Mathf.Cos(CurrentRayAngle), Mathf.Sin(CurrentRayAngle)) * FOVDistance * transform.localScale.x, Color.red);
            }

            if (hit.collider != null && hit.collider.GetComponent<BiduController>())
            {

                TaVendoBidu = true;
                aIPath.maxSpeed = VelocidadePerseguicao;
                Destino.target = BiduController.Instance.transform;
            }
            else
            {
                TaVendoBidu = false;
            }

                yield return null;
        }
    }
}

