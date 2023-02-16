using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SlimeBehavior : MonoBehaviour
{
    public float range = 5f;
    public float speed = 3f;
    public float runSpeed = 5f;
    public float runTime = 2f;
    public float fleeDistance = 10f;
    public float fleeRadius = 3f;
    public int damage = 2;
    public int hp = 10;

    private Transform target;
    private Animator animator;
    private bool isRunning = false;
    private bool isDead = false;
    private bool hasAttacked = false;
    private float runTimer = 0f;
    private Vector2 originalPosition;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
        originalPosition = transform.position;
    }

    void Update()
    {
        if (isDead)
        {
            return;
        }

        if (isRunning)
        {
            runTimer += Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, originalPosition, runSpeed * Time.deltaTime);

            if (runTimer >= runTime)
            {
                isRunning = false;
                hasAttacked = false;
                runTimer = 0f;
            }
        }
        else if (target != null)
        {
            float distance = Vector2.Distance(transform.position, target.position);

            if (distance <= range && !hasAttacked)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

                if (distance <= 0.1f)
                {
                    PlayerController playerController = target.GetComponent<PlayerController>();
                    if (playerController != null)
                    {
                        playerController.TakeDamage(damage);
                    }
                    isRunning = true;
                    hasAttacked = true;
                }
                else if (distance <= 1f)
                {
                    transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                }
            }
            else if (hasAttacked)
            {
                transform.position = Vector2.MoveTowards(transform.position, originalPosition, runSpeed * Time.deltaTime);
                if (Vector2.Distance(transform.position, originalPosition) >= fleeDistance)
                {
                    hasAttacked = false;
                }
            }
            else
            {
                if (Vector2.Distance(transform.position, originalPosition) <= fleeRadius)
                {
                    Vector2 fleeDirection = (transform.position - target.position).normalized;
                    Vector2 fleeTarget = (Vector2)transform.position + fleeDirection * fleeDistance;
                    transform.position = Vector2.MoveTowards(transform.position, fleeTarget, runSpeed * Time.deltaTime);
                }
                else
                {
                    transform.position = Vector2.MoveTowards(transform.position, originalPosition, speed * Time.deltaTime);
                }
            }
        }

        if (hp <= 0)
        {
            animator.SetBool("SlimeRedDeath", true);
            isDead = true;
            Destroy(gameObject, 1.5f);
        }
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
        isRunning = true;
        animator.SetTrigger("SlimeRedDamage");
    }

}







