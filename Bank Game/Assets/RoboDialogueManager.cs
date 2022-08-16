using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RoboDialogueManager : MonoBehaviour
{
    [SerializeField] private float typingSpeed = 0.05f;

    [SerializeField] private TextMeshProUGUI roboDialogueText;
    [SerializeField] private Animator roboSpeechBubbleAnimator;
    [SerializeField] private Animator roboAnimator;
    [SerializeField] private string[] roboDialogueSentences;
    [SerializeField] private GameObject roboContinueButton;
    [SerializeField] private GameObject roboTutorialSpeechBubble;
    private int roboIndex;
    private float speechBubbleAnimationDelay = 0.0f;
    private void Start()
    {
        StartCoroutine(StartDialogue());
    }

    private IEnumerator StartDialogue(){
        roboSpeechBubbleAnimator.SetTrigger("Open");
        roboTutorialSpeechBubble.SetActive(true);
        yield return new WaitForSeconds(speechBubbleAnimationDelay);
        StartCoroutine(TypeRoboDialogue());
    }
    public IEnumerator TypeRoboDialogue(){
        roboDialogueText.text = string.Empty;
        if(roboIndex==3){
            roboSpeechBubbleAnimator.SetTrigger("Close");
            roboAnimator.SetTrigger("isFinished");
            roboTutorialSpeechBubble.SetActive(false);
        }
        if(roboIndex < roboDialogueSentences.Length){
            roboContinueButton.SetActive(false);
            foreach(char letter in roboDialogueSentences[roboIndex].ToCharArray())
            {
                roboDialogueText.text += letter;
                yield return new WaitForSeconds(typingSpeed);
            }
            Debug.Log("W");
        }
        roboIndex++;
        roboContinueButton.SetActive(true);
    }
    public void TriggerTypeRoboDialogue(){
        StartCoroutine(TypeRoboDialogue());
    }
}


