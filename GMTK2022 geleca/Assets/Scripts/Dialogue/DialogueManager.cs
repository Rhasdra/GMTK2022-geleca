using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class DialogueManager : MonoBehaviour, IInteractable
{
    public float typingSpeed = 10;   
    [SerializeField] TypeWriter dialogueBox;
    [SerializeField] SpriteRenderer sprite;
    [SerializeField] AudioSource audio;
    [SerializeField] DialogueObject[] dialogueObject;

    [SerializeField] int objectIndex = 0;
    [SerializeField] int sentenceIndex = 0;
    [SerializeField] bool isFirstText = true;
    [SerializeField] bool isLastText = false;


    public UnityEvent OnDialogueStart;
    public UnityEvent OnLineStart;
    public UnityEvent OnLastLine;
    public UnityEvent OnEndOfDialogues;

    private void Awake() 
    {
        typingSpeed = (typingSpeed / 1000);
    }

    private void NextDialogue() 
    {
        TypeDialogue(dialogueObject[objectIndex], typingSpeed);
        OnLineStart.Invoke();

        if(dialogueObject[objectIndex].Expression != null)
        sprite.sprite = dialogueObject[objectIndex].Expression;

        if(dialogueObject[objectIndex].Sound != null)
        audio.clip = dialogueObject[objectIndex].Sound;
    }

    private void TypeDialogue(DialogueObject dialogueObject, float typingSpeed)
    {
        dialogueBox.Type(dialogueObject.Sentence[sentenceIndex], typingSpeed);
    }

    public void Interact()
    {
        if (dialogueBox.isTyping)
        {
            dialogueBox.RushText();
            return;
        }
        else
        {
            if(isFirstText)
            {
                isFirstText = false;
                OnDialogueStart.Invoke();
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

                //Last Line of the dialogue
                if(objectIndex == dialogueObject.Length-1 && sentenceIndex == dialogueObject[objectIndex].Sentence.Length-1)
                {OnLastLine.Invoke();}

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
                    OnEndOfDialogues.Invoke();
                }
                }
            }
        }
    }
