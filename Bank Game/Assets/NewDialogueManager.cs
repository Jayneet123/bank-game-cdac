using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NewDialogueManager : MonoBehaviour
{
    [SerializeField] private float typingSpeed = 0.05f;

    [SerializeField] private bool PlayerSpeakingFirst;
    [SerializeField] private TextMeshPro playerDialogueText;
    [SerializeField] private TextMeshProUGUI nCPDialogueText;

    [SerializeField] private string[] playerDialogueSentences;
    [SerializeField] private string[] nCPDialogueSentences;

    [SerializeField] private GameObject playerContinueButton;
    [SerializeField] private GameObject nPCContinueButton;

    private int playerIndex;
    private int nPCIndex;
     private void Start(){
        StartDialogue();
     }

    public void StartDialogue()
    {
        if (PlayerSpeakingFirst){
            StartCoroutine(TypePlayerDialogue());
        }
        else
        {
            StartCoroutine(TypeNPCDialogue());
        }

        
        
    }

    private IEnumerator TypePlayerDialogue()
    {
        foreach(char  letter in playerDialogueSentences[playerIndex].ToCharArray())
        {
            playerDialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    private IEnumerator TypeNPCDialogue()
    {
        foreach(char  letter in nPCDialogueSentences[nPCIndex].ToCharArray())
        {
            nPCDialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}