using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "LevelManager", menuName = "ScriptableObjects/LevelManager", order = 1)]
public class LevelManagerScriptableObject : ScriptableObject
{
    public int currentStage = 1;
    public bool[] levelStarArray;


    private void OnEnable()
    {
        levelStarArray = new bool[SceneManager.sceneCountInBuildSettings];
    }
    public void Reset()
    {
        currentStage = 1;
        levelStarArray = new bool[SceneManager.sceneCountInBuildSettings];
    }
}
