using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    [Header("Stat")]
    [SerializeField]
    float moveSpeed = 10.0f;

    public bool canMove = true;

    private Vector2 lastMove = Vector2.zero;
    private Rigidbody2D rb;
    private Animator anim;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {   
        if (canMove)
        {
            Move();
        }
        
        
    }

    void Move()
    {
        float x = 0.0f;
        float y = 0.0f;

        if (Input.GetKey(KeyCode.D))
        {
            x = moveSpeed * Time.fixedDeltaTime;
            lastMove = new Vector2(1.0f, 0.0f);
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            x = -moveSpeed * Time.fixedDeltaTime;
            lastMove = new Vector2(-1.0f, 0.0f);
        }
        else if (Input.GetKey(KeyCode.Z))
        {
            y = moveSpeed * Time.fixedDeltaTime;
            lastMove = new Vector2(0.0f, 1.0f);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            y = -moveSpeed * Time.fixedDeltaTime;
            lastMove = new Vector2(0.0f, -1.0f);
        }

        rb.velocity = new Vector2(x, y);

        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        
    }
    
}





