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

    public int counter=0;

    private string[] chequeNames = {"John Shah","Jack Das","Raj Tomar","Riya Shah","Alice Gupta"};
    private string[] dates = {"01/10/2022","02/02/2022","30/04/2022","21/08/2022","31/10/2022"};
    private string[] rupees = {"50,000/-","30,000/-","28,000/-","80,000/-","20,000/-"};
    private string[] textRupees = {"Fifty Thousand only/-","Thirty Thousand only/-","Twenty Eight Thousand only/-","Eighty Thousand only/-","Twenty Thousand only/-"};
    private string[] signs = {"RTomar.","RShah","DDoshi.","MGupta.","AGupta."};
    private string[] descriptions = {"Additional Information\n\n\nYou are Ramesh Tomar.\nYou are writing a cheque to John Shah to pay a sum of 50000 rupees on the date 01/10/2022.\nYou are transferring the money from a/c no: IDIB000K023 to a/c no: DDIC000M057.\nYou live in Malad West, Mumbai, Maharshtra.\nPlease fill the reciept to complete the cheque deposit.","Additional Information\n\n\nYou are Ramesh Shah.\nYou are writing a cheque to Jack Das to pay a sum of 30000 rupees on the date 02/02/2022.\nYou are transferring the money from a/c no: IDIB000K023 to a/c no: DDIC000M057.\nYou live in Malad West, Mumbai, Maharshtra.\nPlease fill the reciept to complete the cheque deposit.","Additional Information\n\n\nYou are Dinesh Doshi.\nYou are writing a cheque to Raj Tomar to pay a sum of 28000 rupees on the date 30/04/2022.\nYou are transferring the money from a/c no: IDIB000K023 to a/c no: DDIC000M057.\nYou live in Malad West, Mumbai, Maharshtra.\nPlease fill the reciept to complete the cheque deposit.","Additional Information\n\n\nYou are Manish Gupta.\nYou are writing a cheque to Riya Shah to pay a sum of 80000 rupees on the date 21/08/2022.\nYou are transferring the money from a/c no: IDIB000K023 to a/c no: DDIC000M057.\nYou live in Malad West, Mumbai, Maharshtra.\nPlease fill the reciept to complete the cheque deposit.","Additional Information\n\n\nYou are Akash Gupta.\nYou are writing a cheque to Alice Gupta to pay a sum of 20000 rupees on the date 31/10/2022.\nYou are transferring the money from a/c no: IDIB000K023 to a/c no: DDIC000M057.\nYou live in Malad West, Mumbai, Maharshtra.\nPlease fill the reciept to complete the cheque deposit.",};
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
    }
    void Start()
    {
        score.text = FormManager.Score.ToString();
    }

    public void onSubmitCheque(){
        mail.SetActive(true);
        if((chequeNameInput.text==chequeNames[j])&&(dateInput.text==dates[j])&&(rupeeInput.text==rupees[j])&&(textRupeeInput.text==textRupees[j])&&(signInput.text==signs[j])){
            counter++;
        }
        Debug.Log("Success");
    }

    public void onMailClick(){
        Debug.Log(counter);
        if(counter==0){
            failed.SetActive(true);
        }
        if(counter==1){
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
