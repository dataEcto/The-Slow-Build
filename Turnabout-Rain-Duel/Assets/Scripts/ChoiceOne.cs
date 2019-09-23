using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChoiceOne : MonoBehaviour
{
    public bool choseOne;
    [Header("Text Variables")]
    public TextMeshProUGUI textDisplay;
    [TextArea(3,10)]
    public string textToEdit;

    [Header("Choices Variable")]
    public GameObject choiceManager;
    
    void Start()
    {
        choseOne = false;
        textDisplay.text = textToEdit;
        choiceManager = GameObject.Find("Choices");
    }


    public void PlayerChoseOne()
    {
        choseOne = true;
        choiceManager.SetActive(false);
        Debug.Log("Choice 1 was chosen");
    }
    
}
