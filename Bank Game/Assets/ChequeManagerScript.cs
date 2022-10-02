using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChequeManagerScript : MonoBehaviour
{
    public TextMeshProUGUI score;
    
    void Start()
    {
        score.text = FormManager.Score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
