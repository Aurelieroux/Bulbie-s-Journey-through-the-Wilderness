using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    [Header("Stat")]
    [SerializeField] float moveSpeed = 10.0f;
    [SerializeField] int hp = 20;

    public bool canMove = true;

    [Header("Combat")]
    [SerializeField] Transform sword; // Référence à l'objet sword
    [SerializeField] int attackDamage = 2;

    public Transform respawnPoint;

    private Vector2 lastMove = Vector2.zero;
    private Rigidbody2D rb;
    private Animator anim;

    private void Start()
    {
        respawnPoint = GameObject.Find("RespawnPoint").transform;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            Move();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
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

    void Attack()
    {
        // On récupère tous les ennemis qui se trouvent dans le rayon d'attaque de l'objet sword
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(sword.position, 1.0f, LayerMask.GetMask("Enemies"));

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;

        if (hp <= 0)
        {
            Respawn();
        }
    }

    void Respawn()
    {
        transform.position = respawnPoint.transform.position;
        hp = 20;
    }
}









