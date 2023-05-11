using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonController : MonoBehaviour
{
    public TextMeshProUGUI buttonText;
    public TMP_InputField inputPin;
    public bool pinfinished=false;
    public TMP_InputField inputAmt;

    // Update is called once per frame
    public void ValueWhenButtonClicked()
    {
        if(inputPin.text.Length<4){
            inputPin.text += buttonText.text;
            pinfinished = true;
        }    
        else if(inputAmt.text.Length<4){
            inputAmt.text += buttonText.text;
        }
            
    }
}
