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


    // Start is called before the first frame update
    void Start()
    {
        BiduRigidbody2D = GetComponent<Rigidbody2D>();
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
