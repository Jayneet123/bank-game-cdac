using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISignIn : MonoBehaviour
{
    string username , password;
    public static UISignIn Instance1;

    void Awake(){
        Instance1 = this;
    }

    public void UpdateUsername (string _username){
        username = _username;
    }
    public void UpdatePassword (string _password){
        password = _password;
    }

    public void SignIn(){
        if (UserAccountManager.Instance.counter == 2){
            UserAccountManager.Instance.errorType.text = "Here's a hint.\nTry the credentials.\nUsername:Bank123\nPassword:Bank123";
        }
        UserAccountManager.Instance.SignIn(username,password);
    }
}
