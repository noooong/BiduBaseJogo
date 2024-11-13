using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiduController : MonoBehaviour
{
    private Rigidbody2D BiduRigidbody2D;
    public float BiduSpeed;
    public Vector2 BiduDirection;
    public bool BiduFaceRight = true;
    public bool _isWalk;
    public static BiduController Instance;


    private void Awake()
    {
        Instance = this;
    }




    // Start is called before the first frame update
    void Start()
    {
                

        BiduRigidbody2D = GetComponent<Rigidbody2D>();
        BiduRigidbody2D.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        BiduRigidbody2D.sleepMode = RigidbodySleepMode2D.NeverSleep;

        //quando carrega procura um objeto com o nome da ultima porta que ele passou, caso encontre ele vai para a posição designada pela porta
        try
        {
            if (PlayerPrefs.GetString("LastDoor") != "")
            {
                foreach (Door door in Door.PortasDaCena)
                {
                    if (door.Nome == PlayerPrefs.GetString("LastDoor"))
                    {
                        transform.position = door.SpawnArea.transform.position;
                        break;
                    }
                }
            }
        }
        catch { Debug.Log("não foi encontrado a porta com nome: " + PlayerPrefs.GetString("LastDoor")); }
    }


    // Update is called once per frame
    void Update()
    {

        PlayerMove();

        BiduRigidbody2D.MovePosition(BiduRigidbody2D.position + BiduDirection.normalized * BiduSpeed * Time.fixedDeltaTime);
    }

    private void FixedUpdate()
    {
        if (BiduDirection.x != 0 || BiduDirection.y != 0)
        {
            _isWalk = true;
        }
        else
        {
            _isWalk = false;
        }


    }

    void PlayerMove()
    {
        BiduDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (BiduDirection.x < 0 && BiduFaceRight)
        {
            Flip();
        }
        else if (BiduDirection.x > 0 && !BiduFaceRight)
        {
            Flip();
        }

    }

    void Flip()
    {
        BiduFaceRight = !BiduFaceRight;
        transform.Rotate(0f, 180, 0f);
    }

}
