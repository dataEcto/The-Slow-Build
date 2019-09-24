using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game4Music : MonoBehaviour
{
    public Dialogue dialogueScript;
    public AudioManager audioScript;
    public Animator objectAnim;

    private bool playTheme1;

    private bool playTheme2;
    
    private bool travisObject;
    
    // Start is called before the first frame update
    void Start()
    {
        dialogueScript = GameObject.Find("Dialogue Manager").GetComponent<Dialogue>();
        audioScript = GameObject.Find("Audio Manager").GetComponent<AudioManager>();

        playTheme1 = false;
        playTheme2 = false;

        travisObject = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playTheme1 == false)
        {
            audioScript.PlaySong("Suspense");
            playTheme1 = true;
        }
        
        else if (dialogueScript.index == 14)
        {
            audioScript.StopPlaying("Suspense");
        }

        if (dialogueScript.index >= 16 && playTheme2 == false)
        {
            audioScript.PlaySong("Cornered");
            playTheme2 = true;
        }
        
        if (travisObject == false && dialogueScript.index == 16)
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
