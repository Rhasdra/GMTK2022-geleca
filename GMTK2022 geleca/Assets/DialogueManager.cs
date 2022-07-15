using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour, IInteractable
{
    public GameObject[] textBoxes;
    public float typingSpeed = 50;
    [SerializeField] DialogueObject[] dialogueObject;
    [SerializeField] int index = 0;
    [SerializeField] int objectIndex = 0;
    [SerializeField] int sentenceIndex = 0;

    private void Awake() 
    {
        typingSpeed = (typingSpeed / 1000);
    }

    private void Start()
    {
        textBoxes[index].GetComponent<IDialogueBox>().Type(dialogueObject[objectIndex].Sentence[objectIndex], typingSpeed);
    }

    public void Interact()
    {
        DialogueBox current = textBoxes[index].GetComponent<DialogueBox>();

        if (current.isTyping)
        {
            current.RushText();
        }
        else
        {
            //index += 1;
        }
    }
    
}
