using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LevelGridButtonPrefab : MonoBehaviour
{
    public Button thisButton;
    public Text labelText;
    public int sceneVal = 0;
    // Start is called before the first frame update
    void Start()
    {
        labelText.text += sceneVal.ToString();
        thisButton.onClick.AddListener(SceneSelect);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    void SceneSelect()
    {
       
        SceneManager.LoadScene(sceneVal);
    }
}
