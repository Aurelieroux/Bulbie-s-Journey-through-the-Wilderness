using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerController : MonoBehaviour
{
    [SerializeField] private string walkRightAnimation = "Character_Walk_Right_Animation";
    [SerializeField] private string walkLeftAnimation = "Character_Walk_Left_Animation";
    [SerializeField] private string walkNorthAnimation = "Character_Walk_North_Animation";
    [SerializeField] private string walkSouthAnimation = "Character_Walk_South_Animation";

    [Header("Stats")]
    [SerializeField] private float moveSpeed = 10.0f;
    [SerializeField] private int maxHp = 20;
    private int currentHp;

    [Header("Attack")]
    [SerializeField] private int attackDamage = 2;
    [SerializeField] private float attackRange = 1.0f;

    [Header("Respawn")]
    [SerializeField] private Transform respawnPoint;


    private Rigidbody2D rb;
    private Animator anim;
    private bool canMove = true;
    private Vector2 lastMove = Vector2.zero;


  

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentHp = maxHp;
    }

    private void Update()
    {
        Move();

        
    }

    public void TakeDamage(int damage)
    {
        currentHp -= damage;

        if (currentHp <= 0)
        {
            Respawn();
        }
    }

    private void Move()
    {
        float x = 0.0f;
        float y = 0.0f;

        // Déplacements au clavier
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
        {
            x += Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
            y += Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
            lastMove = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            if (lastMove.x > 0)
            {
                anim.SetBool("walkRight", true);
                anim.SetBool("walkLeft", false);
                anim.SetBool("walkNorth", false);
                anim.SetBool("walkSouth", false);
            }
            else if (lastMove.x < 0)
            {
                anim.SetBool("walkRight", false);
                anim.SetBool("walkLeft", true);
                anim.SetBool("walkNorth", false);
                anim.SetBool("walkSouth", false);
            }
            else if (lastMove.y > 0)
            {
                anim.SetBool("walkRight", false);
                anim.SetBool("walkLeft", false);
                anim.SetBool("walkNorth", true);
                anim.SetBool("walkSouth", false);
            }
            else if (lastMove.y < 0)
            {
                anim.SetBool("walkRight", false);
                anim.SetBool("walkLeft", false);
                anim.SetBool("walkNorth", false);
                anim.SetBool("walkSouth", true);
            }
        }
        
        else
        {
            anim.SetBool("walkRight", false);
            anim.SetBool("walkLeft", false);
            anim.SetBool("walkNorth", false);
            anim.SetBool("walkSouth", false);
        }

        rb.velocity = new Vector2(x, y);

    }


    public void Respawn()
    {
        transform.position = respawnPoint.position;
        currentHp = maxHp;
    }


}












