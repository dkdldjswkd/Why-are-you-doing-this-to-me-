using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class LineScript : MonoBehaviour
{
    [SerializeField] GameObject tmp;

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
    //LineRenderer.positionCount -> 라인렌더러 좌표의 최대 인덱스 갯수
    //LineRenderer.GetPosition(i).x -> i번째 인덱스의 x좌표값

    //다 그려진 선인지 판단
    public bool complete = false;

    private void Start()
    {
        lr = GetComponent<LineRenderer>();

        // 템플릿 초기화
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                Template[i, j] = 0;
            }
        }
    }


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
        for (int i = 0; i < lr.positionCount; i++)
        {
            float tmpX = lr.GetPosition(i).x - Location_Left;
            float tmpY = lr.GetPosition(i).y - Location_Down;

            int indexX = (int)(tmpX / DeltaX);
            if (indexX >= 10) indexX = 9;
            else if(indexX < 0) indexX = 0;

            int indexY = (int)(tmpY / DeltaY);
            if (indexY >= 10) indexY = 9;
            if (indexY < 0) indexY = 0;

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

    ////보간
    //public void Interpolation()
    //{
    //    List<string> DirectionList = new List<string>(); // 직선의 방향 리스트, DirectionList + 1 -> 점의 개수
    //    List<string> DirectionList_after = new List<string>(); //보간된 직선의 방향 리스트
    //    List<Vector3> points = new List<Vector3>(); //보간된 직선의 포인트를 담는 리스트

    //    //직선(보간전)의 방향리스트 생성 
    //    for (int i = 0; i < lr.positionCount-1; i++)
    //    {
    //        double p1x = lr.GetPosition(i).x;
    //        double p1y = lr.GetPosition(i).y;

    //        double p2x = lr.GetPosition(i + 1).x;
    //        double p2y = lr.GetPosition(i + 1).y;

    //        double deltaX = p2x - p1x;
    //        double deltaY = p2y - p1y;
    //        double inc = deltaY / deltaX; // 기울기 -> y증가량 / x증가량

    //        double radians = Math.Atan(inc);
    //        double angle = radians * (180 / Math.PI);

    //             if (deltaX > 0 && deltaY > 0) { angle += 0; } // 1사분면
    //        else if (deltaX < 0 && deltaY > 0) { angle += 180; } // 2사분면
    //        else if (deltaX < 0 && deltaY < 0) { angle += 180; } // 3사분면
    //        else if (deltaX > 0 && deltaY < 0) { angle += 360; } // 4사분면
    //        //1사분면 각 -> angle
    //        //2사분면 각 -> 180 + angle
    //        //3사분면 각 -> 180 + angle
    //        //4사분면 각 -> 360 + angle
    //        if (angle < 0) angle += 360;
    //        // 상->하 직선의 경우 -90도가 됨
    //        else if (angle == 0) { if (deltaX < 0) angle = 180; }
    //        // 좌->우, 우->좌 두 직선의 경우 0도가됨(좌->우는 상관없지만 우->좌가 문제)

    //        string direction;
    //        if (angle > 22.5f && 67.5f > angle) direction = "우상";
    //        else if (angle > 67.5f && 112.5f > angle) direction = "상";
    //        else if (angle > 112.5f && 157.5f > angle) direction = "좌상";
    //        else if (angle > 157.5f && 202.5f > angle) direction = "좌";
    //        else if (angle > 202.5 && 247.5f > angle) direction = "좌하";
    //        else if (angle > 247.5f && 292.5f > angle) direction = "하";
    //        else if (angle > 292.5f && 337.5f > angle) direction = "우하";
    //        else direction = "우";

    //        DirectionList.Add(direction);

    //        //print("p" + i.ToString() + " -> " + "p" + (i + 1).ToString() + "의 각도는 : " + angle);
    //        //print("p" + i.ToString() + " -> " + "p" + (i + 1).ToString() + "는 " + direction + " 화살표");
    //    }

    //    //보간될 새로운 라인의 포인트를 담음
    //    points.Add(lr.GetPosition(0));

    //    int Deviate = 0; // 어긋난 점의 인덱스
    //    //1차 보간 (어긋나지 않은 직선들을 한 직선으로 통일시킴)
    //    for (int i = 0; i < DirectionList.Count-1; i++)
    //    {
    //        Deviate++;

    //        string tmp1 = DirectionList[i]; // ex. p0 -> p1 의 직선방향
    //        string tmp2 = DirectionList[i + 1]; // ex. p1 -> p2 의 직선방향
    //        if (tmp1 != tmp2 || i == DirectionList.Count-2) // 직선의 방향이 어긋나면 또는 마지막 인덱스라면
    //        {
    //            points.Add(lr.GetPosition(Deviate)); //기본형 라인의 어긋난 좌표를 추가
    //        }
    //    }

    //    //1차 보간된 라인의 길이 설정
    //    float lineLangth = 0;
    //    for (int i = 0; i < points.Count-1; i++)
    //    {
    //        lineLangth += Vector3.Distance(points[i], points[i + 1]);
    //    }
    //    //print("라인의 총 길이 " + lineLangth);

    //    //제외 기준 길이 설정 (총길이 / 직선의개수 * 2)
    //    float deadline = lineLangth / ( (points.Count-1) * 2);
    //    //print("제외 조건 " + deadline);


    //    //2차 보간 (짧은 직선은 제외시킴)
    //    for (int i = 0; ; i++)
    //    {
    //        //현재 인덱스의 직선이 짧다면 인덱스에서 제외함
    //        if (Vector3.Distance(points[i], points[i + 1]) < deadline)
    //        {
    //            points.RemoveAt(i + 1);
    //            i = 0;
    //            continue;
    //        }

    //        if (i == points.Count - 2)
    //            break;
    //    }


    //    //최종적으로 보간된 새로운 라인을 생성
    //    GameObject Line_Interpolation = Instantiate(Resources.Load("Prefab/Others/Line")) as GameObject;
    //    LineRenderer lr_Interpolation = Line_Interpolation.GetComponent<LineRenderer>();
    //    //보간된 라인의 최대 인덱스 초기화
    //    lr_Interpolation.positionCount = points.Count;

    //    //보간된 라인 좌표 초기화 -> 새로운(보간된) 직선의 생성
    //    for(int i=0; i < points.Count; i++)
    //    {
    //        lr_Interpolation.SetPosition(i, points[i]);
    //    }

    //    //보간된 직선의 방향 리스트 생성
    //    for (int i = 0; i < lr_Interpolation.positionCount - 1; i++)
    //    {
    //        double p1x = lr_Interpolation.GetPosition(i).x;
    //        double p1y = lr_Interpolation.GetPosition(i).y;

    //        double p2x = lr_Interpolation.GetPosition(i + 1).x;
    //        double p2y = lr_Interpolation.GetPosition(i + 1).y;

    //        double deltaX = p2x - p1x;
    //        double deltaY = p2y - p1y;
    //        double inc = deltaY / deltaX; // 기울기 -> y증가량 / x증가량

    //        double radians = Math.Atan(inc);
    //        double angle = radians * (180 / Math.PI);

    //        if (deltaX > 0 && deltaY > 0) { angle += 0; } // 1사분면
    //        else if (deltaX < 0 && deltaY > 0) { angle += 180; } // 2사분면
    //        else if (deltaX < 0 && deltaY < 0) { angle += 180; } // 3사분면
    //        else if (deltaX > 0 && deltaY < 0) { angle += 360; } // 4사분면
    //        //1사분면 각 -> angle
    //        //2사분면 각 -> 180 + angle
    //        //3사분면 각 -> 180 + angle
    //        //4사분면 각 -> 360 + angle
    //        if (angle < 0) angle += 360;
    //        // 상->하 직선의 경우 -90도가 됨
    //        else if (angle == 0) { if (deltaX < 0) angle = 180; }
    //        // 좌->우, 우->좌 두 직선의 경우 0도가됨(좌->우는 상관없지만 우->좌가 문제)

    //        string direction;
    //        if (angle > 22.5f && 67.5f > angle) direction = "우상";
    //        else if (angle > 67.5f && 112.5f > angle) direction = "상";
    //        else if (angle > 112.5f && 157.5f > angle) direction = "좌상";
    //        else if (angle > 157.5f && 202.5f > angle) direction = "좌";
    //        else if (angle > 202.5 && 247.5f > angle) direction = "좌하";
    //        else if (angle > 247.5f && 292.5f > angle) direction = "하";
    //        else if (angle > 292.5f && 337.5f > angle) direction = "우하";
    //        else direction = "우";

    //        DirectionList_after.Add(direction);
    //    }

    //    string InputedMagic = "";
    //    for (int i = 0; i < DirectionList_after.Count; i++)
    //    {
    //        InputedMagic += DirectionList_after[i];
    //        InputedMagic += " ";
    //    }

    //    //출력 테스트
    //    print(InputedMagic);

    //    Interpolation_joon.MagicChecking(InputedMagic);

    //    points.Clear();
    //}



}
