using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceOne : MonoBehaviour
{
    public bool choseOne;
    
    void Start()
    {
        choseOne = false;
    }

    
    void Update()
    {
        
    }

    public void PlayerChoseOne()
    {
        choseOne = true;
        Debug.Log("Choice 1 was chosen");
    }
    
}
