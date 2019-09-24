using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game3Music : MonoBehaviour
{
    public Dialogue dialogueScript;
    public AudioManager audioScript;

    private bool playTheme1;

    private bool playTheme2;
    
    // Start is called before the first frame update
    void Start()
    {
        dialogueScript = GameObject.Find("Dialogue Manager").GetComponent<Dialogue>();
        audioScript = GameObject.Find("Audio Manager").GetComponent<AudioManager>();

        playTheme1 = false;
        playTheme2 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playTheme1 == false)
        {
            audioScript.PlaySong("Truth");
            playTheme1 = true;
        }
        
        else if (dialogueScript.indexC1 == 14)
        {
            audioScript.StopPlaying("Truth");
        }
        
        
        
    }
}
