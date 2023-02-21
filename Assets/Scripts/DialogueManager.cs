using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public GameObject dBox;
    public TextMeshProUGUI dText;
    public bool dialogueActive;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowBox(string dialogue)
    {
        dialogueActive = true;
        dBox.SetActive(true);
        dText.text = dialogue;
    }

    public void HideBox()
    {
        dialogueActive = false;
        dBox.SetActive(false);
    }
}
