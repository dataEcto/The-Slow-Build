using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class Game0Music : MonoBehaviour
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
        if (playTheme1 == false && dialogueScript.index >= 1)
        {
            audioScript.PlaySong("Godot");
            playTheme1 = true;
        }

        if (dialogueScript.indexC1 > 4 || dialogueScript.indexC2 > 4 || dialogueScript.indexC3 > 4)
        {
            audioScript.StopPlaying("Godot");
        }
    }
    
    
}
