using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game2Music : MonoBehaviour
{
    public Dialogue dialogueScript;
    public AudioManager audioScript;
    public Animator objectAnim;

    private bool playTheme1;

    private bool playTheme2;

    private bool travisObject;

    private bool dessyObject;
    
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
            audioScript.PlaySong("Moderato");
            playTheme1 = true;
        }
        
        if (dialogueScript.indexC3 > 0 )
        {
            audioScript.StopPlaying("Moderato");
            
        }

        if (dialogueScript.indexC3 >= 4 && playTheme2 == false)
        {
            playTheme2 = true;
             audioScript.PlaySong("Objection");
        }

        if (dialogueScript.indexC3 == 20)
        {
            audioScript.StopPlaying("Objection");
        }

        if (dessyObject == false && dialogueScript.indexC3 == 6)
        {
            audioScript.PlaySong("Dessy Objects");
            objectAnim.SetBool("someoneObjects",true);
            StartCoroutine(Objecting());
            dessyObject = true;

        }
        
        if (travisObject == false && dialogueScript.indexC3 == 8)
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
