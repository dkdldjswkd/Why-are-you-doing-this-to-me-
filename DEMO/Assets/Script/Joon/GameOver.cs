using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] GameObject Lord;
    [SerializeField] GameObject GameOverCanvas;
    [SerializeField] GameObject[] OtherCanvas = new GameObject[3];
    public static int HowEnd;


    private void Start()
    {
        GameOverCanvas.SetActive(false);
    }

    void Update()
    {
 
        if(Lord == null)
        {
            End(2);
        }

    }

    public void End(int n)
    {
        // 1이면 승리, 2면 패배
        HowEnd = n;

        if (GameOverCanvas.activeSelf == false)
        {

                GameOverCanvas.SetActive(true);
                for (int i = 0; i < 3; ++i)
                {
                    OtherCanvas[i].SetActive(false);
                }

                Time.timeScale = 0;

            if (GameOver.HowEnd == 1)
            {
                GameObject.Find("GameOver_Canvas").transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
                GameObject.Find("GameOver_Canvas").transform.GetChild(0).GetChild(1).gameObject.SetActive(false);

            }
            else
            {
                GameObject.Find("GameOver_Canvas").transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
                GameObject.Find("GameOver_Canvas").transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
            }


        }
    }

}

//대충짠 코드
