using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LineScript : MonoBehaviour
{
    //템플릿의 각 끝점의 좌표들
    public float Location_Up;
    public float Location_Down;
    public float Location_Left;
    public float Location_Right;

    //Vector2[,] Location = new Vector2[10, 10];
    public static int[,] Template = new int[10, 10];

    //가로, 세로 크기
    public float Size_X;
    public float Size_Y;

    //가로, 세로 1/10의 크기
    public float DeltaX;
    public float DeltaY;

    LineRenderer lr;

    //다 그려진 선인지 판단
    public bool complete = false;

    private void Start()
    {
        lr = GetComponent<LineRenderer>();

        // 템플릿 초기화
        for(int i=0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                Template[i, j] = 0;
            }
        }
    }

    //라인이 다 그려졌다면 멤버변수들을 초기화 && 템플릿 매칭
    public void SetInfomation()
    {
        //멤버변수 초기화
        if (complete)
        {
            Size_X = Location_Right - Location_Left;
            Size_Y = Location_Up - Location_Down;
            DeltaX = Size_X / 10f;
            DeltaY = Size_Y / 10f;

        }

        // 템플릿 매칭
        for(int i = 0; i < lr.positionCount; i++)
        {
            float tmpX = lr.GetPosition(i).x - Location_Left;
            float tmpY = lr.GetPosition(i).y - Location_Down;

            int indexX = (int)(tmpX / DeltaX);
            if (indexX >= 10) indexX = 9;
            int indexY = (int)(tmpY / DeltaY);
            if (indexY >= 10) indexY = 9;

            //print(indexY + ", " + indexX);

            Template[indexY, indexX]++;
        }

        //실제 이미지에 전달
        GameObject TemplateImage = GameObject.Find("TemplateImage");
        for (int i = 0; i < 10; i++)
        {
            Transform tmp = TemplateImage.transform.GetChild(i);
            for (int j = 0; j < 10; j++)
            {
                if (Template[i, j] != 0)
                    tmp.GetChild(j).GetComponent<Image>().color = new Color(0, 0, 0);
            }

        }
    }

    public static void TemplateClear()
    {
        //템플릿 초기화
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                Template[i, j] = 0;
            }
        }

        GameObject TemplateImage = GameObject.Find("TemplateImage");
        for (int i = 0; i < 10; i++)
        {
            Transform tmp = TemplateImage.transform.GetChild(i);
            for (int j = 0; j < 10; j++)
            {
                tmp.GetChild(j).GetComponent<Image>().color = new Color(1, 1, 1);
            }

        }
    }

}
