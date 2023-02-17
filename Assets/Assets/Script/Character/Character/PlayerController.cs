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

    [Header("Sword")]
    [SerializeField] private Transform swordNorth;
    [SerializeField] private Transform swordSouth;
    [SerializeField] private Transform swordLeft;
    [SerializeField] private Transform swordRight;

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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
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


        private void Attack()
    {
        Vector2 swordDirection = Vector2.zero;

        if (lastMove.x > 0)
        {
            swordDirection = Vector2.right;
        }
        else if (lastMove.x < 0)
        {
            swordDirection = Vector2.left;
        }
        else if (lastMove.y > 0)
        {
            swordDirection = Vector2.up;
        }
        else if (lastMove.y < 0)
        {
            swordDirection = Vector2.down;
        }

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position + (Vector3)swordDirection * attackRange, attackRange, LayerMask.GetMask("Enemies"));

        if (hitEnemies != null)
        {
            foreach (Collider2D enemy in hitEnemies)
            {
                enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
            }
        }

        // Animation de l'attaque
        if (swordDirection == Vector2.up)
        {
            anim.SetTrigger("launchAttackNorth");
        }
        else if (swordDirection == Vector2.down)
        {
            anim.SetTrigger("launchAttackSouth");
        }
        else if (swordDirection == Vector2.right)
        {
            anim.SetTrigger("launchAttackRight");
        }
        else if (swordDirection == Vector2.left)
        {
            anim.SetTrigger("launchAttackLeft");
        }
    }

    public void Respawn()
    {
        transform.position = respawnPoint.position;
        currentHp = maxHp;
    }


}












