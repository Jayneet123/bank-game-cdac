using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.UI;

public class OnBankText : MonoBehaviour
{
    public Text onBank;
    PlayerInput playerInput;
    CharacterController characterController;
    Vector2 currentMovementInput;
    Vector3 currentMovement;
    bool isMovementPressed;

    void Awake(){
        playerInput = new PlayerInput();
        characterController = GetComponent<CharacterController>();

        playerInput.CharacterControls.Run.started += onMovementInput;
        playerInput.CharacterControls.Run.canceled += onMovementInput;
        
        void onMovementInput(InputAction.CallbackContext context){
            currentMovementInput = context.ReadValue<Vector2>();
            currentMovement.x = currentMovementInput.x;
            currentMovement.z = currentMovementInput.y;
            isMovementPressed = currentMovementInput.x != 0 || currentMovementInput.y !=0;
        }
    }   
    void Update(){
        if(isMovementPressed){
            onBank.enabled = false;
        }
    }  

    void OnEnable(){
        playerInput.CharacterControls.Enable();
    }

    void OnDisable(){
        playerInput.CharacterControls.Disable();
    }
}
