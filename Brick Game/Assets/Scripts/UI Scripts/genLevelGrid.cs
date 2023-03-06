using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class genLevelGrid : MonoBehaviour
{
    int x = -200;
    int y = 160;
    public GameObject levelSelect;
        
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < SceneManager.sceneCountInBuildSettings - 1; i++)
        { 
                genButton(x,y,i);
                x += 75;
        }

       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void genButton(int x, int y, int currentButton)
    {
        Debug.Log(gameObject.name);
         Instantiate(levelSelect,new Vector3(20,20,20),Quaternion.identity,gameObject.transform);
        
    }
}
