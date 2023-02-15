using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorPlayer : MonoBehaviour
{
    private Animator anim;
    private bool attackInProgress = false;
    private bool walkRight = false;
    private bool walkBack = false;
    private bool walkLeft = false;
    private bool walkDown = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Gérer l'attaque
        if (Input.GetKeyDown(KeyCode.Space) && !attackInProgress)
        {
            if (walkRight)
            {
                anim.SetTrigger("launchAttackRight");
            }
            else if (walkLeft)
            {
                anim.SetTrigger("launchAttackLeft");
            }
            else if (walkBack)
            {
                anim.SetTrigger("launchAttackBack");
            }
            else if (walkDown)
            {
                anim.SetTrigger("launchAttackDown");
            }
            else
            {
                anim.SetTrigger("launchAttack");
            }
            attackInProgress = true;
        }

        if (attackInProgress && anim.GetCurrentAnimatorStateInfo(0).IsName("Character_Idle"))
        {
            attackInProgress = false;
        }

        // Gérer la marche à droite
        if (Input.GetKeyDown(KeyCode.D))
        {
            walkRight = true;
            walkLeft = false;
            walkDown = false;
            walkBack = false;
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            walkRight = false;
        }
        anim.SetBool("walkRight", walkRight);

        // Gérer la marche en arrière
        if (Input.GetKeyDown(KeyCode.Z))
        {
            walkBack = true;
            walkRight = false;
            walkLeft = false;
            walkDown = false;
        }
        else if (Input.GetKeyUp(KeyCode.Z))
        {
            walkBack = false;
        }
        anim.SetBool("walkBack", walkBack);

        // Gérer la marche à gauche
        if (Input.GetKeyDown(KeyCode.Q))
        {
            walkLeft = true;
            walkRight = false;
            walkDown = false;
            walkBack = false;
        }
        else if (Input.GetKeyUp(KeyCode.Q))
        {
            walkLeft = false;
        }
        anim.SetBool("walkLeft", walkLeft);

        // Gérer la marche vers le bas
        if (Input.GetKeyDown(KeyCode.S))
        {
            walkDown = true;
            walkRight = false;
            walkBack = false;
            walkLeft = false;
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            walkDown = false;
        }
        anim.SetBool("walkDown", walkDown);

        // Handling attack animation
        if (Input.GetKeyDown(KeyCode.Space) && !attackInProgress)
        {
            if (walkRight)
            {
                anim.SetTrigger("launchAttackRight");
            }
            else if (walkLeft)
            {
                anim.SetTrigger("launchAttackLeft");
            }
            else if (walkBack)
            {
                anim.SetTrigger("launchAttackBack");
            }
            else if (walkDown)
            {
                anim.SetTrigger("launchAttack");
            }
            else
            {
                anim.SetTrigger("launchAttack");
            }
            attackInProgress = true;
        }

        if (attackInProgress && anim.GetCurrentAnimatorStateInfo(0).IsName("Character_Idle"))
        {
            {
                attackInProgress = false;
                Debug.Log("Attack Animation Triggered");

            }

        }
    }
}





