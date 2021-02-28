﻿using System.Collections;
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

        { "우 하 좌 상 ", "ㅁ(시계방향)"}
    };

    //Dictionary[Key]로 Value를 취득할 수 있다.
    public static void MagicChecking(string inputed)
    {
        string whatMagic;
        if (Magics.TryGetValue(inputed, out whatMagic))
            print(whatMagic);
        else
            print("일치하는 마법이 없습니다.");
    }

    public static string WhatDirection(Vector3 p1, Vector3 p2)
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

    //보간
    public static List<Vector3> Interpolation(List<Vector3> points)
    {
        List<string> DirectionList = new List<string>(); // 보간전 방향리스트

        //보간전 방향리스트 생성 
        for (int i = 0; i < points.Count - 1; i++)
        {
            double p1x = points[i].x;
            double p1y = points[i].y;

            double p2x = points[i + 1].x;
            double p2y = points[i + 1].y;

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

            string direction;
            if (angle > 22.5f && 67.5f > angle) direction = "우상";
            else if (angle > 67.5f && 112.5f > angle) direction = "상";
            else if (angle > 112.5f && 157.5f > angle) direction = "좌상";
            else if (angle > 157.5f && 202.5f > angle) direction = "좌";
            else if (angle > 202.5 && 247.5f > angle) direction = "좌하";
            else if (angle > 247.5f && 292.5f > angle) direction = "하";
            else if (angle > 292.5f && 337.5f > angle) direction = "우하";
            else direction = "우";

            DirectionList.Add(direction);
        }

        List<string> DirectionList_after = new List<string>(); //보간 후 방향리스트
        List<Vector3> points_after = new List<Vector3>(); //보간 후 포인트

        //---- 테스트 .RemoveAt(인덱스);
        points_after = points; // 보간후 포인트의 첫번째 인덱스 추가

        //1차 보간
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


        //points_after.Add(points[0]); // 보간후 포인트의 첫번째 인덱스 추가

        //int Deviate = 0; // 어긋난 점의 인덱스
        ////1차 보간 (어긋나지 않은 직선들을 한 직선으로 통일시킴)
        //for (int i = 0; i < DirectionList.Count - 1; i++)
        //{
        //    Deviate++;

        //    string tmp1 = DirectionList[i]; // ex. p0 -> p1 의 직선방향 (ex. 우상)
        //    string tmp2 = DirectionList[i + 1]; // ex. p1 -> p2 의 직선방향 (ex. 상)

        //    //이부분 수정해야함
        //    if (tmp1 != tmp2 || i == DirectionList.Count - 2) // 직선의 방향이 어긋나면 또는 마지막 인덱스라면
        //    {
        //        points_after.Add(points[Deviate]); //기본형 라인의 어긋난 좌표를 추가
        //    }
        //}


        float lineLangth = 0; // 1차 보간된 그림의 길이를 담는 변수
        for (int i = 0; i < points_after.Count - 1; i++) // 1차 보간된 그림의 길이를 변수에 담는 반복문
        {
            lineLangth += Vector3.Distance(points_after[i], points_after[i + 1]);
        }

        //제외 기준 길이 설정 (총길이 / 직선의개수 * 2)
        float deadline = lineLangth / ((points_after.Count - 1) * 2);

        //2차 보간 (짧은 직선은 제외시킴)
        if(points_after.Count > 1)
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


        //보간된 직선의 방향 리스트 생성
        for (int i = 0; i < points_after.Count - 1; i++)
        {
            double p1x = points_after[i].x;
            double p1y = points_after[i].y;

            double p2x = points_after[i + 1].x;
            double p2y = points_after[i + 1].y;

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

            string direction;
            if (angle > 22.5f && 67.5f > angle) direction = "우상";
            else if (angle > 67.5f && 112.5f > angle) direction = "상";
            else if (angle > 112.5f && 157.5f > angle) direction = "좌상";
            else if (angle > 157.5f && 202.5f > angle) direction = "좌";
            else if (angle > 202.5 && 247.5f > angle) direction = "좌하";
            else if (angle > 247.5f && 292.5f > angle) direction = "하";
            else if (angle > 292.5f && 337.5f > angle) direction = "우하";
            else direction = "우";

            DirectionList_after.Add(direction);
        }

        string InputedMagic = "";
        for (int i = 0; i < DirectionList_after.Count; i++)
        {
            InputedMagic += DirectionList_after[i];
            InputedMagic += " ";
        }

        //출력 테스트
        print(InputedMagic);

        MagicChecking(InputedMagic);
        // points_after.Clear();

        return points_after;
    }

    //벡터3 리스트를 Line으로 그려주는 함수
    public static void CreateLine(List<Vector3> points) // 1번째 매개변수 : (Line의 Position들을 갖는) 벡터3 리스트
    {
        GameObject Line = new GameObject("new Line");
        Line.AddComponent<LineRenderer>();
        LineRenderer lr = Line.GetComponent<LineRenderer>();

        //보간된 라인의 최대 인덱스 초기화
        lr.positionCount = points.Count;

        //보간된 라인 좌표 초기화 -> 새로운(보간된) 직선의 생성
        for (int i = 0; i < points.Count; i++)
        {
            lr.SetPosition(i, points[i]);
        }

        //----------------추가적인것들 ex.굵기, 색 등 비쥬얼적인 부분--------------
        lr.SetWidth(0.1f, 0.1f);
    }
}