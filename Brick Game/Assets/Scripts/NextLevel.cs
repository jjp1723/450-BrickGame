using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class NextLevel : MonoBehaviour
{
    public GameObject menuText; 
    public GameObject gameText;
    public GameObject throwBlock;
    public GameObject line;
    public Text scoreValue;
    public Text throwValue;
    public Text scoreValueEnd;
    public Text throwValueEnd;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(SceneManager.GetActiveScene().name == "2");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Goal")
        {
            scoreValueEnd.text += scoreValue.text;
            throwValueEnd.text += throwValue.text;
            menuText.SetActive(true);
            gameText.SetActive(false);
            throwBlock.SetActive(false);
            line.SetActive(false);
        }
    }
}
