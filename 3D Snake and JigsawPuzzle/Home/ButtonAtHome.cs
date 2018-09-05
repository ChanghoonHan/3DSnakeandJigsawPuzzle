using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAtHome : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GoToPuzzle()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("_Puzzle_Start");
    }

    public void GoToSnake()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("_Snake_Start");
    }
}
