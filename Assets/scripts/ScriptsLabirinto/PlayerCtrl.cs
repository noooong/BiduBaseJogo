using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{

    private Camera mainCamera;
    [SerializeField]
    private float maxSpeed = 1f;
    Rigidbody2D rb;

    private void Start()
    {
        mainCamera = Camera.main;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        FollowMousePositionDelayed(maxSpeed);
    }

    private void FollowMousePosition()
    {
        transform.position = GetWorldPositionFromMouse();
    }


    private void FollowMousePositionDelayed(float maxSpeed)
    {
        if(Input.GetMouseButton(0)) { 
        //qual a direcao que o player vai seguir ao segurar o botão esquerdo do mouse
        Vector2 direction = new Vector2(GetWorldPositionFromMouse().x -transform.position.x, GetWorldPositionFromMouse().y - transform.position.y );

        //caso esteja apertando o mouse, o player vai se mover em direção a ele
        rb.velocity = new Vector2(direction.x, direction.y ).normalized * maxSpeed * Vector2.Distance(transform.position, GetWorldPositionFromMouse());
        }
        else
        {
            //caso o contrario o player vai parar
           
            rb.velocity = Vector2.zero;
        }
    }

    private Vector2 GetWorldPositionFromMouse()
    {
        return mainCamera.ScreenToWorldPoint(Input.mousePosition);
    }

}