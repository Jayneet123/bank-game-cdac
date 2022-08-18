using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class FormManager : MonoBehaviour
{
    public GameObject aadharNumber;
    public GameObject aadharNumberOnCard;
    private int counter = 0;
    
    public void onSubmit(){
        if (aadharNumber.tag == aadharNumberOnCard.tag){
            counter++;
            Debug.Log("Counter");
        }
    }
}
