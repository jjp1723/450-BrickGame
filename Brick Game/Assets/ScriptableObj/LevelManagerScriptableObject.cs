using UnityEngine;

[CreateAssetMenu(fileName = "LevelManager", menuName = "ScriptableObjects/LevelManager", order = 1)]
public class LevelManagerScriptableObject : ScriptableObject
{
    public int currentStage = 1;


    public void Reset()
    {
        currentStage = 1;
    }
}
