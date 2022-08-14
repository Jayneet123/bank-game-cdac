using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DragAndDropInputSystem : MonoBehaviour
{
    [SerializeField] private InputAction mouseClick;
    [SerializeField] private float mouseDragPhysicsSpeed = 10;
    private Camera mainCamera;
    private WaitForFixedUpdate waitForFixedUpdate = new WaitForFixedUpdate();
    [SerializeField] private float mouseDragSpeed = 0.1f;
    private Vector3 velocity = Vector3.zero;

    private void Awake(){
        mainCamera= Camera.main;
    }

    private void OnEnable(){
        mouseClick.Enable();
        mouseClick.performed += MousePressed;
    }

    private void onDisable(){
        mouseClick.performed -= MousePressed;
        mouseClick.Disable();
    }

    private void MousePressed(InputAction.CallbackContext context){
        Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit)){
            if (hit.collider != null){
                StartCoroutine(DragUpdate(hit.collider.gameObject));
            }
        }
    }

    private IEnumerator DragUpdate(GameObject clickedObject){
        float initialDistance = Vector3.Distance(clickedObject.transform.position,mainCamera.transform.position);
        clickedObject.TryGetComponent<Rigidbody>(out var rb);
        while(mouseClick.ReadValue<float>() != 0){
            Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
            if(rb != null){
                Vector3 direction = ray.GetPoint(initialDistance)-clickedObject.transform.position;
                rb.velocity = direction*mouseDragPhysicsSpeed;
                yield return waitForFixedUpdate;
            }
            else{
                clickedObject.transform.position = Vector3.SmoothDamp(clickedObject.transform.position,ray.GetPoint(initialDistance),ref velocity,mouseDragSpeed);
                yield return null;
            }
        }
    }
}
