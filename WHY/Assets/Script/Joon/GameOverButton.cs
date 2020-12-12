using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOverButton : MonoBehaviour
{
    public void GoMainScreen()
    {
        Time.timeScale = 1.0f; // 시간 멈춤 원상복구
        SceneManager.LoadScene("MainMenu");
        
    }

    public void Exit()
    {
        Application.Quit();
    }
}
