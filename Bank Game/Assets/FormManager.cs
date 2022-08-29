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
    public TextMeshProUGUI salary;
    public TMP_InputField salaryInput;
    public TextMeshProUGUI address;
    public TMP_InputField addressInput;
    public TextMeshProUGUI email;
    public TMP_InputField emailInput;
    public TMP_InputField phone;
    public TextMeshProUGUI fatherNamePAN;
    public TextMeshProUGUI fatherNameBirth;
    public TextMeshProUGUI panNumber;
    public TextMeshProUGUI weight;
    public TextMeshProUGUI height;
    public TextMeshProUGUI day;
    public TextMeshProUGUI month;
    public TextMeshProUGUI year;
    public TextMeshProUGUI errorText;

    public GameObject roboTutorialSpeech;

    public int counter = 0;
    private string[] names = {"Rahul Ram Das","Ganesh Shyam Das","Mukund Gopal Das","Raj Shravan Das","Rohan Dev Das"};
    private string[] aadharNumbers = {"123456789012","111122223333","777788889999","555566668888","333322220000"};
    private string[] dobs = {"17/12/2001","16/05/1986","08/09/1977","31/10/2002","26/02/2001"};
    private string[] motherNames = {"Sita Ram Das","Radha Shyam Das","Paravti Gopal Das","Gopi Shravan Das","Varsha Dev Das"};
    private string[] fatherNames = {"Ram Das","Shyam Das","Gopal Das","Shravan Das","Dev Das"};
    private string[] panNumbers = {"AESPD5678H","WORPD3378N","BORPD3569H","ABCEF456OH","PENPD9090H"}; 
    private string[] days = {"17th","16th","8th","31st","26th"};
    private string[] months = {"December","May","September","October","February"};
    private string[] years = {"2001","1986","1977","2002","2001"};
    private string[] salaries = {"20,000","30,000","40,000","35,000","50,000"};
    private string[] emails = {"rahul123@gmail.com","ganesh123@gmail.com","mukund123@gmail.com","raj123@gmail.com","rohan123@gmail.com"};
    private string[] addresses = {"31  Bhiku Building st Floor V.s.marg Prabhadevi, Mumbai, Maharashtra,400025,India","45  Chord Road Rajajinagar, Bangalore, Karnataka,560022,India","Nutan Prasad Society Nutan Prasad Society Ideal Colony Near Rupee Co-op Bankkothrud Paudroad, Pune, Maharashtra,411029,India","94  Royapettah High Rd Mylapore, Chennai, Tamil Nadu,600004,India","36  Anand Sagar Nr Amar Gyan Estate Thane , Mumbai, Maharashtra,400607,India"};
    public int j ;

    public GameObject try1;
    public GameObject try2;
    public GameObject try3;
    public GameObject fireworks;
    public GameObject fireworks2;

    public GameObject aadharCard;
    public GameObject panCard;
    public GameObject birthCertificate;
    public GameObject addInfo;

    public Animator submitAnimator;
    public Animator aadharAnimator;
    public Animator panAnimator;
    public Animator birthAnimator;

    List <string> errorPlace = new List<string>();
    
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
        salary.text = salaries[j];
        address.text = addresses[j];
        email.text = emails[j];
    }
    
    public void onSubmit(){
        submitAnimator.SetTrigger("Submit");
        aadharAnimator.SetTrigger("Submit");
        panAnimator.SetTrigger("Submit");
        birthAnimator.SetTrigger("Submit");
        if (nameInput.text!=names[j]) errorPlace.Add("Full Name");
        if (aadharInput.text!=aadharNumbers[j]) errorPlace.Add("Aadhar Card Number");
        if (dobInput.text!=dobs[j]) errorPlace.Add("Date of Birth");
        if (motherNameInput.text!=motherNames[j]) errorPlace.Add("Mothers Name");
        if (phone.text.Length != 10) errorPlace.Add("Phone Number");
        if (salaryInput.text!=salaries[j]) errorPlace.Add("Salary");
        if (addressInput.text!=addresses[j]) errorPlace.Add("Address");
        if (emailInput.text!=emails[j]) errorPlace.Add("Email Address");

        if(nameInput.text==names[j]&&(aadharInput.text==aadharNumbers[j])&&(dobInput.text==dobs[j])&&(motherNameInput.text==motherNames[j])&&(phone.text.Length == 10)&&(salaryInput.text==salaries[j])&&(addressInput.text==addresses[j])&&(emailInput.text==emails[j])){
            counter++;
        }
        else{
            errorText.text = "There is an error in";
            foreach (var error in errorPlace){
                errorText.text += error+",";
            }
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
            // SceneManager.LoadScene("Application Form");
            noOfTries++;
        }

    }
    public void onBack(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void onAddInfo(){
        aadharCard.SetActive(false);
        birthCertificate.SetActive(false);
        panCard.SetActive(false);
        addInfo.SetActive(true);
    }

    public void onReturn(){
        aadharCard.SetActive(true);
        birthCertificate.SetActive(true);
        panCard.SetActive(true);
        addInfo.SetActive(false);
    }
}
