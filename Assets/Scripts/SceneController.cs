using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    

    public void ToLoadingScene() { 
        SceneManager.LoadScene("LoadingScene");
    }
    public void ToMainMenu() {
        SceneManager.LoadScene("Menu");
    }
    public void ToExitGame() {
        Application.Quit();
    }
}
