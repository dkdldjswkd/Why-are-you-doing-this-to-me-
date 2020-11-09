using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class SpawnerButton : MonoBehaviour
{
    public static bool[] ClickedButton = new bool[4];
    bool me = false; // 자신이 클릭되어있는지 판단하는 변수
    int myNumber; //몇번재 버튼인지
    string myName; //this의 이름
    Text ButtonText;
    float Second;

    private void Start()
    {
        Second = 0;
        //모든 스폰버튼 비활성화
        for (int i = 0; i < 4; ++i)
        {
            ClickedButton[i] = false;
        }

        myName = gameObject.name;
        myNumber = myName[myName.Length - 1] - 48;
        print(myName);
        print(myNumber);

        ButtonText = transform.GetChild(0).GetComponent<Text>();
    }

    private void Update()
    {
        // 비용이 많이 드는 처리 수정해야함, 버튼의 상태를 업데이트 해주는 함수
        if (ClickedButton[myNumber] == true)
        {
            ButtonText.text = "활성화";
            print("활성화");
        }
        else
        {
            ButtonText.text = "비 활성화";
            print("비 활성화");
        }
    }

    //스포너 버튼이 하나라도 활성화 되어있다면 참 아니라면 거짓
    public static bool ClickedCheck()
    {
        for (int i = 0; i < 4; ++i)
        {
            if (ClickedButton[i] == true)
            {
                return true;
            }
        }
        return false;


    }

    //현재 버튼들의 상태를 알려주는 임시함수
    public static void showbuttonsState()
    {
        //for (int i = 0; i < 4; ++i)
        //    Debug.Log(ClickedButton[i]);
        Debug.Log(ClickedButton[0] + ", "+ ClickedButton[1] + ", "+ ClickedButton[2] + ", "+ ClickedButton[3]);
    }

    // 눌려진 버튼이 몇번 버튼인지 반환함
    public static int whoClickedButton()
    {
        for (int i=0;i<4;i++)
        {
            if (ClickedButton[i] == true)
                return i;
        }

        //아무것도 눌려있지 않을경우 100을 반환함
        return 100;
    }

    static public void Off(int n)
    {

    }

    //---------------------------------------------------실질적으로 버튼이 눌렸을시 작동되는 함수들-----------------------------------------------
    public void Spawner0()
    {
        int tmp = 0;
        // 클릭된 버튼을 활성화 시키며 그 외 버튼은 비활성화
        if (ClickedButton[tmp] == false)
        {
            me = true;
            ClickedButton[tmp] = true;
            for (int i = 0; i < 4; ++i)
            {
                if (i == tmp)
                    continue;
                ClickedButton[i] = false;
            }
        }
        else // 활성화된 버튼을 비활성화
        {
            me = false;
            ClickedButton[tmp] = false;
        }

        if (ClickedButton[tmp] == true) me = true;
        ClickedCheck();
        showbuttonsState();
    }

    public void Spawner1()
    {
        int tmp = 1;
        // 클릭된 버튼을 활성화 시키며 그 외 버튼은 비활성화
        if (ClickedButton[tmp] == false)
        {
            ClickedButton[tmp] = true;
            for (int i = 0; i < 4; ++i)
            {
                if (i == tmp)
                    continue;
                ClickedButton[i] = false;
            }
        }
        else // 활성화된 버튼을 비활성화
        {
            ClickedButton[tmp] = false;
        }


        ClickedCheck();

        showbuttonsState();
    }

    public void Spawner2()
    {
        int tmp = 2;
        // 클릭된 버튼을 활성화 시키며 그 외 버튼은 비활성화
        if (ClickedButton[tmp] == false)
        {
            ClickedButton[tmp] = true;
            for (int i = 0; i < 4; ++i)
            {
                if (i == tmp)
                    continue;
                ClickedButton[i] = false;
            }
        }
        else // 활성화된 버튼을 비활성화
        {
            ClickedButton[tmp] = false;
        }

        ClickedCheck();

        showbuttonsState();
    }

    public void Spawner3()
    {
        int tmp = 3;
        // 클릭된 버튼을 활성화 시키며 그 외 버튼은 비활성화
        if (ClickedButton[tmp] == false)
        {
            ClickedButton[tmp] = true;
            for (int i = 0; i < 4; ++i)
            {
                if (i == tmp)
                    continue;
                ClickedButton[i] = false;
            }
        }
        else // 활성화된 버튼을 비활성화
        {
            ClickedButton[tmp] = false;
        }

        ClickedCheck();

        showbuttonsState();
    }


}
