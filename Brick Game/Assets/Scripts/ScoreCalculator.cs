using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCalculator : MonoBehaviour
{
    private int score;
    public Text scoreText;

    private void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Block")
        {
            score += 10;
            scoreText.text = score.ToString(); 
        }
    }
}
