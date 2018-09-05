using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAtPuzzle : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    public void GoToPuzzle()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("_Puzzle_Start");
    }

    public void GoToHome()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("_Home");
    }
}
