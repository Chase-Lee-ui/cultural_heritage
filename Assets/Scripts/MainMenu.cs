using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame() {
        SceneManager.LoadScene("Level_1", LoadSceneMode.Single);
    }
    public void HowToPlay() {
        SceneManager.LoadScene("How To Play", LoadSceneMode.Single);
    }
    public void QuitGame() {
        Application.Quit();
    }

    public void TitleScreen() {
        SceneManager.LoadScene("Title", LoadSceneMode.Single);
    }

    public void Credits() {
        SceneManager.LoadScene("Credits", LoadSceneMode.Single);
    }
}
