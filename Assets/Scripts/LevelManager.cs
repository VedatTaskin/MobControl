using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    int currentScene;

    private void Start()
    {
        Time.timeScale = 1f;
        currentScene = SceneManager.GetActiveScene().buildIndex;
        UpdateLevelText();       
    }

    void UpdateLevelText()
    {
        UIController.Instance.SetLevelText(currentScene);
    }

    public void Restart()
    {
        SceneManager.LoadScene(currentScene);
    }


    //There is no next level so the level repeat itself :)
    public void NextLevel()
    {
        SceneManager.LoadScene(currentScene);
    }


}
