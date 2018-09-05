using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour {
    public static HighScore S;
    public static string HIGH_SCORE_KEY = "kr.ac.deu.game.chang.2017.Snake.highscore";
    public int BestScore = 0;
    public static bool newHighScore = false;

    void Awake()
    {
        S = this;
        newHighScore = false;
        if (PlayerPrefs.HasKey(HIGH_SCORE_KEY))
        {
            BestScore = PlayerPrefs.GetInt(HIGH_SCORE_KEY);
        }
        PlayerPrefs.SetInt(HIGH_SCORE_KEY, BestScore);

        Text gt = this.GetComponent<Text>();
        gt.text = "Best Time : " + BestScore;
    }

    public void BestScoreRecord(int Score)
    {
        if (Score > PlayerPrefs.GetInt(HIGH_SCORE_KEY))
        {
            BestScore = Score;
            Text gt = this.GetComponent<Text>();
            gt.text = "Best Time : " + BestScore;
            newHighScore = true;
            PlayerPrefs.SetInt(HIGH_SCORE_KEY, BestScore);
        }
    }
}
