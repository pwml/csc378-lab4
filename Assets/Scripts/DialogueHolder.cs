using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueHolder : MonoBehaviour
{
    public string dialogue;
    private DialogueManager dMan;
    private bool playerEnter;

    // Start is called before the first frame update
    void Start()
    {
        dMan = FindObjectOfType<DialogueManager>();    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.T) && playerEnter && !dMan.dialogueActive)
        {
            dMan.ShowBox(dialogue);
        }
        else if (Input.GetKeyUp(KeyCode.T) && playerEnter && dMan.dialogueActive)
        {
            dMan.HideBox();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Bear")
        {
            playerEnter = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Bear")
        {
            dMan.HideBox();
            playerEnter = false;
        }
    }
}
