using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
   public static HUDManager instance;

    public GameObject dialogueHolder, continueButton;
    public TextMeshProUGUI textDisplay;
    public Image imageDisplay;

    private void Awake()
    {
        instance = this;
    }
}
