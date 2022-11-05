using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChequeManagerScript : MonoBehaviour
{
    public TextMeshProUGUI score;

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

    private int counter=0;

    private string[] chequeNames = {"John Shah"};
    private string[] dates = {"01/10/2022"};
    private string[] rupees = {"50,000"};
    private string[] textRupees = {"Fifty Thousand only/-"};
    private string[] signs = {"JShah."};
    
    void Awake(){
        chequeName.text = chequeNames[0];
        date.text = dates[0];
        rupee.text = rupees[0];
        textRupee.text = textRupees[0];
        sign.text = signs[0];
    }
    void Start()
    {
        score.text = FormManager.Score.ToString();
    }

    public void onSubmitCheque(){
        if((chequeNameInput.text==chequeNames[0])&&(dateInput.text==dates[0])&&(rupeeInput.text==rupees[0])&&(textRupeeInput.text==textRupees[0])&&(signInput.text==signs[0])){
            counter++;
            Debug.Log("Success");
        }
    }
}