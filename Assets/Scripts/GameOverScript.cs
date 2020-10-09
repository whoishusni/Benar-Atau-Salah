using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    public Text scoreText;
    public Text highScoreText;
    public Text labelForNewHighScore;
    void Start()
    {
        int score = SetupScore.score;
        scoreText.text = score.ToString();
        highScoreText.text = PlayerPrefs.GetInt("highScore", 0).ToString();

        if (score > PlayerPrefs.GetInt("highScore", 0))
        {
            PlayerPrefs.SetInt("highScore", score);
            highScoreText.text = score.ToString();
            labelForNewHighScore.gameObject.SetActive(true);
        }
        else {
            labelForNewHighScore.gameObject.SetActive(false);
        }

        //Banner show

        AdsManagerr ads = new AdsManagerr();

        ads.RequestBanner();
    }
    
}
