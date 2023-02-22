using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Timers;


public class ScoreCalculator : MonoBehaviour
{
    private float gameTimer = 0f;
    private float score;
    public Text scoreText;

    private void Update()
    {
        gameTimer += Time.deltaTime;
        score = gameTimer;
        if (score <= 0)
        {
            score = 0;
        }
        scoreText.text = score.ToString();
    }


}
