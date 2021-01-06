using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scene : MonoBehaviour
{
    public void SceneClickListener(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }

    public void exitbutton()
    {
        Application.Quit();
    }
 
}
