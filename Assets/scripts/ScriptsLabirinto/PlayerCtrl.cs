using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerCtrl : MonoBehaviour
{

    public float speed = 500;
    public Rigidbody2D rb;
    public Animator animator;

    Vector2 movimento;

    private void Update()
    {
        movimento = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        animator.SetFloat("Horizontal", movimento.x);
        animator.SetFloat("Vertical", movimento.y);
        animator.SetFloat("Velocidade", movimento.sqrMagnitude);

        if (movimento != Vector2.zero)
        {
            animator.SetFloat("Horizontal_idle", movimento.x);
            animator.SetFloat("Vertical_idle", movimento.y);
        }
    }

    private void FixedUpdate()
    {
        
    rb.velocity = movimento * speed * Time.deltaTime;

    }
}

