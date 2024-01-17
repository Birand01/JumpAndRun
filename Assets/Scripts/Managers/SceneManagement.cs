using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    private int sceneIndex = 0;

    private void OnEnable()
    {
        RestartLevelButton.OnLevelStartButton += GoToMainMenu;
    }
    private void OnDisable()
    {
        RestartLevelButton.OnLevelStartButton -= GoToMainMenu;

    }
    private void LevelCounterEvent(TMP_Text tMP_Text)
    {
        tMP_Text.text = "LEVEL " + SceneManager.GetActiveScene().buildIndex.ToString();

    }
    private void GoToMainMenu()
    {

        SceneManager.LoadScene(0);
    }
    private void RestartLevel()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIndex, LoadSceneMode.Single);
    }

}
