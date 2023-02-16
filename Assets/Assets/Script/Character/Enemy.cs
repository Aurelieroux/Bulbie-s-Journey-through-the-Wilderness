using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float range = 5f;
    public float speed = 3f;
    public float runSpeed = 5f;
    public float runTime = 2f;
    public int damage = 2;
    public int hp = 10;

    private Transform target;
    private Animator animator;
    private bool isRunning = false;
    private bool isDead = false;
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
                runTimer = 0f;
            }
        }
        else if (target != null)
        {
            float distance = Vector2.Distance(transform.position, target.position);

            if (distance <= range)
            {
                if (!animator.GetCurrentAnimatorStateInfo(0).IsName("SlimeRed_LowJump"))
                {
                    animator.SetTrigger("SlimeRedLowJump");
                }

                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

                if (distance <= 0.1f)
                {
                    PlayerController playerController = target.GetComponent<PlayerController>();
                    if (playerController != null)
                    {
                        playerController.TakeDamage(damage);
                    }
                    animator.SetTrigger("SlimeRedHugeJump");
                }
                else if (distance <= 1f)
                {
                    transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
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
