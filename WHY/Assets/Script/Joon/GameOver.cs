using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] GameObject Lord;
    [SerializeField] GameObject GameOverCanvas;
    [SerializeField] GameObject []OtherCanvas = new GameObject[3];
    // Start is called before the first frame update

    // Update is called once per frame

    private void Start()
    {
        GameOverCanvas.SetActive(false);
    }

    void Update()
    {
        if (Lord == null)
        {
            GameOverCanvas.SetActive(true);
            for(int i = 0; i < 3; ++i)
            {
                OtherCanvas[i].SetActive(false);
            }

            Time.timeScale = 0;
        }
         

    }

}

//대충짠 코드
