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

    private bool isAttacking;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        walkRight = false;
        walkLeft = false;
        walkSouth = false;
        walkNorth = false;

        if (horizontal > 0)
        {
            walkRight = true;
        }
        else if (horizontal < 0)
        {
            walkLeft = true;
        }

        if (vertical > 0)
        {
            walkNorth = true;
        }
        else if (vertical < 0)
        {
            walkSouth = true;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isAttacking = true;
            

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
        }

        //animator.SetBool("walkRight", walkRight);
        //animator.SetBool("walkLeft", walkLeft);
        //animator.SetBool("walkSouth", walkSouth);
        //animator.SetBool("walkNorth", walkNorth);

        if (isAttacking)
        {
            //animator.SetLayerWeight(1, 1);
        }
        else
        {
            //animator.SetLayerWeight(1, 0);
        }
    }

    public void StartAttack()
    {
        
        
        
    }

    public void EndAttack()
    {
        isAttacking = false;
    }
}





