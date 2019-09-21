using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChoiceTwo : MonoBehaviour
{
    public bool chooseTwo;
    [Header("Text Variables")]
    public TextMeshProUGUI textDisplay;
    [TextArea(3,10)]
    public string textToEdit;

    [Header("Choices Variable")]
    public GameObject choiceManager;
    void Start()
    {
        chooseTwo = false;
        textDisplay.text = textToEdit;
        choiceManager = GameObject.Find("Choices");
    }

  
    void Update()
    {
        
    }

    public void ChooseTwo()
    {
        chooseTwo = true;
        choiceManager.SetActive(false);
        Debug.Log("Choice Two was Chosen.");
    }
}
