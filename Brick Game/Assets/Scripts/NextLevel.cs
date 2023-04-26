using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class NextLevel : MonoBehaviour
{
    public LaunchingBehavior LaunchingBehavior;
    public GameObject menuText; 
    public GameObject gameText;
    public GameObject throwBlock;
    public GameObject line;
    public Text scoreValue;
    public Text throwValue;
    public Text scoreValueEnd;
    public GameObject winText;
    public GameObject loseText;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(SceneManager.GetActiveScene().name == "2");
        if (int.Parse(scoreValue.text) <= 0 && throwBlock.GetComponent<Rigidbody2D>().velocity == Vector2.zero && LaunchingBehavior.gameTimer >= .5f)
        {
            loseText.SetActive(true);
            menuText.SetActive(true);
            gameText.SetActive(false);
            throwBlock.SetActive(false);
            line.SetActive(false);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Goal")
        {
            scoreValueEnd.text += scoreValue.text;

            winText.SetActive(true);
            menuText.SetActive(true);
            gameText.SetActive(false);
            throwBlock.SetActive(false);
            line.SetActive(false);
        }
    }
}
