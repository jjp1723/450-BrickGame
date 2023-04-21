using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject gridObj;
    public GameObject titleObj;
    public GameObject tutObj;
    public LevelManagerScriptableObject levelManager;
    bool toggleGrid = false;
    bool toggleTut = false;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("j"))
        {
            levelManager.Reset();
        }
    }
    public void LoadLevel(string tarScene)
    {
        SceneManager.LoadScene(tarScene);
    }
    public void ToggleGridView()
    {
        toggleGrid = !toggleGrid;
        gridObj.SetActive(toggleGrid);
        titleObj.SetActive(!toggleGrid);
        
    }


    public void ToggleTutorialView()
    {
        toggleTut = !toggleTut;
        tutObj.SetActive(toggleTut);
        titleObj.SetActive(!toggleTut);

    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
