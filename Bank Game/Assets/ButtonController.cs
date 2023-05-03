using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonController : MonoBehaviour
{
    public TextMeshProUGUI buttonText;
    public TMP_InputField input;

    // Update is called once per frame
    public void ValueWhenButtonClicked()
    {
        if(input.text.Length<5)
        input.text += buttonText.text;
    }
}
