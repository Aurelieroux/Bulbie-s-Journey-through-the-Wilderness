using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private int maxHp = 20;
    private bool isInvincible = false;

    [Header("Invincibility")]
    [SerializeField] private float invincibilityDuration = 5.0f;
    private float invincibilityTimer = 0.0f;
    public float tempsEcoule = 0f; // Temps écoulé en secondes


    [Header("Respawn")]
    [SerializeField] private Transform respawnPoint;

    [SerializeField] private Collider2D[] ennemyCollider;


    
    
    private void Start()
    {
        isInvincible = false;
    }

    private void Update()
    {
        // Update the invincibility timer
        if (isInvincible)
        {
           
            invincibilityTimer += Time.deltaTime;

            if (invincibilityTimer >= invincibilityDuration)
            {
                isInvincible = false;
                
            }


        }

        if (maxHp <= 0)
        {
            Respawn();
        }

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
      
        if (collider.CompareTag("Enemy") && !isInvincible)
        {
            
            maxHp -= 2;
            isInvincible = true;
            invincibilityTimer = invincibilityDuration;              
           
        }

        
    }

    public void Respawn()
    {
        transform.position = respawnPoint.position;
        maxHp = 0;
    }

}
