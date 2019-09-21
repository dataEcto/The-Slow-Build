using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChoiceThree : MonoBehaviour
{
    public bool choiceThree;
    [Header("Text Variables")]
    public TextMeshProUGUI textDisplay;
    [TextArea(3,10)]
    public string textToEdit;

    [Header("Choices Variable")]
    public GameObject choiceManager;

    
    void Start()
    {
        choiceThree = false;
        textDisplay.text = textToEdit;
        choiceManager = GameObject.Find("Choices");
    }

    
    void Update()
    {
        
    }

    public void ChooseThree()
    {
        choiceThree = true;
        choiceManager.SetActive(false);
        Debug.Log("Choice Three was chosen.");
    }
    
}
