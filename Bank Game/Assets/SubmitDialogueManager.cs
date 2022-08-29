using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SubmitDialogueManager : MonoBehaviour
{
    [SerializeField] private float typingSpeed = 0.05f;

    [SerializeField] private TextMeshProUGUI DialogueText;
    [SerializeField] private Animator SpeechBubbleAnimator;
    // [SerializeField] private Animator Animator;
    [SerializeField] private string[] DialogueSentences;
    [SerializeField] private GameObject ContinueButton;
    [SerializeField] private GameObject TutorialSpeechBubble;
    private int Index;
    private float speechBubbleAnimationDelay = 0.0f;
    private void Start()
    {
        StartCoroutine(StartDialogue());
    }

    private IEnumerator StartDialogue(){
        SpeechBubbleAnimator.SetTrigger("Open");
        TutorialSpeechBubble.SetActive(true);
        yield return new WaitForSeconds(speechBubbleAnimationDelay);
        StartCoroutine(TypeDialogue());
    }
    public IEnumerator TypeDialogue(){
        DialogueText.text = string.Empty;
        if(Index==2){
            SpeechBubbleAnimator.SetTrigger("Close");
            // Animator.SetTrigger("isFinished");
            TutorialSpeechBubble.SetActive(false);
        }
        if(Index < DialogueSentences.Length){
            ContinueButton.SetActive(false);
            foreach(char letter in DialogueSentences[Index].ToCharArray())
            {
                DialogueText.text += letter;
                yield return new WaitForSeconds(typingSpeed);
            }
            Debug.Log("W");
        }
        Index++;
        ContinueButton.SetActive(true);
    }
    public void TriggerTypeDialogue(){
        StartCoroutine(TypeDialogue());
    }
}

