using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakSpot : MonoBehaviour
{
    [SerializeField] private float healthEnnemy = 10;
    [SerializeField] private Collider2D[] swordColliders;

    private void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("SwordLeft"))
        {
            Animator animator = collider.GetComponentInParent<Animator>();
            if (animator != null && animator.GetBool("launchAttackLeft"))
            {
                healthEnnemy -= 2;
            }
        }
        else if (collider.CompareTag("SwordRight"))
        {
            Animator animator = collider.GetComponentInParent<Animator>();
            if (animator != null && animator.GetBool("launchAttackRight"))
            {
                healthEnnemy -= 2;
            }
        }
        else if (collider.CompareTag("SwordNorth"))
        {
            Animator animator = collider.GetComponentInParent<Animator>();
            if (animator != null && animator.GetBool("launchAttackNorth"))
            {
                healthEnnemy -= 2;
            }
        }
        else if (collider.CompareTag("SwordSouth"))
        {
            Animator animator = collider.GetComponentInParent<Animator>();
            if (animator != null && animator.GetBool("launchAttackSouth"))
            {
                healthEnnemy -= 2;
            }
        }
    }
}


