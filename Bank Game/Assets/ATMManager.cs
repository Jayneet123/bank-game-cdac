using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using TMPro;

public class ATMManager : MonoBehaviour
{
    public GameObject background;
    public GameObject atm;    
    public GameObject creditCard;    
    public GameObject atmModel;     
    public GameObject note;   

    //ATM Working
    public Animator cardAnimator;
    public Animator noteAnimator;
    public GameObject insertCard;
    public GameObject insertPin;
    public GameObject cashDeposit;
    public GameObject accountType;
    public GameObject withdraw;
    public GameObject processing;
    public GameObject collectCash;
    public TMP_InputField inputPin;
    public TextMeshProUGUI enterButton;
    public TextMeshProUGUI rightButton;
    public TextMeshProUGUI leftButton;
    public int counter=0;

    // Start is called before the first frame update
    void Start()
    {
        atmModel.SetActive(true);
        background.SetActive(true);        
    }

    public void onAtmEnter(){
        atmModel.SetActive(false);
        background.SetActive(false);
        atm.SetActive(true);
        creditCard.SetActive(true);
        insertCard.SetActive(true);
    }

    public void onCardClick(){
        cardAnimator.SetTrigger("clicked");
        insertPin.SetActive(true);
        insertCard.SetActive(false);
    }

    public void ClearScreen(){
        string emptyText= "";
        inputPin.text = emptyText;
    }

    public IEnumerator EnterClick(){
            if(counter==0){
                insertPin.SetActive(false);
                processing.SetActive(true);
                yield return new WaitForSeconds(3);
                accountType.SetActive(true);
                counter++;
            }
            else if(counter==1){
                withdraw.SetActive(false);
                processing.SetActive(true);
                yield return new WaitForSeconds(2);
                collectCash.SetActive(true);
                //Animation
                note.SetActive(true);
                noteAnimator.SetTrigger("isWithdrawn");
            }
    }

    public void onEnterClick(){
        StartCoroutine(EnterClick());
    }

    public IEnumerator onSideButtonClick(){
        accountType.SetActive(false);
        processing.SetActive(true);
        yield return new WaitForSeconds(3);
        withdraw.SetActive(true);
    }

    public void onSideClick(){
        StartCoroutine(onSideButtonClick());
    }
}
