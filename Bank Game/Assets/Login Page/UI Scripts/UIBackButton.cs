using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIBackButton : MonoBehaviour
{
    public GameObject options;
    // public GameObject content;
    public Canvas signIn;
    public Button SignIn;
    public Button CreateAccount;
    
    // void onMouseDowm(){
    //     // signIn.SetActive(false);
    //     // content.SetActive(true);
    //     // options.SetActive(true);
    //     EventSystem.current.SetSelectedGameObject(options);
    // }

    public Button yourButton;

	void Start () {
		Button btn = yourButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick(){
		Debug.Log ("You have clicked the button!");
        options.SetActive(true);
	}
}
