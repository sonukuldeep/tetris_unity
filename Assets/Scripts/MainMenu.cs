using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject MainCanvas;
    [SerializeField] GameObject ControlsUI;
    [SerializeField] GameObject ScoreBoardUI;
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void GoToControls()
    {
        ControlsUI.SetActive(true);
        MainCanvas.SetActive(false);
    }

    public void GoToLeaderboard()
    {
        ScoreBoardUI.SetActive(true);
        MainCanvas.SetActive(false);
    }

    public void GoToMenu()
    {
        ControlsUI.SetActive(false);
        ScoreBoardUI.SetActive(false);
        MainCanvas.SetActive(true);
    }
}
