using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;


public class SpawnerButton : MonoBehaviour
{
    public static bool[] ClickedButton = new bool[4]; //4개의 버튼의 활성화/비활성화를 판단.
    public static GameObject[] MyMinion = new GameObject[4]; //4개의 버튼이 소유하고있는 미니언들을 나타냄.
    public static Sprite[] MyMinionSprite = new Sprite[4]; // 4개의 버튼의 미니언 이미지

    public static int ActButton; // 100이라면 아무 버튼도 눌려있지 않음

    int myNumber; //this가 몇번째 버튼인지
    string myName; //this의 이름
    UnityEngine.UI.Image myImage; // 자신 이미지
    Text ButtonText; //this의 버튼 텍스트

    public static int RandomX, RandomY; // 랜덤값부여 변수

    private void Start()
    {
        myImage = GetComponent<UnityEngine.UI.Image>();

        ActButton = 100; //비활성화

        //모든 스폰버튼 비활성화
        for (int i = 0; i < 4; ++i)
        {
            ClickedButton[i] = false;
        }

        DefanceManager.WatingMinion = null;

        myName = gameObject.name;
        myNumber = myName[myName.Length - 1] - 48;

        ButtonText = transform.GetChild(0).GetComponent<Text>();

        roll();
    }

    public void roll()
    {
        while (true)
        {
            RandomX = Random.Range(0, DefanceManager.Level); RandomY = Random.Range(0, 3);
            if (DefanceManager.MinionActCheck[RandomX, RandomY] != 3)
            {
                break;
            }
        }
        //자신버튼의 미니언으로 지정하고 활성화 시킴
        MyMinion[myNumber] = DefanceManager.Minions[RandomX, RandomY];
        MyMinionSprite[myNumber] = DefanceManager.MinionsSprite[RandomX, RandomY];
        myImage.sprite = DefanceManager.MinionsSprite[RandomX, RandomY];
        DefanceManager.MinionActCheck[RandomX, RandomY] = 1;
    }

    private void Update()
    {
        // 비용이 많이 드는 처리 수정해야함, 버튼의 상태를 업데이트 해주는 함수
        myImage.sprite = MyMinionSprite[myNumber];
        //ButtonText.text = MyMinion[myNumber].name;
    }

    //활성화 표시
    void ifAct()
    {
        if (ClickedButton[myNumber])
        {

        }
    }

    //현재 버튼들의 상태를 알려주는 임시함수
    public static void showbuttonsState()
    {
        //for (int i = 0; i < 4; ++i)
        //    Debug.Log(ClickedButton[i]);
        Debug.Log(ClickedButton[0] + ", " + ClickedButton[1] + ", " + ClickedButton[2] + ", " + ClickedButton[3]);
    }

    //---------------------------------------------------실질적으로 버튼이 눌렸을시 작동되는 함수-----------------------------------------------
    public void Sample()
    {
        // 클릭된 버튼을 활성화 시키며 그 외 버튼은 비활성화
        if (ClickedButton[myNumber] == false)
        {
            ClickedButton[myNumber] = true;
            ActButton = myNumber;
            for (int i = 0; i < 4; ++i)
            {
                if (i == myNumber)
                    continue;
                ClickedButton[i] = false;
            }
        }
        else // 활성화된 버튼을 비활성화
        {
            ActButton = 100;
            ClickedButton[myNumber] = false;
            DefanceManager.WatingMinion = null;
        }

        DefanceManager.WatingMinion = MyMinion[myNumber];

        print(ActButton);
    }

}

