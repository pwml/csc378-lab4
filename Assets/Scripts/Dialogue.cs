//Unity 2D Platformer Tutorial 36 - Dialogue System by Antarsoft
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    //Fields
    //Window
    public GameObject window;
    //Indicator 
    public GameObject indicator;
    //Text component
    public TMP_Text dialogueText;
    //Dialogues list
    public List<string> dialogues;
    //writing speed
    public float writingSpeed;
    //Index on dialogues
    private int index;
    //character index
    private int charIndex;
    //Started boolean
    private bool started;
    //wait for next boolean
    private bool waitForNext;

    private void Awake()
    {
        ToggleIndicator(false);
        ToggleWindow(false);
    }

    private void ToggleWindow(bool show)
    {
        window.SetActive(show);
    }

    public void ToggleIndicator(bool show)
    {
        indicator.SetActive(show);
    }

    //start dialogue
    public void StartDialogue()
    {
        if (started)
        {
            return;
        }

        //boolean to indicate that we have started
        started = true;
        //show the window 
        ToggleWindow(true);
        //hide the indicator
        ToggleIndicator(false);
        //start with first dialogue
        GetDialogue(0);
    }

    private void GetDialogue(int i)
    {
        //start index at zero
        index = i;
        //reset the character index
        charIndex = 0;
        //clear the dialogue component text
        charIndex = 0;
        //clear the dialogue component text
        dialogueText.text = string.Empty;
        //start writing
        StartCoroutine(Writing());
    }

    //end dialogue
    public void EndDialogue()
    {
        //started is disabled 
        started = false;
        //disable wait for next as well
        waitForNext = false;
        //stop all Ienumerators
        StopAllCoroutines();
        //hide the window
        ToggleWindow(false);
    }

    //writing logic
    IEnumerator Writing()
    {
        yield return new WaitForSeconds(writingSpeed);

        string currentDialogue = dialogues[index];
        //write the character
        dialogueText.text += currentDialogue[charIndex];
        //increase the character index
        charIndex++;
        //make sure you have reached the end of the sentence
        if (charIndex < currentDialogue.Length)
        {
            //wait for x seconds
            yield return new WaitForSeconds(writingSpeed);
            //restart the same process 
            StartCoroutine(Writing());
        }
        else
        {
            //end this sentence and wait for the next one
            waitForNext = true;
        }
    }

    private void update()
    {
        if (!started)
        {
            return;
        }

        if (waitForNext && Input.GetKeyDown(KeyCode.E))
        {
            waitForNext = false;
            index++;

            //check if we are in the scope of dialogues list
            if (index < dialogues.Count)
            {
                //if so fetch the next dialogue
                GetDialogue(index);
            }
            else
            {
                //if not end the dialogue process
                ToggleIndicator(true);
                EndDialogue();
            }
        }
    }
}
