using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CycleJourNuit : MonoBehaviour
{
    public float tempsEcoule = 0f; // Temps écoulé en secondes
    public float tempsNuit = 30f; // Temps en secondes pour la nuit
    public GameObject objetDeclencheur; // Objet déclencheur qui fera augmenter l'intensité de la lumière
    public GameObject jour;
    public GameObject nuit;
    
    private bool estNuit = false; // Booléen pour savoir si c'est la nuit ou non

    // Initialisation
    void Start()
    {
      jour.SetActive(true);
      nuit.SetActive(false);

    }

    // Update est appelé une fois par frame
    void Update()
    {
        tempsEcoule += Time.deltaTime;

        
     
            

            if (tempsEcoule >= tempsNuit)
            {
                estNuit = true;
                jour.SetActive(false);
                nuit.SetActive(true);
            }
        

       
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("omg");

        
            estNuit = false;
            jour.SetActive(true);
            nuit.SetActive(false);
            tempsEcoule = 0f;
    }
    // Fonction appelée lorsqu'un objet entre en collision avec le trigger

    


}




