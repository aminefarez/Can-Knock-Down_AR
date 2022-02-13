using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    public Button[] lvlButtons;


    public void LoadLevel(int levelIndex)
    {
        // Load the selected Level
        SceneManager.LoadScene(levelIndex);
    }

    public void QuitApp()
    {
        // Exit the Game
        Application.Quit();
    }

}
