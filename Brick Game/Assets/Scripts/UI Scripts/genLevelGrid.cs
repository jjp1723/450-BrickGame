using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class genLevelGrid : MonoBehaviour
{
    int x = -8;
    int y = 4;
    public GameObject levelSelect;
    

    // Start is called before the first frame update
    void Start()
    {


        for (int i = 1; i < SceneManager.sceneCountInBuildSettings; i++)
        { 
                genButton(x,y,i);
                x += 2;
            if (x > 2)
            {
                x = -8;
                y -= 2;
            }
        }
    }

       
    

    // Update is called once per frame
    void Update()
    {
        
    }

    void genButton(int x, int y, int currentButton)
    {
        Debug.Log(gameObject.name);
        GameObject currentLevel = Instantiate(levelSelect,new Vector3(x,y,0),Quaternion.identity,gameObject.transform);
        currentLevel.GetComponent<LevelGridButtonPrefab>().sceneVal = currentButton;
    }
}
