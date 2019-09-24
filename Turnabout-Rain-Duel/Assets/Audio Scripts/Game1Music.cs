using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game1Music : MonoBehaviour
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
        if (playTheme1 == false)
        {
            audioScript.PlaySong("Court Begins");
            playTheme1 = true;
        }
        
        if (dialogueScript.indexC1 >= 7 || dialogueScript.indexC2 >= 1 || dialogueScript.indexC3 >= 1)
        {
            audioScript.StopPlaying("Court Begins");
        }
    }
}
