using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public HeartSystem heart;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //toda vez que o player entrar em colisão ele perderá um coração
        if (collision.gameObject.tag == "Player")
        {
            heart.vida--;
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
