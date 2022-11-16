using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnHover : MonoBehaviour
{
    public GameObject gameObject;
    public void changeWhenHover(){
        gameObject.SetActive(true);
    }
    public void normalWhenHoverDone(){
        gameObject.SetActive(false);
    }
}
