using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NewDialogueManager : MonoBehaviour
{
    [SerializeField] private float typingSpeed = 0.05f;

    [SerializeField] private bool PlayerSpeakingFirst;
    [Header("Dialogue TMP text")]
    [SerializeField] private TextMeshProUGUI playerDialogueText;
    [SerializeField] private TextMeshProUGUI nPCDialogueText;
    [Header("Animation Controllers")]
    [SerializeField] private Animator playerSpeechBubbleAnimator;
    [SerializeField] private Animator nPCSpeechBubbleAnimator;
    // [Header("Dialogue Sentences")]
    [SerializeField] private string[] playerDialogueSentences;
    [SerializeField] private string[] nPCDialogueSentences;

    [Header("Dialogue Buttons")]
    [SerializeField] private GameObject playerContinueButton;
    [SerializeField] private GameObject nPCContinueButton;
    private bool dialogueStarted;

    private int playerIndex;
    private int nPCIndex;
    private float speechBubbleAnimationDelay = 0.6f;


    private void Start(){
        StartCoroutine(StartDialogue());
     }

    public IEnumerator StartDialogue()
    {
        if (PlayerSpeakingFirst){
            playerSpeechBubbleAnimator.SetTrigger("Open");
            yield return new WaitForSeconds(speechBubbleAnimationDelay);
            StartCoroutine(TypePlayerDialogue());
        }
        else
        {
            nPCSpeechBubbleAnimator.SetTrigger("Open");
            yield return new WaitForSeconds(speechBubbleAnimationDelay);
            StartCoroutine(TypeNPCDialogue());
        }
    }

    private IEnumerator TypePlayerDialogue()
    {
        foreach(char letter in playerDialogueSentences[playerIndex].ToCharArray())
        {
            playerDialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        playerContinueButton.SetActive(true);
    }

    private IEnumerator TypeNPCDialogue()
    {
        foreach(char  letter in nPCDialogueSentences[nPCIndex].ToCharArray())
        {
            nPCDialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        nPCContinueButton.SetActive(true);
    }
    public void ContinuePlayerDialogue()
    {
        nPCDialogueText.text = string.Empty;
        nPCSpeechBubbleAnimator.SetTrigger("Close");
        yield return  new WaitForSeconds(speechBubbleAnimationDelay);
        
        playerDialogueText.text = string.Empty;
        playerSpeechBubbleAnimator.SetTrigger("Open");
        yield return  new WaitForSeconds(speechBubbleAnimationDelay);

        nPCContinueButton.SetActive(false);
        if(playerIndex < playerDialogueSentences.Length - 1)
        {
            if(dialogueStarted)
            playerIndex++;
            else 
               dialogueStarted = true;

            playerDialogueText.text = string.Empty;
            StartCoroutine(TypePlayerDialogue());
        }
    }
    public void ContinueNPCDialogue()
    {
        playerDialogueText.text = string.Empty;
        playerSpeechBubbleAnimator.SetTrigger("Close");
        yield return  new WaitForSeconds(speechBubbleAnimationDelay);

        nPCDialogueText.text = string.Empty;
        nPCSpeechBubbleAnimator.SetTrigger("Open");
        yield return  new WaitForSeconds(speechBubbleAnimationDelay);
        playerContinueButton.SetActive(false);
        if(nPCIndex < nPCDialogueSentences.Length - 1)
        {
            if(dialogueStarted)
            nPCIndex++;
            else 
               dialogueStarted = true;

            nPCDialogueText.text = string.Empty;
            StartCoroutine(TypeNPCDialogue());
        }
    }

    public void TriggerContinuePlayerDialogue(){
        StartCoroutine(ContinuePlayerDialogue());
    }

    public void TriggerContinueNPCDialogue(){
        StartCoroutine(ContinueNPCDialogue());
    }
}