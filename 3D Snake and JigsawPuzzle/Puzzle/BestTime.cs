using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestTime : MonoBehaviour {
    public static string HIGH_SCORE_KEY = "kr.ac.deu.game.chang.2017.puzzle.highscore";
    public int BestTimeReco = 10000;
    public static bool newHighScore = false;

    void Awake()
    {
        newHighScore = false;
        if (PlayerPrefs.HasKey(HIGH_SCORE_KEY))
        {
            BestTimeReco = PlayerPrefs.GetInt(HIGH_SCORE_KEY);
        }
        PlayerPrefs.SetInt(HIGH_SCORE_KEY, BestTimeReco);

        Text gt = this.GetComponent<Text>();
        gt.text = "Best Time : " + BestTimeReco;
    }

    public static void BestTimeRecord(int Score)
    {
        if (Score < PlayerPrefs.GetInt(HIGH_SCORE_KEY))
        {
            newHighScore = true;
            PlayerPrefs.SetInt(HIGH_SCORE_KEY, Score);
        }
    }
}
