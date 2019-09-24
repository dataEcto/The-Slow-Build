using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeliceAnimation : MonoBehaviour
{
    public Dialogue dialogueScript;
    public Animator feliceAnim;
    
    // Start is called before the first frame update
    void Start()
    {
        dialogueScript = GameObject.Find("Dialogue Manager").GetComponent<Dialogue>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogueScript.index == 14)
        {
            feliceAnim.SetBool("shouldAppear",true);
        }
        
        if (dialogueScript.index == 18)
        {
            feliceAnim.SetBool("shouldTilt",true);
        }
        
        if (dialogueScript.index == 19)
        {
            feliceAnim.SetBool("putHood",true);
        }
        
        if (dialogueScript.index == 25)
        {
            feliceAnim.SetBool("beExcited",true);
        }
        
        if (dialogueScript.index == 30)
        {
            feliceAnim.SetBool("isHappy",true);
        }
    }
}
