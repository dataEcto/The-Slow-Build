using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game5Music : MonoBehaviour
{
    public Dialogue dialogueScript;
    public AudioManager audioScript;
    public Animator objectAnim;

    private bool playTheme1;

    private bool playTheme2;

    private bool dessyObject;

    private bool travisObject;
    
    // Start is called before the first frame update
    void Start()
    {
        dialogueScript = GameObject.Find("Dialogue Manager").GetComponent<Dialogue>();
        audioScript = GameObject.Find("Audio Manager").GetComponent<AudioManager>();

        playTheme1 = false;
        playTheme2 = false;

        dessyObject = false;
        travisObject = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playTheme1 == false)
        {
            audioScript.PlaySong("Variation");
            playTheme1 = true;
        }

        if (dialogueScript.index >= 10)
        {
            audioScript.StopPlaying("Variation");
        }

        if (playTheme2 == false && dialogueScript.index >= 16)
        {
            audioScript.PlaySong("Dessy Pursuit");
            playTheme2 = true;
        }

        if (dialogueScript.indexC3 >= 9)
        {
            audioScript.StopPlaying("Dessy Pursuit");
        }
        
        if (dessyObject == false && dialogueScript.index == 6)
        {
            audioScript.PlaySong("Dessy Objects");
            objectAnim.SetBool("someoneObjects",true);
            StartCoroutine(Objecting());
            dessyObject = true;

        }
        
        if (travisObject == false && dialogueScript.index == 17)
        {
            audioScript.PlaySong("Travis Objects");
            objectAnim.SetBool("someoneObjects",true);
            StartCoroutine(Objecting());
            travisObject = true;

        }
        
        
        
    }
    
    IEnumerator Objecting()
    {
         
        yield return new WaitForSeconds(0.5f);
        objectAnim.SetBool("someoneObjects",false);
    }
}
