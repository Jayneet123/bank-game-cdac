using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEditor;

public class MovementAndAnimation : MonoBehaviour
{
    PlayerInput playerInput;
    CharacterController characterController;
    Animator animator;
    
    //Robot Controls
    public GameObject robo;
    public GameObject roboDialogue;

    Vector2 currentMovementInput;
    Vector3 currentMovement;
    bool isMovementPressed; 
    float rotationFactorPerFrame = 15.0f;
    public GameObject canvas;

    public GameObject mainCam;
    public GameObject cam2;
    public GameObject newDialogueManager;
    public Canvas dialogueBackButton;
    public Canvas normalBackButton;

    //runs before the start function
    void Awake(){
        playerInput = new PlayerInput();
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

        playerInput.CharacterControls.Run.started += onMovementInput;
        playerInput.CharacterControls.Run.canceled += onMovementInput;

        void onMovementInput(InputAction.CallbackContext context){
            currentMovementInput = context.ReadValue<Vector2>();
            currentMovement.x = currentMovementInput.x;
            currentMovement.z = currentMovementInput.y;
            isMovementPressed = currentMovementInput.x != 0 || currentMovementInput.y !=0;
        }
    }

    void handleRotation(){
        Vector3 positionToLookAt;
        positionToLookAt.x = currentMovement.x;
        positionToLookAt.y = 0.0f;
        positionToLookAt.z = currentMovement.z;

        Quaternion currentRotation = transform.rotation;
        if (isMovementPressed){
            robo.SetActive(false);
            roboDialogue.SetActive(false);
            Quaternion targetRotation = Quaternion.LookRotation(positionToLookAt);
            transform.rotation = Quaternion.Slerp(currentRotation,targetRotation,rotationFactorPerFrame);
        }
            
    }

    void handleAnimation(){
        bool Run = animator.GetBool("Run");
        if(isMovementPressed && !Run){
            animator.SetBool("Run",true);
        }

        if(!isMovementPressed && Run){
            animator.SetBool("Run",false);
        }

    }

    void Update()
    {
        handleRotation();
        handleAnimation();
        characterController.Move(currentMovement* Time.deltaTime);
    }

    void OnEnable(){
        playerInput.CharacterControls.Enable();
    }

    void OnDisable(){
        playerInput.CharacterControls.Disable();
    }   
    void OnControllerColliderHit(ControllerColliderHit hit){
        if (hit.gameObject.CompareTag("Desk")){
            mainCam.SetActive(false);
            cam2.SetActive(true);
            OnDisable();
            newDialogueManager.SetActive(true);
            dialogueBackButton.enabled = true;
            normalBackButton.enabled = false;
        }
        if (hit.gameObject.CompareTag("Finish")){
            EditorUtility.DisplayDialog("Error! Going out of the play area","Please return to the play zone by pressing W","Ok","Cancel");
        }
    }
}
