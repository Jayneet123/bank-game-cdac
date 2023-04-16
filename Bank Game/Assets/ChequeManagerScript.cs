using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ChequeManagerScript : MonoBehaviour
{
    public TextMeshProUGUI score;
    public GameObject try1;
    public GameObject mail;
    public GameObject success;
    public GameObject failed;

    public TextMeshProUGUI chequeName;
    public TMP_InputField chequeNameInput;
    public TextMeshProUGUI date;
    public TMP_InputField dateInput;
    public TextMeshProUGUI rupee;
    public TMP_InputField rupeeInput;
    public TextMeshProUGUI textRupee;
    public TMP_InputField textRupeeInput;
    public TextMeshProUGUI sign;
    public TMP_InputField signInput;

    public TextMeshProUGUI desc;
    public GameObject robotCheque;

    public int counter=0;
    public int slipcounter=0;
    // Cheque variables
    private string[] chequeNames = {"John Shah","Jack Das","Raj Tomar","Riya Shah","Alice Gupta"};
    private string[] dates = {"01/10/2022","02/02/2022","30/04/2022","21/08/2022","31/10/2022"};
    private string[] rupees = {"50,000","30,000","28,000","80,000","20,000"};
    private string[] textRupees = {"Fifty Thousand only","Thirty Thousand only","Twenty Eight Thousand only","Eighty Thousand only","Twenty Thousand only"};
    private string[] signs = {"RTomar.","RShah","DDoshi.","MGupta.","AGupta."};

    // Cheque slip variables
    public Canvas inputCanvas;
    public GameObject slip;
    private string[] descriptions = {"Additional Information\n\n\nYou are Ramesh Tomar.\nYou are writing a cheque to John Shah to pay a sum of 50000 rupees on the date 01/10/2022.\nYou are transferring the money from a/c no: IDIB000K023 to a/c no: DDIC000M057.\nYou live in Malad West, Mumbai, Maharshtra.\nPlease fill the reciept to complete the cheque deposit.","Additional Information\n\n\nYou are Ramesh Shah.\nYou are writing a cheque to Jack Das to pay a sum of 30000 rupees on the date 02/02/2022.\nYou are transferring the money from a/c no: IDIB000K023 to a/c no: DDIC000M057.\nYou live in Malad West, Mumbai, Maharshtra.\nPlease fill the reciept to complete the cheque deposit.","Additional Information\n\n\nYou are Dinesh Doshi.\nYou are writing a cheque to Raj Tomar to pay a sum of 28000 rupees on the date 30/04/2022.\nYou are transferring the money from a/c no: IDIB000K023 to a/c no: DDIC000M057.\nYou live in Malad West, Mumbai, Maharshtra.\nPlease fill the reciept to complete the cheque deposit.","Additional Information\n\n\nYou are Manish Gupta.\nYou are writing a cheque to Riya Shah to pay a sum of 80000 rupees on the date 21/08/2022.\nYou are transferring the money from a/c no: IDIB000K023 to a/c no: DDIC000M057.\nYou live in Malad West, Mumbai, Maharshtra.\nPlease fill the reciept to complete the cheque deposit.","Additional Information\n\n\nYou are Akash Gupta.\nYou are writing a cheque to Alice Gupta to pay a sum of 20000 rupees on the date 31/10/2022.\nYou are transferring the money from a/c no: IDIB000K023 to a/c no: DDIC000M057.\nYou live in Malad West, Mumbai, Maharshtra.\nPlease fill the reciept to complete the cheque deposit.",};
    public TMP_InputField branch_input;
    public TMP_InputField ac_input;
    public TMP_InputField credit_input;
    public TMP_InputField amount_input;
    public TMP_InputField totalrs_input;
    public TMP_InputField deposited_input;
    public TMP_InputField date_input;

    
    public int j ;
    
    void Awake(){
        PlayerPrefs.SetInt("level",2);
        int i = Random.Range(0,5);
        j=i;
        chequeName.text = chequeNames[i];
        date.text = dates[i];
        rupee.text = rupees[i];
        textRupee.text = textRupees[i];
        sign.text = signs[i];
        desc.text = descriptions[i];
        slip.SetActive(false);
        inputCanvas.enabled = true;
    }
    void Start()
    {
        score.text = FormManager.Score.ToString();
    }

    public void onSubmitCheque(){
        slip.SetActive(true);
        if((chequeNameInput.text==chequeNames[j])&&(dateInput.text==dates[j])&&(rupeeInput.text==rupees[j])&&(textRupeeInput.text==textRupees[j])&&(signInput.text==signs[j])){
            counter++;
        }
        Debug.Log("Success");
        inputCanvas.enabled = false;
        robotCheque.SetActive(false);
    }
    public void onSlipSubmit(){
        if((branch_input.text=="Malad West")&&(date_input.text==dates[j])&&(totalrs_input.text==rupees[j])&&(amount_input.text==textRupees[j])&&(credit_input.text==chequeNames[j])&&(ac_input.text=="IDIB000K023")){
            slipcounter++;
            Debug.Log(slipcounter);
        }
        slip.SetActive(false);
        mail.SetActive(true);
    }

    public void onMailClick(){
        Debug.Log(counter);
        if(counter==0|slipcounter==0){
            failed.SetActive(true);
        }
        if(slipcounter==1&&counter==1){
            success.SetActive(true);
        }
    }

    public void onSuccessContinue(){
        SceneManager.LoadScene("Start");
    }
    public void onFailContinue(){
        FormManager.Score -= 10;
        SceneManager.LoadScene("Cheque");
    }
}
