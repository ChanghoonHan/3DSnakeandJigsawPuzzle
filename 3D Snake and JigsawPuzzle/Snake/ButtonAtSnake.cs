using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAtSnake : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GoToSnake()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("_Snake_Start");
    }

    public void GoToHome()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("_Home");
    }
}
