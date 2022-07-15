using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class DialogueManager : MonoBehaviour, IInteractable
{
    public float typingSpeed = 50;
    [SerializeField] DialogueObject[] dialogueObject;
    [SerializeField] int objectIndex = 0;
    [SerializeField] int sentenceIndex = 0;
    [SerializeField] bool isFirstText = true;
    [SerializeField] bool isLastText = false;

    IDialogueBox dialogueBox;

    public UnityEvent DialogueStart;
    public UnityEvent EndOfDialogues;

    private void Awake() 
    {
        typingSpeed = (typingSpeed / 1000);
        dialogueBox = GetComponent<IDialogueBox>();
    }

    private void NextDialogue() 
    {
        TypeDialogue(dialogueObject[objectIndex], typingSpeed);
        DialogueStart.Invoke();
    }

    private void TypeDialogue(DialogueObject dialogueObject, float typingSpeed)
    {
        dialogueBox.Type(dialogueObject.Sentence[sentenceIndex], typingSpeed);
    }

    public void Interact()
    {
        TypeWriter current = GetComponent<TypeWriter>();

        if (current.isTyping)
        {
            current.RushText();
            return;
        }
        else
        {
            if(isFirstText)
            {
                isFirstText = false;
                NextDialogue();
                return;
            }     
            if(isLastText)
            {
                return;
            }

            if(sentenceIndex < dialogueObject[objectIndex].Sentence.Length - 1)
            {
                sentenceIndex += 1;
                NextDialogue();
                return;
            }
            else
            {
                sentenceIndex = 0;
                if(objectIndex < dialogueObject.Length -1)
                {
                    objectIndex += 1;
                    NextDialogue();
                    return;
                }
                else
                {
                    isLastText = true;
                    EndOfDialogues.Invoke();
                    Debug.Log("ACABOU O DIALOGO");
                }
                }
            }
        }
    }
