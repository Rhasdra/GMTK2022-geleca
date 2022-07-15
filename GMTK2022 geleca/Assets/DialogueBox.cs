using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueBox : MonoBehaviour, IDialogueBox
{
    TextMeshProUGUI textBox;
    public bool isTyping = false;

    private string currentText = string.Empty;
    private IEnumerator coroutine;

    private void Awake() 
    {
        textBox = GetComponent<TextMeshProUGUI>();
        textBox.text = string.Empty;
    }

    public void Type(string textToType, float typingSpeed)
    {
        textBox.text = string.Empty;
        currentText = textToType;
        isTyping = true;
        coroutine = TypeText(textToType, typingSpeed);
        StartCoroutine(coroutine);
    }

    private IEnumerator TypeText(string textToType, float typingSpeed)
    {
        int i = 0;
        foreach(char letter in textToType.ToCharArray()){
            textBox.text += letter;

            if(i < textToType.Length -1)
            {
                i++;
                yield return new WaitForSeconds(typingSpeed);
            }
            else
            {
                isTyping = false;
                yield break;
            }
        }
    }

    public void RushText()
    {
        StopCoroutine(coroutine);
        textBox.text = currentText;
        isTyping = false;
    }
}