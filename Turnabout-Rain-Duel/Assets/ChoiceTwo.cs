using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceTwo : MonoBehaviour
{
    public bool chooseTwo;
    
    void Start()
    {
        chooseTwo = false;
    }

  
    void Update()
    {
        
    }

    public void ChooseTwo()
    {
        chooseTwo = true;
    }
}
