using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATMManager : MonoBehaviour
{
    public GameObject background;
    public GameObject atm;    
    public GameObject creditCard;    
    public GameObject atmModel;        

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void onAtmEnter(){
        atmModel.SetActive(false);
        background.SetActive(false);
        atm.SetActive(true);
    }
}
