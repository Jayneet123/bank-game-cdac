using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class DragAndDropCodeMonkey : MonoBehaviour , IPointerDownHandler , IBeginDragHandler , IEndDragHandler , IDragHandler
{
    [SerializeField] private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    private void Awake(){
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnPointerDown(PointerEventData eventData){
        // Debug.Log("OnPointerDown");
        canvasGroup.enabled = true;
    }

    public void OnBeginDrag(PointerEventData eventData){
        // Debug.Log("OnBeginDrag");
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = 0.6f;
    }

    public void OnDrag(PointerEventData eventData){
        // Debug.Log("OnDrag");
        Vector2 position;
        RectTransformUtility.ScreenPointToLocalPointInRectangle((RectTransform)canvas.transform,
        eventData.position,canvas.worldCamera,out position);
        transform.position=canvas.transform.TransformPoint(position);
    }

    public void OnEndDrag(PointerEventData eventData){
        // Debug.Log("OnEndDrag");
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }

}
