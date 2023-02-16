using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PNJWizard : MonoBehaviour
{
    public GameObject dialogueBox; // GameObject contenant la boîte de dialogue

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            dialogueBox.SetActive(true); // Activer le GameObject contenant la boîte de dialogue
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            dialogueBox.SetActive(false); // Désactiver le GameObject contenant la boîte de dialogue
        }
    }
}





