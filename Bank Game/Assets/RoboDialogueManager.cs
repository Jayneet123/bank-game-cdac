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
    [SerializeField] private string[] roboDialogueSentences1;
    [SerializeField] private GameObject roboContinueButton;
    [SerializeField] private GameObject roboTutorialSpeechBubble;
    private int roboIndex;
    private int roboIndex1 = 0;
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
        if(roboIndex==3||roboIndex1 == 1){
            roboSpeechBubbleAnimator.SetTrigger("Close");
            roboAnimator.SetTrigger("isFinished");
            roboTutorialSpeechBubble.SetActive(false);
        }
        if(roboIndex < roboDialogueSentences.Length){
            roboContinueButton.SetActive(false);
            if (FormManager.level1Complete == 0){
                foreach(char letter in roboDialogueSentences[roboIndex].ToCharArray())
                {
                    roboDialogueText.text += letter;
                    yield return new WaitForSeconds(typingSpeed);
                }
            }
            if (FormManager.level1Complete == 1){
                foreach(char letter in roboDialogueSentences1[roboIndex1].ToCharArray())
                {
                    roboIndex1 = 1;
                    roboDialogueText.text += letter;
                    yield return new WaitForSeconds(typingSpeed);
                }
            }
            // Debug.Log("W");
        }
        roboIndex++;
        roboContinueButton.SetActive(true);
    }
    public void TriggerTypeRoboDialogue(){
        StartCoroutine(TypeRoboDialogue());
    }
}


