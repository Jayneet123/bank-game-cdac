using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour , IDropHandler
{
    public Text name;
    public Text onNameField;
    public void OnDrop(PointerEventData eventData){
        Debug.Log("OnDrop");
        // if (eventData.pointerDrag != null){
        //     eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
        // }
        onNameField.text = name.text;
        name.text = " ";
        
    }
}
