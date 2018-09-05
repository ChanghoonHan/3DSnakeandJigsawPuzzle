using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearText : MonoBehaviour {
    public static ClearText S;

    private void Awake()
    {
        S = this;
        this.gameObject.SetActive(false);
    }

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ClearGame()
    {
        this.gameObject.SetActive(true);
    }
}
