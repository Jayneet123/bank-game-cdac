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

    public int counter=0;

    private string[] chequeNames = {"John Shah","Jack Das","Raj Tomar","Riya Shah","Alice Gupta"};
    private string[] dates = {"01/10/2022","02/02/2022","30/04/2022","21/08/2022","31/10/2022"};
    private string[] rupees = {"50,000/-","30,000/-","28,000/-","80,000/-","20,000/-"};
    private string[] textRupees = {"Fifty Thousand only/-","Thirty Thousand only/-","Twenty Eight Thousand only/-","Eighty Thousand only/-","Twenty Thousand only/-"};
    private string[] signs = {"JShah.","JDas.","RTomar.","RShah.","AGupta."};
    public int j ;
    
    void Awake(){
        int i = Random.Range(0,5);
        j=i;
        chequeName.text = chequeNames[i];
        date.text = dates[i];
        rupee.text = rupees[i];
        textRupee.text = textRupees[i];
        sign.text = signs[i];
    }
    void Start()
    {
        score.text = FormManager.Score.ToString();
    }

    public void onSubmitCheque(){
        mail.SetActive(true);
        if((chequeNameInput.text==chequeNames[0])&&(dateInput.text==dates[0])&&(rupeeInput.text==rupees[0])&&(textRupeeInput.text==textRupees[0])&&(signInput.text==signs[0])){
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
