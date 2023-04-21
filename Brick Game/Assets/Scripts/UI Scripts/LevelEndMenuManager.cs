using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEndMenuManager : MonoBehaviour
{
    Scene cScene;
    string nextScene;
    [SerializeField] LevelManagerScriptableObject levelManager;
    [SerializeField] GameObject Wintext;
    int numScene;
    // Start is called before the first frame update
    void Start()
    {
        cScene = SceneManager.GetActiveScene();
        nextScene = cScene.name;
        numScene = int.Parse(nextScene) + 1;
     
        nextScene = numScene.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Wintext.activeInHierarchy)
        {
            if (levelManager.currentStage < numScene)
            {
                levelManager.currentStage = numScene;
            }
        }
    }

    public void LoadScene(string tarScene)
    {
        

        SceneManager.LoadScene(tarScene);

    }
    public void LoadScene()
    {
        int buildIndex = SceneUtility.GetBuildIndexByScenePath(nextScene);
        
        if(buildIndex != -1)
        {
            SceneManager.LoadScene(nextScene);
        }
        else
        {

            SceneManager.LoadScene("Main_Menu");
        }

    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
