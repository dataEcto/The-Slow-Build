using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game6Music : MonoBehaviour
{
    public Dialogue dialogueScript;
    public AudioManager audioScript;

    private bool playTheme1;

  
    
    // Start is called before the first frame update
    void Start()
    {
        dialogueScript = GameObject.Find("Dialogue Manager").GetComponent<Dialogue>();
        audioScript = GameObject.Find("Audio Manager").GetComponent<AudioManager>();

        playTheme1 = false;
      
    }

    // Update is called once per frame
    void Update()
    {
        if (playTheme1 == false && dialogueScript.index > 1)
        {
            audioScript.PlaySong("Dells");
            playTheme1 = true;
        }

       
       
        
        
        
    }
}
