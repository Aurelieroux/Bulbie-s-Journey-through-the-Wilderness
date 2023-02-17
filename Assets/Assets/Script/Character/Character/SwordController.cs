using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SwordController : MonoBehaviour
{
    public int damage = 2;

    private Animator animator;
    private Collider2D swordCollider;

    private void Start()
    {
        animator = GetComponentInParent<Animator>();
        swordCollider = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            swordCollider.enabled = false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                animator.SetTrigger("AttackNorth");
                swordCollider.enabled = true;
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                animator.SetTrigger("AttackSouth");
                swordCollider.enabled = true;
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                animator.SetTrigger("AttackLeft");
                swordCollider.enabled = true;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                animator.SetTrigger("AttackRight");
                swordCollider.enabled = true;
            }
            else
            {
                animator.SetTrigger("Attack");
                swordCollider.enabled = true;
            }
        }
    }
}
