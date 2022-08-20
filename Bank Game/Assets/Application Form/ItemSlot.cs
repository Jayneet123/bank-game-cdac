using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ItemSlot : MonoBehaviour , IDropHandler
{
    public TMP_InputField gameObject;
    public void OnDrop(PointerEventData eventData){
        Debug.Log(eventData.pointerDrag);
        gameObject.text = eventData.pointerDrag.GetComponent<TextMeshProUGUI>().text;
        eventData.pointerDrag.GetComponent<TextMeshProUGUI>().text = " ";
    }
}
