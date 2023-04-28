using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuTitleText : MonoBehaviour
{
    public string winLossString;
    // Start is called before the first frame update
    void Start()
    {
        Text losetext = GetComponent<Text>();

        losetext.text = "Level " + SceneManager.GetActiveScene().name + " " + winLossString;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
