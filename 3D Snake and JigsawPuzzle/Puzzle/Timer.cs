using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    //public static int time = 0;
    public static int time = 0;

	// Use this for initialization
	void Start () {
        InvokeRepeating("StartGameFunc", 0f, 0.01f);
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    void StartGameFunc()
    {
        if(SmallCube.StartGame == true)
        {
            InvokeRepeating("TimeCal", 0f, 1f);
            CancelInvoke("StartGameFunc");
        }
    }

    void TimeCal()
    {
        if (!BigCube.isGameClear())
        {
            time += 1;
        }
        else
        {
            BestTime.BestTimeRecord(time);
            CancelInvoke("TimeCal");
            ClearText.S.ClearGame();
        }
        this.gameObject.GetComponent<Text>().text = "Time : " + time.ToString();
    }
    
}
