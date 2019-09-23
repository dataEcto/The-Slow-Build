using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;


public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    [TextArea(3,8)] public string[] sentences;
    [TextArea(3,8)] public string[] choiceOneSentences;
    [TextArea(3,8)] public string[] choiceTwoSentences;
    [TextArea(3,8)] public string[] choiceThreeSentences;
    
    public int index;
    public int indexC1;
    public int indexC2;
    public int indexC3;
    
    public float typingSpeed;
    
    private bool onLastSentence;
    private bool isTyping;
    
    //These bools need to be manually set in the inspector
    //For each case by case scenario.
    public bool shouldAnimateCharacter;
    public bool aninmateTransistion;
    public bool activateTransistionAnim;
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

    public string sceneToLoad1;
    public string sceneToLoad2;
    public string sceneToLoad3;

    private ChoiceOne choiceOneScript;
    private ChoiceTwo choiceTwoScript;
    private ChoiceThree choiceThreeScript;
    
    [Header("Branch Checks")]
    //These bool will check what branch we are on.
    private bool mainBranch;
    
    void Start()
    {
        isTyping = false;
        onLastSentence = false;

        shouldAnimateCharacter = false;
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
            //Lets start reseting important variables back to what they were.
            onLastSentence = false;
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
        
        //If the Second Choice was chosen
        if (choiceTwoScript.chooseTwo && isTyping == false)
        {
            //Again, reset all components here.
            onLastSentence = false;
            StopCoroutine(Type());
            textDisplay.text = "";

            StartCoroutine(TypeChoiceTwo());
            isTyping = true;
        }

        if (textDisplay.text == choiceTwoSentences[indexC2])
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                NextSentenceChoiceTwo();
                Debug.Log("Display next Sentence");
            }
        }
        
        //If the third choice...
        if (choiceThreeScript.choiceThree && isTyping == false)
        {
            //Again, reset all components here.
            onLastSentence = false;
            StopCoroutine(Type());
            textDisplay.text = "";

            StartCoroutine(TypeChoiceThree());
            isTyping = true;
        }

        if (textDisplay.text == choiceThreeSentences[indexC3])
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                NextSentenceChoiceThree();
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
                //Or? Perhaps I can make a script in the character that checks this script to see
                //If sprites should change?
                //That way, i don't gotta hard code anything.
                shouldAnimateCharacter = true;
                //Set this to false via character script.

                if (textDisplay.text == sentences[index])
                {
                    //And end it off with dialogue boxes here if needed!
                    choiceManager.SetActive(true);
                    onLastSentence = true;
                  
                }
               
            }
 
        }
     
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
                Debug.Log("On last sentence");
                shouldAnimateCharacter = true;
                //Set this to false via character script.

                if (textDisplay.text == choiceOneSentences[indexC1])
                {
                    //And end it off with dialogue boxes here if needed!
                    //choiceManager.SetActive(true);
                    StopCoroutine(TypeChoiceOne());
                    StartCoroutine(LoadSceneC1());
                    if (aninmateTransistion)
                    {
                        activateTransistionAnim = true;
                    }
                    onLastSentence = true;
                  
                }
               
            }
 
        }
    }


    IEnumerator TypeChoiceTwo()
    {
        foreach (char letter in choiceTwoSentences[indexC2].ToCharArray())
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
        choiceTwoScript.chooseTwo = false;
    }
    
    public void NextSentenceChoiceTwo()
    {
        if (indexC2 < choiceTwoSentences.Length - 1)
        {
            indexC2++;
            textDisplay.text = "";
            StartCoroutine(TypeChoiceTwo());
        }
      
        //We run through these nested if statements if 
        //We are on the last sentence
        //Make sure this only happens once
        if (onLastSentence == false)
        {
            if (indexC2 > choiceTwoSentences.Length - 2)
            {
                //I can change the sprites in here.
                Debug.Log("On last sentence");
                shouldAnimateCharacter = true;
                //Set this to false via character script.

                if (textDisplay.text == choiceTwoSentences[indexC2])
                {
                    //And end it off with dialogue boxes here if needed!
                    //choiceManager.SetActive(true);
                    onLastSentence = true;
                    StopCoroutine(TypeChoiceTwo());
                    StartCoroutine(LoadSceneC2());
                
                  
                }
               
            }
 
        }
    }
    
    IEnumerator TypeChoiceThree()
    {
        foreach (char letter in choiceThreeSentences[indexC3].ToCharArray())
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
        choiceThreeScript.choiceThree = false;
    }
    
    public void NextSentenceChoiceThree()
    {
        if (indexC3 < choiceThreeSentences.Length - 1)
        {
            indexC3++;
            textDisplay.text = "";
            StartCoroutine(TypeChoiceThree());
        }
      
        //We run through these nested if statements if 
        //We are on the last sentence
        //Make sure this only happens once
        if (onLastSentence == false)
        {
            if (indexC3 > choiceThreeSentences.Length - 2)
            {
                //I can change the sprites in here.
                Debug.Log("On last sentence");
                shouldAnimateCharacter = true;
                //Set this to false via character script.

                if (textDisplay.text == choiceThreeSentences[indexC3])
                {
                    //And end it off with dialogue boxes here if needed!
                    //choiceManager.SetActive(true);
                    onLastSentence = true;
                    StopCoroutine(TypeChoiceThree());
                    StartCoroutine(LoadSceneC3());
                    
                  
                }
               
            }
 
        }
    }

    IEnumerator LoadSceneC1()
    {
        if (aninmateTransistion)
        {
            activateTransistionAnim = true;
        }
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(sceneToLoad1);
    }
    
    IEnumerator LoadSceneC2()
    {
        if (aninmateTransistion)
        {
            activateTransistionAnim = true;
        }
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(sceneToLoad2);
    }
    
    IEnumerator LoadSceneC3()
    {
        if (aninmateTransistion)
        {
            activateTransistionAnim = true;
        }
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(sceneToLoad3);
    }
    
   
    

}
