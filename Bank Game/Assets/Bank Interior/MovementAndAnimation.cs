using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEditor;
using UnityEngine.SceneManagement;

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
    public GameObject canvasObject;
    public GameObject otherCamCanvas;
    public GameObject wrongDesk;

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
        if(FormManager.level1Complete == 0){
            if (hit.gameObject.CompareTag("Desk Level 1")){
                mainCam.SetActive(false);
                cam2.SetActive(true);
                OnDisable();
                newDialogueManager.SetActive(true);
                dialogueBackButton.enabled = true;
                normalBackButton.enabled = false;
                otherCamCanvas.SetActive(true);
            }
            else {
                if (hit.gameObject.CompareTag("Desk Level 2")){
                    wrongDesk.SetActive(true);
                }
            }
        }
        if(FormManager.level1Complete == 1){
            if (hit.gameObject.CompareTag("Desk Level 1")){
                wrongDesk.SetActive(true);
            }
            else {
                if (hit.gameObject.CompareTag("Desk Level 2")){
                    OnDisable();
                    SceneManager.LoadScene("Cheque");
                }
            }
        }
        if (hit.gameObject.CompareTag("Finish")){
            Debug.Log("Out of the area");
            // EditorUtility.DisplayDialog("Error! Going out of the play area","Please return to the play zone by pressing W","Ok","Cancel");
            canvasObject.SetActive(true);
        }
    }
}
