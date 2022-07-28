using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISignIn : MonoBehaviour
{
    string username , password;

    public void UpdateUsername (string _username){
        username = _username;
    }
    public void UpdatePassword (string _password){
        password = _password;
    }
    public void SignIn(){
        UserAccountManager.Instance.SignIn(username,password);
    }
}
