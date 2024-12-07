using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoBase : MonoBehaviour
{
   public int vida { get; protected set; }
    public Vector2 BiduDirection;
    public bool BiduFaceRight = true;

    void Update()
    {

        PlayerMove();
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

    public void LevaDano(int dano)
    {
        vida -= dano;
        Debug.Log(vida);
    }
}
