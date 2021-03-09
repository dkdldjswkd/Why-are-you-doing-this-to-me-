using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Interpolation_joon : MonoBehaviour
{

    //마법 문자 딕셔너리
    public static Dictionary<string, string> Magics = new Dictionary<string, string>() {
        {"좌하 우 좌하 ", "번개"}, // ex. '좌하->우->좌하'의 그림은 '번개'마법을 사용함

        {"우 하 ", "ㄱ"},

        {"하 우 ", "ㄴ"},

        {"좌 하 우 ", "ㄷ" },

        {"좌하 하 우 우상 상 좌 ", "반시계 원"},
        {"좌하 하 우 우상 상 좌상 ", "반시계 원"},
        {"좌하 우하 우 우상 좌상 좌 ", "반시계 원"},
        {"좌하 하 우하 우 우상 상 좌 ", "반시계 원" },
        {"좌하 하 우하 우 우상 상 좌상 ", "반시계 원" },
        {"좌하 하 우하 우 우상 좌상 좌 ", "반시계 원" },
        {"좌하 우하 우 우상 상 좌상 좌 ", "반시계 원" },
        {"좌하 하 우하 우 우상 상 좌상 좌 ", "반시계 원"},
        {"좌 좌하 하 우하 우 우상 상 좌상 좌 ", "반시계 원" },
        {"좌하 하 우하 우 우상 상 좌상 좌 좌상 ", "반시계 원"},

        {"하 우상 좌 우하 좌상 ", "별"},
        {"좌하 우 좌 우하 상 ", "별"},
        {"좌하 우상 좌 하 상 ", "별"},
        {"하 우상 좌 우하 상 ", "별"},
        {"좌하 우상 좌 우하 상 ", "별"},
        {"좌하 우상 좌 우하 좌상 ", "별"},
        {"하 우상 좌 우하 상 좌상 ", "별"},
        {"좌하 우상 우 좌 우하 상  ", "별"},
        {"좌하 우상 좌 우하 좌상 상 ", "별"},
        {"좌하 하 우상 좌 우하 좌상 ", "별"},
        {"좌하 우 좌 우하 우하 상 좌상 ", "별"},
        {"하 우상 우상 우 좌 우하 우하 좌상 ", "별"},
        {"좌하 우상 우 우상 좌 우하 우 좌상 상 ", "별" },
        {"좌하 하 좌하 우 우 우상 우 우상 좌 우하 우하 상 좌상 ", "별"},

    };

    //Dictionary[Key]로 Value를 취득할 수 있다.
    public static string MagicChecking(string inputed)
    {
        string whatMagic;
        if (Magics.TryGetValue(inputed, out whatMagic))
        {
            //print(whatMagic);
            return whatMagic;
        }
        else
        {
            //print("일치하는 마법이 없습니다.");
            return "Null";
        }
            
    }


    //역보간
    public static List<Vector3> Interpolation(List<Vector3> points)
    {
        //---------------------------------------------------변수 생성----------------------------------------------------------
        //List<string> DirectionList_after = new List<string>(); //역보간 방향리스트
        List<Vector3> points_after = new List<Vector3>(); //역보간 포인트 리스트

        //--------------------------------------1차 역보간(버전1)(같은방향의 직선들을 하나의 직선으로 만듬)------------------------------
        //points_after = points; // 역보간을 진행할 포인트 리스트(points_after)에 역보간전 포인트 리스트(points)를 담음
        //for (int i = 1; i < points_after.Count - 1; i++)
        //{
        //    string tmp1 = WhatDirection(points_after[i - 1], points_after[i]); // ex. p0 -> p1 의 직선방향 (ex. 우상)
        //    string tmp2 = WhatDirection(points_after[i], points_after[i + 1]); // ex. p1 -> p2 의 직선방향 (ex. 상)

        //    if (tmp1 == tmp2)
        //    {
        //        points_after.RemoveAt(i);
        //        i--;
        //    }
        //}

        //---------------------------1차 역보간(버전2)(곡률이 45도를 넘지 않는다면 하나의 직선으로 만듬)-----------------------------
        points_after = Interpolation_Inflection(points);

        //---------------------------------------------------2차 역보간 세팅-------------------------------------------------------
        float lineLangth = 0; // 1차 역보간된 그림의 길이를 담는 변수
        for (int i = 0; i < points_after.Count - 1; i++) // 1차 역보간된 그림의 길이를 변수에 담는 반복문
        {
            lineLangth += Vector3.Distance(points_after[i], points_after[i + 1]);
        }

        //제외 기준 길이 설정 (총길이 / 직선의개수 * 2)
        float deadline = lineLangth / ((points_after.Count - 1) * 2);

        //---------------------------------------------2차 역보간(짧은 직선은 삭제함)---------------------------------------------
        if (points_after.Count > 1)
        {
            for (int i = 0; ; i++)
            {
                //현재 인덱스의 직선이 짧다면 인덱스에서 제외함
                if (Vector3.Distance(points_after[i], points_after[i + 1]) < deadline)
                {
                    points_after.RemoveAt(i + 1);
                    i = 0;
                    continue;
                }

                if (i == points_after.Count - 2)
                    break;
            }
        }

        //----------------------------------------3차 역보간(같은방향의 직선을 하나의 직선으로 역보간함)------------------------------------------
        for (int i = 1; i < points_after.Count - 1; i++)
        {
            string tmp1 = WhatDirection(points_after[i - 1], points_after[i]); // ex. p0 -> p1 의 직선방향 (ex. 우상)
            string tmp2 = WhatDirection(points_after[i], points_after[i + 1]); // ex. p1 -> p2 의 직선방향 (ex. 상)

            if (tmp1 == tmp2)
            {
                points_after.RemoveAt(i);
                i--;
            }
        }

        ////---------------------------------------------4차 역보간(1차 역보간 버전2와 같은작업)---------------------------------------------
        //List<Vector3> tmpPointList = new List<Vector3>(); //역보간 포인트 리스트
        //tmpPointList = Interpolation_Inflection(points_after); //4차 역보간 (곡률의 임계값을 넘기지 않는다면 하나의 직선으로 판단)
        //points_after.Clear();
        //points_after = tmpPointList;


        ////-----------------------------------------------역보간된 직선의 방향 리스트 생성------------------------------------------
        //for (int i = 0; i < points_after.Count - 1; i++)
        //{
        //    DirectionList_after.Add(WhatDirection(points_after[i], points_after[i + 1]));
        //}


        ////-----------------------------역보간 된 직선의 방향리스트를 하나의 문자열로 만듬(ex. 좌상 하 좌 )------------------------
        //string InputedMagic = "";
        //for (int i = 0; i < DirectionList_after.Count; i++)
        //{
        //    InputedMagic += DirectionList_after[i];
        //    InputedMagic += " ";
        //}


        //------------------------------------------------------곡률 보정-------------------------------------------------------



        ////출력 테스트
        //print(InputedMagic);

        //MagicChecking(InputedMagic);

        return points_after;
    }

    //변곡률이 45도를 넘지 않는다면 하나의 직선으로 처리함
    public static List<Vector3> Interpolation_Inflection(List<Vector3> points)
    {
        // 변곡점이 없는 문자라면 역보간처리하지 않음 (ex.상, 하, 좌상 등의 직선 문자)
        if (points.Count < 2) { 
            print("변곡점이 없으므로 역보간하지 않음");
            return points; 
        }

        List<Vector3> points_after = new List<Vector3>(); //역보간 포인트 리스트

        List<int> newIndex = new List<int>(); //points의 인덱스 중 유의미한 인덱스만 거름
        newIndex.Add(0);

        int StartPoint = 0;
        for (int i = 2; i < points.Count; i++)
        {
            if (i - StartPoint < 2) continue;

            double TotalCurveAngle = 0;
            for (int j = StartPoint; j <= i - 2; j++)
            {
                //내각 구하기 (변곡률을 구하기 위해 내각을 구함)
                double tmp1 = Slope(points[j + 1], points[j]);
                double tmp2 = Slope(points[j + 1], points[j+2]);
                double inAngle = tmp1 - tmp2;
                if (inAngle < 0) inAngle *= -1;
                if (inAngle > 180) inAngle = 360 - inAngle;
                //변곡률 구하기
                double CurveAngle = 180 - inAngle;
                double slope1 = Slope(points[j], points[j + 1]); // 첫번째 직선의 기울기
                double slope2 = Slope(points[j + 1], points[j + 2]); // 두번째 직선의 기울기
                //곡률이 양수인지 음수인지 구하는 과정
                if (slope1 + CurveAngle > 360) slope1 = slope1 + CurveAngle - 360;
                else slope1 += CurveAngle;
                if (Math.Abs(slope2 - slope1) < 1) CurveAngle *= 1;
                else CurveAngle *= -1;


                TotalCurveAngle += CurveAngle;
                //if(i-2 == j) print((StartPoint + 1).ToString() + "번 직선부터 " + (i).ToString() + "번 직선까지의 변곡률 : " + TotalCurveAngle); // 디버그 코드
                if (Math.Abs( TotalCurveAngle ) > 45.0) // 곡률의 절댓값이 45도 이상이라면 변곡점으로 판단
                {
                    //print((i - 1).ToString() + "번 인덱스는 변곡점"); //디버그 코드
                    newIndex.Add(i - 1);
                    StartPoint = i - 1;
                    break;
                }
            }

            //points의 마지막 인덱스이자 반목문의 마지막 && 마지막 좌표가 newIndex에 원소가 아니라면
            if(i == points.Count-1 && newIndex[newIndex.Count-1] != i)
            {
                //print(i.ToString() + "번 인덱스는 마지막점"); //디버그 코드
                newIndex.Add(i);
            }
                
        }

        //기존 points에서 유의미한 인덱스만 추출해서 points_after에 삽입함
        for (int i = 0; i < newIndex.Count; i++)
        {
            points_after.Add( points[ newIndex[i] ] );
        }

        //디버그 코드
        string newIndex_string = "";
        for (int i = 0; i < newIndex.Count; i++)
        {
            newIndex_string += (newIndex[i]).ToString();
            newIndex_string += " ";
        }
        print("역보간 된 인덱스 넘버 : " + newIndex_string + ", 인덱스 카운트 : " + newIndex.Count);

        return points_after;
    }

    //벡터3 리스트를 Line으로 그려주는 함수
    public static List<Vector3> CreateLine(List<Vector3> points) // 1번째 매개변수 : (Line의 Position들을 갖는) 벡터3 리스트
    {
        GameObject Line = new GameObject("new Line");
        Line.AddComponent<LineRenderer>();
        LineRenderer lr = Line.GetComponent<LineRenderer>();

        //그려줄 Line의 Index 설정 (매개변수인 points의 index와 같게 설정함)
        lr.positionCount = points.Count;

        //역보간된 라인 좌표 초기화 -> 새로운(역보간된) 직선의 생성
        for (int i = 0; i < points.Count; i++)
        {
            lr.SetPosition(i, points[i]);
        }

        //----------------추가적인것들 ex.굵기, 색 등 비쥬얼적인 부분--------------
        lr.SetWidth(0.3f, 0.3f);

        return points; // 그린 Line의 벡터3 List 반환
    }

    //p1 -> p2 의 방향값 (ex. 좌상) 반환 함수
    public static string WhatDirection(Vector3 p1, Vector3 p2)
    {
       double angle = Slope(p1, p2);

        string direction;
        if (angle > 22.5f && 67.5f > angle) direction = "우상";
        else if (angle > 67.5f && 112.5f > angle) direction = "상";
        else if (angle > 112.5f && 157.5f > angle) direction = "좌상";
        else if (angle > 157.5f && 202.5f > angle) direction = "좌";
        else if (angle > 202.5 && 247.5f > angle) direction = "좌하";
        else if (angle > 247.5f && 292.5f > angle) direction = "하";
        else if (angle > 292.5f && 337.5f > angle) direction = "우하";
        else direction = "우";

        return direction;
    }

    //p1 -> p2 의 각도 (ex. 45도) 반환 함수
    public static double Slope(Vector3 p1, Vector3 p2)
    {
        double p1x = p1.x;
        double p1y = p1.y;

        double p2x = p2.x;
        double p2y = p2.y;

        double deltaX = p2x - p1x;
        double deltaY = p2y - p1y;
        double inc = deltaY / deltaX; // 기울기 -> y증가량 / x증가량

        double radians = Math.Atan(inc);
        double angle = radians * (180 / Math.PI);

        if (deltaX > 0 && deltaY > 0) { angle += 0; } // 1사분면
        else if (deltaX < 0 && deltaY > 0) { angle += 180; } // 2사분면
        else if (deltaX < 0 && deltaY < 0) { angle += 180; } // 3사분면
        else if (deltaX > 0 && deltaY < 0) { angle += 360; } // 4사분면
        //1사분면 각 -> angle
        //2사분면 각 -> 180 + angle
        //3사분면 각 -> 180 + angle
        //4사분면 각 -> 360 + angle
        if (angle < 0) angle += 360;
        // 상->하 직선의 경우 -90도가 됨
        else if (angle == 0) { if (deltaX < 0) angle = 180; }
        // 좌->우, 우->좌 두 직선의 경우 0도가됨(좌->우는 상관없지만 우->좌가 문제)

        return angle;
    }

    //방향 리스트 문자열 반환하며, 일치하는 마법문자를 출력해줌
    public static string returnDirectionList(List<Vector3> Line) //1. 방향 리스트 문자열을 반환받을 Line List
    {
        List<string> DirectionList = new List<string>(); //방향리스트

        for (int i = 0; i < Line.Count - 1; i++)
        {
            DirectionList.Add(WhatDirection(Line[i], Line[i + 1]));
        }

        string InputedMagic = "";
        int Stroke = DirectionList.Count;
        for (int i = 0; i < DirectionList.Count; i++)
        {
            InputedMagic += DirectionList[i];
            InputedMagic += " ";
        }
       
        string GestureAndStroke = "제스처 : " + InputedMagic + "\n획수 : " + Stroke + "\n해당마법 : "+MagicChecking(InputedMagic);
        InputedMagic_joon.setMagicText(GestureAndStroke);
        return InputedMagic;
    }
}