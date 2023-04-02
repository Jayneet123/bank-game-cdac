using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class UserAccountManager : MonoBehaviour
{
    public static int counter = 0;
    public Canvas options;
    public Canvas signIn;
    public Canvas createAccount;
    public Button signInButton;
    public static UserAccountManager Instance;
    public TextMeshProUGUI errorType;
    public GameObject panel;
    public int currentLevel;

    void Awake(){
        Instance = this;
    }

    public void CreateAccount(string emailAddress,string username,string password){
        PlayFabClientAPI.RegisterPlayFabUser(
            new RegisterPlayFabUserRequest{
                Email = emailAddress,
                Password = password,
                Username = username
            },
            result => {
                panel.SetActive(true);
                errorType.text = "Account has been created successfully. Please signin";
                Debug.Log($"Successful Account Creation for {username} and {emailAddress}");
                createAccount.enabled = false;
                signIn.enabled = true;
            },
            error => {
                Debug.Log(error);
                panel.SetActive(true);
                errorType.text = $"Unsuccessful Account Creation for {username} \nPlease check that email should be from A to Z , 0 to 9 without dot and password between 0 to 9 characters";
            }
        );
    }

    public void SignIn(string username, string password){
        PlayFabClientAPI.LoginWithPlayFab( new LoginWithPlayFabRequest(){
            Username = username,
            Password = password
        },
        result => {
                Debug.Log($"Successful Account Login for {username}");
                currentLevel = PlayerPrefs.GetInt("level");
                Debug.Log(currentLevel);
                if(currentLevel == 1){
                    SceneManager.LoadScene("Application Form");
                }
                if(currentLevel == 2){
                    SceneManager.LoadScene("Cheque");
                }
                if(currentLevel == 0){
                    SceneManager.LoadScene("Start");
                }
                else{
                    Debug.Log("Error");
                    // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }
                
            },
        error => {
                panel.SetActive(true);
                errorType.text = $"Unsuccessful Account Login for {username}\n\nPlease check the credentials and try again";
            }
        );
    }

    public void onBackButtonClick(){
        SceneManager.LoadScene("Login");
    }

    public void onSignInButtonClick(){
        counter++;
        // Debug.Log(counter);
    }
}
