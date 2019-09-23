using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class SceneTransistions : MonoBehaviour
{
    public GameObject panel;
    public Animator transistionAnim;
    private Dialogue dialogueScript;
    
    void Start()
    {
        dialogueScript = GameObject.Find("Dialogue Manager").GetComponent<Dialogue>();
    }

    
    void Update()
    {
        if (dialogueScript.activateTransistionAnim)
        {
            panel.SetActive(true);
            Debug.Log("Start transistion");
            transistionAnim.SetTrigger("end");
        }
    }
}
