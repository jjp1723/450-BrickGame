using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Timers;


public class ScoreCalculator : MonoBehaviour
{
    private float gameTimer = 0f;
    private float score;
    private int AmountOfWallsHit;
    private int TimesThrown;
    private float collectiblesCollected = 0f;
    public Text scoreText;
    public Text thrownText;
    public Text collectibleText;
    public LaunchingBehavior script;
    

    private void Update()
    {
        gameTimer += Time.deltaTime;

        score = Mathf.Round(gameTimer *10f) *.1f;
        if (score <= 0)
        {
            score = 0;
        }
        scoreText.text = score.ToString();

        TimesThrown = script.TimesThrown;
        thrownText.text = TimesThrown.ToString();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Block")
        {
           
        }

        if (collision.gameObject.tag == "Collectible")
        {
            collectiblesCollected += 1f;
            Destroy(collision.gameObject);
            collectibleText.text = collectiblesCollected.ToString();
        }

    }


}
