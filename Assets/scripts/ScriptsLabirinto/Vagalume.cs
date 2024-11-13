using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Vagalume : MonoBehaviour
{
    [SerializeField]Vector3 PosInicial;
    Vector3 PosToFollow;
    [SerializeField]float velocidade;
    [SerializeField] float MinLight, MaxLight;
    [SerializeField] float velocidadeLuz = .1f;
    Light2D Light;


    void Start()
    {
        PosInicial = transform.position;
        PosToFollow = PosInicial;
        Light = GetComponent<Light2D>();
       StartCoroutine( Move());
        StartCoroutine(Pisca());
    }

    IEnumerator Move()
    {

        while (true)
        {
            
            if (Vector2.Distance(transform.position, PosToFollow) < 0.1f)
            {
                PosToFollow = new Vector2(PosInicial.x + Random.Range(-1f, 1f), PosInicial.y + Random.Range(-1f, 1f));
            }

            Debug.Log(PosToFollow);
            transform.position = Vector2.MoveTowards(transform.position, PosToFollow, velocidade * Time.deltaTime);
            yield return null;
        }
    }

    IEnumerator Pisca()
    {
        while (true)
        {
            if(Light.intensity > MaxLight || Light.intensity < MinLight)
            {
                velocidadeLuz *= -1;
            }

            if(Light.intensity > MaxLight)
            {
                Light.intensity = MaxLight;
            }

            if (Light.intensity < MinLight)
            {
                Light.intensity = MinLight;
            }

            Light.intensity += velocidadeLuz;
            yield return null;
        }
    }
}
