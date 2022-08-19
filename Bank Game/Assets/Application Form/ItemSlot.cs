using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ItemSlot : MonoBehaviour , IDropHandler
{
    public TextMeshProUGUI name;
    // public TextMeshProUGUI onNameField;
    public TMP_InputField gameObject;
    public void OnDrop(PointerEventData eventData){
        Debug.Log("OnDrop");
        // if (eventData.pointerDrag != null){
        //     eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
        // }
        gameObject.text = name.text;
        name.text = " ";
        // gameObject.interactable=false;
        // gameObject.text="";
        
    }
}
