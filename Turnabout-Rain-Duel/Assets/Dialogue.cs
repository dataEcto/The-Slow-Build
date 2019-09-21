using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;


public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    [TextArea(3,10)] public string[] sentences;
    [TextArea(3,10)] public string[] choiceOneSentences;
    
    private int index;
    private int indexC1;
    public float typingSpeed;
    
    private bool onLastSentence;
    public bool isTyping;
    
    //If I check if the index is higher than the length, I can do a certain action.
    //Itd have to be something like.. if index is greater than the length of the array - 2
    public Animator anim;
    public AudioSource blip;

    //I will make it so that these buttons are activate.
    //However, I will not check if one of these buttons were clicked here.
    //I will need to make a small script that runs a function that checks a bool as true.
    //When clicked on.
    //These can be hard coded away in case you want no choices but still want a transistion.
    [Header("Choice Variables")]
    public GameObject choiceManager;
    public GameObject choiceOne;
    public GameObject choiceTwo;
    public GameObject choiceThree;

    private ChoiceOne choiceOneScript;
    private ChoiceTwo choiceTwoScript;
    private ChoiceThree choiceThreeScript;
    
    [Header("Branch Checks")]
    //These bools will check what branch we are on.
    public bool mainBranch;
    
    void Start()
    {
        isTyping = false;
        onLastSentence = false;
        
        blip = GetComponent<AudioSource>();
        
        choiceOneScript = choiceOne.GetComponent<ChoiceOne>();
        choiceTwoScript = choiceTwo.GetComponent<ChoiceTwo>();
        choiceThreeScript = choiceThree.GetComponent<ChoiceThree>();

        mainBranch = true;

    }
   
    void Update()
    {
        //Set this to type the initial array
        //As long as we're on the main branch
        //Note to self: use stop all coroutines for switch to new branches
        //also set the text to ""
        if  (mainBranch && isTyping == false)
        {
            StartCoroutine(Type());
            isTyping = true;
        }
        
        if (textDisplay.text == sentences[index])
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                NextSentence();
            }
        }

        //If The First Choice was chosen.
        if (choiceOneScript.choseOne && isTyping == false)
        {
           
            StopCoroutine(Type());
            textDisplay.text = "";
            StartCoroutine(TypeChoiceOne());  
            isTyping = true;
 
        }


        if (textDisplay.text == choiceOneSentences[indexC1])
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                NextSentenceChoiceOne();
                Debug.Log("Display next Sentence");
            }
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

            isTyping = false;
            mainBranch = false;

    }

    IEnumerator TypeChoiceOne()
    {
        foreach (char letter in choiceOneSentences[indexC1].ToCharArray())
        {
            textDisplay.text += letter;
            blip.pitch = Random.Range(0.9f, 1.0f);
            yield return new WaitForSeconds(typingSpeed);  
            

            if (!blip.isPlaying)
            {
                blip.Play();
            }
        }
        
        isTyping = false;
        choiceOneScript.choseOne = false;

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
                    choiceManager.SetActive(true);
                    onLastSentence = true;
                  
                }
               
            }
 
        }
     
    }

    public void NextSentenceChoiceOne()
    {
        if (indexC1 < choiceOneSentences.Length - 1)
        {
            indexC1++;
            textDisplay.text = "";
            StartCoroutine(TypeChoiceOne());
        }
      
        //We run through these nested if statements if 
        //We are on the last sentence
        //Make sure this only happens once
        if (onLastSentence == false)
        {
            if (indexC1 > choiceOneSentences.Length - 2)
            {
                //I can change the sprites in here.
               

                if (textDisplay.text == sentences[index])
                {
                    //And end it off with dialogue boxes here if needed!
                    choiceManager.SetActive(true);
                    onLastSentence = true;
                  
                }
               
            }
 
        }
    }
    
    

}
