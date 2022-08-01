using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UserAccountManager : MonoBehaviour
{
    public Canvas options;
    public Canvas signIn;
    public Canvas createAccount;
    public Button signInButton;
    public static UserAccountManager Instance;

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
                Debug.Log($"Successful Account Creation for {username} and {emailAddress}");
                // SignIn(username,password);
                createAccount.enabled = false;
                signIn.enabled = true;
                // UISignIn.Instance1.UpdateUsername(username);
                // UISignIn.Instance1.UpdatePassword(password);
                // UISignIn.Instance1.SignIn();
            },
            error => {
                Debug.Log($"Unsuccessful Account Creation for {username} and {emailAddress}\n {error.GenerateErrorReport()}");
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
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            },
        error => {
                Debug.Log($"Unsuccessful Account Login for {username}\n {error.GenerateErrorReport()}");
            }
        );
    }
}
