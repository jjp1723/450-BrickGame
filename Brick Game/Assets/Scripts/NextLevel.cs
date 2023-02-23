using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NextLevel : MonoBehaviour
{
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
            if(SceneManager.GetActiveScene().name=="2")
            {
                SceneManager.LoadScene("Brick_Game_MVI", LoadSceneMode.Single);
            }
            else
            {
                SceneManager.LoadScene("2", LoadSceneMode.Single);
            }
            
        }
    }
}
