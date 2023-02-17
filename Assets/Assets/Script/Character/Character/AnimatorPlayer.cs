using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorPlayer : MonoBehaviour
{
    private Animator animator;

    private bool walkRight;
    private bool walkLeft;
    private bool walkSouth;
    private bool walkNorth;
    private bool IdleFalse;

    private bool isAttacking;

    private Vector2 lastMove;
    private bool swordLeft;
    private bool swordRight;

    void Start()
    {
        animator = GetComponent<Animator>();
        swordLeft = false;
        swordRight = false;

    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        walkRight = false;
        walkLeft = false;
        walkSouth = false;
        walkNorth = false;
        IdleFalse = true;

        if (horizontal > 0)
        {
            walkRight = true;
            IdleFalse = false;
            lastMove = new Vector2(horizontal, 0f);
        }
        else if (horizontal < 0)
        {
            walkLeft = true;
            IdleFalse = false;
            lastMove = new Vector2(horizontal, 0f);
        }

        if (vertical > 0)
        {
            walkNorth = true;
            IdleFalse = false;
            lastMove = new Vector2(0f, vertical);
        }
        else if (vertical < 0)
        {
            walkSouth = true;
            IdleFalse = false;
            lastMove = new Vector2(0f, vertical);
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("XButton")) // Si on appuie sur espace ou le bouton carré de la manette
        {
            isAttacking = true;

            animator.SetTrigger("launchAttack");

            if (lastMove.x > 0) // Si le personnage est orienté vers la droite
            {
                swordRight = true; // Définit la variable swordRight à true
                swordLeft = false; // Définit la variable swordLeft à false
            }
            else if (lastMove.x < 0) // Si le personnage est orienté vers la gauche
            {
                swordLeft = true; // Définit la variable swordLeft à true
                swordRight = false; // Définit la variable swordRight à false
            }

            if (walkRight)
            {
                animator.SetTrigger("launchAttackRight");
            }
            else if (walkLeft)
            {
                animator.SetTrigger("launchAttackLeft");
            }
            else if (walkNorth)
            {
                animator.SetTrigger("launchAttackNorth");
            }
            else if (walkSouth)
            {
                animator.SetTrigger("launchAttackSouth");
            }
            else
            {
                animator.SetTrigger("launchAttack");
            }
        }

        animator.SetBool("walkRight", walkRight);
        animator.SetBool("walkLeft", walkLeft);
        animator.SetBool("walkSouth", walkSouth);
        animator.SetBool("walkNorth", walkNorth);

        if (isAttacking)
        {
            animator.SetLayerWeight(1, 1);
        }
        else
        {
            animator.SetLayerWeight(1, 0);
        }
    }

    public void StartAttack()
    {
        // Do something when the attack starts, if necessary
    }

    public void EndAttack()
    {
        isAttacking = false;
    }
}







