using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;


public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    [TextArea(3,10)]
    public string[] sentences;
    
    private int index;   
    public float typingSpeed;
    
    private bool onLastSentence;
    
    //If I check if the index is higher than the length, I can do a certain action.
    //Itd have to be something like.. if index is greater than the length of the array - 2
    public Animator anim;
    public AudioSource blip;

    //I will make it so that these buttons are activate.
    //However, I will not check if one of these buttons were clicked here.
    //I will need to make a small script that runs a function that checks a bool as true.
    //When clicked on.
    //These can be hard coded away in case you want no choices but still want a transistion.
    public GameObject choiceOne;
    public GameObject choiceTwo;

    private ChoiceOne choiceOneScript;
    private ChoiceTwo choiceTwoScript;

    void Start()
    {
        StartCoroutine(Type());
        onLastSentence = false;
        blip = GetComponent<AudioSource>();

        choiceOneScript = choiceOne.GetComponent<ChoiceOne>();
        choiceTwoScript = choiceTwo.GetComponent<ChoiceTwo>();
        
       
            

    }
   
    void Update()
    {
        if (textDisplay.text == sentences[index])
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                NextSentence();
            }
        }

        if (choiceOneScript.choseOne == true)
        {
            Destroy(this.gameObject);
        }
        
        
      
      
    }

    IEnumerator Type()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            blip.pitch = Random.Range(0.9f, 1.0f);
            yield return new WaitForSeconds(typingSpeed);  
            

            if (!blip.isPlaying)
            {
                blip.Play();
            }
        }
    }
    public void NextSentence()
    {
        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
      

        
        //We run through these nested if statements if 
        //We are on the last sentence
        //Make sure this only happens once
        if (onLastSentence == false)
        {
            if (index > sentences.Length - 2)
            {
                //I can change the sprites in here.
                anim.SetBool("isHappy",true);

                if (textDisplay.text == sentences[index])
                {
                    //And end it off with dialogue boxes here if needed!
                    choiceOne.SetActive(true);
                    choiceTwo.SetActive(true);               
                    onLastSentence = true;
                }
               
            }

        }
     
        
    }


}
