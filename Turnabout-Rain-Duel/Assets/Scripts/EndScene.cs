using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class EndScene : MonoBehaviour
{
    public GameObject panel;
    public Animator transistionAnim;
    //private Dialogue dialogueScript;
    
    void Start()
    {
        //dialogueScript = GameObject.Find("Dialogue Manager").GetComponent<Dialogue>();
    }

    
    void Update()
    {      
            panel.SetActive(true);
            

            
      
    }

    IEnumerator LoadGame()
    {
        transistionAnim.SetTrigger("end");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("Game1");
    }
}
