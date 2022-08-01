using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnSignInClick : MonoBehaviour
{
    public GameObject options;
    public Button SignIn;
    public GameObject signIn;


    void Start () {
		Button btn = SignIn.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick(){
		Debug.Log ("You have clicked the button!");
        signIn.SetActive(true);
        options.SetActive(false);
	}
}
