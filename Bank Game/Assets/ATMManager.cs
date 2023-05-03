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

    //ATM Working
    public Animator cardAnimator;
    public GameObject insertCard;
    public GameObject insertPin;
    public GameObject cashDeposit;
    public GameObject accountType;
    public GameObject withdraw;
    public GameObject processing;
    public GameObject collectCash;
    public TMP_InputField inputPin;
    public TextMeshProUGUI Button;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void onAtmEnter(){
        atmModel.SetActive(false);
        background.SetActive(false);
        atm.SetActive(true);
        creditCard.SetActive(true);
    }

    public void onCardClick(){
        cardAnimator.SetTrigger("clicked");
        insertPin.SetActive(true);
        insertCard.SetActive(false);
    }

    public void forPin(){
        while(inputPin.text.Length<5){
            this.Button.text += inputPin.text;
        }
    }
}
