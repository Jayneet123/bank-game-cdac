using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class FormManager : MonoBehaviour
{
    public TextMeshProUGUI aadhar;
    public TMP_InputField aadharInput;
    public TextMeshProUGUI nameAadhar;
    public TextMeshProUGUI namePAN;
    public TextMeshProUGUI nameBirth;
    public TMP_InputField nameInput;
    public TextMeshProUGUI dob;
    public TMP_InputField dobInput;
    public TextMeshProUGUI motherName;
    public TMP_InputField motherNameInput;
    public TMP_InputField phone;
    public TextMeshProUGUI fatherNamePAN;
    public TextMeshProUGUI fatherNameBirth;
    public TextMeshProUGUI panNumber;
    public TextMeshProUGUI weight;
    public TextMeshProUGUI height;
    public TextMeshProUGUI day;
    public TextMeshProUGUI month;
    public TextMeshProUGUI year;

    public GameObject roboTutorialSpeech;

    public int counter = 0;
    private string[] names = {"Rahul Ram Das","Ganesh Shyam Das","Mukund Gopal Das","Raj Shravan Das","Rohan Dev Das"};
    private string[] aadharNumbers = {"123456789012","111122223333","777788889999","555566668888","333322220000"};
    private string[] dobs = {"17/12/2001","16/05/1986","08/09/1977","31/10/2002","26/02/2001"};
    private string[] motherNames = {"Sita Ram Das","Radha Shyam Das","Paravti Gopal Das","Gopi Shravan Das","Varsha Dev Das"};
    private string[] fatherNames = {"Ram Das","Shyam Das","Gopal Das","Shravan Das","Dev Das"};
    private string[] panNumbers = {"AESPD5678H","WORPD3378N","BORPD3569H","ABCEF456O7"}; 
    private string[] days = {"17th","16th","8th","31st","26th"};
    private string[] months = {"December","May","September","October","February"};
    private string[] years = {"2001","1986","1977","2002","2001"};
    public int j ;

    public GameObject try1;
    public GameObject try2;
    public GameObject try3;
    public GameObject fireworks;
    public GameObject fireworks2;
    
    static int noOfTries=1;

    private void Awake() {
        int i = Random.Range(0,5);
        j=i;
        nameAadhar.text = names[i];
        namePAN.text = names[i];
        nameBirth.text = names[i];
        aadhar.text = aadharNumbers[i];
        dob.text = dobs[i];
        fatherNamePAN.text = fatherNames[i];
        fatherNameBirth.text = fatherNames[i];
        motherName.text = motherNames[i];
        panNumber.text = panNumbers[i];
        day.text = days[i];
        month.text = months[i];
        year.text = years[i];
    }
    
    public void onSubmit(){
        if ((nameInput.text==names[j])&&(aadharInput.text==aadharNumbers[j])&&(dobInput.text==dobs[j])&&(motherNameInput.text==motherNames[j])&&(phone.text.Length == 10)){
            counter++;
            Debug.Log(counter);
        }
        else{
            Debug.Log("Error");
        }
        if (counter == 1){
            roboTutorialSpeech.SetActive(false);
            fireworks.SetActive(true);
            fireworks2.SetActive(true);
            if(noOfTries==1) try1.SetActive(true);
            if(noOfTries==2) try2.SetActive(true);
            if(noOfTries==3) try3.SetActive(true);
        }
        else {
            SceneManager.LoadScene("Application Form");
            noOfTries++;
        }

    }
    public void onBack(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
