using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameoverText : MonoBehaviour {
    public static GameoverText S;

    private void Awake()
    {
        S = this;
        this.gameObject.SetActive(false);
    }
    
    public void GameOverView()
    {
        this.gameObject.SetActive(true);
    }
}
