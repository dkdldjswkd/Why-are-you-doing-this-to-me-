﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DrawLine : MonoBehaviour
{
    LineRenderer lr;
    List<Vector3> points = new List<Vector3>();
    int curvePoint = 0;
    GameObject go;

    void Update()
    {
        //그리기 시작, 선의 첫 좌표를 정함
        if (Input.GetKeyDown(KeyCode.Space))
        {
            go = Instantiate(Resources.Load("Prefab/Others/Line")) as GameObject;
            lr = go.GetComponent<LineRenderer>();


            points.Add(transform.position);
            lr.positionCount = 1;
            lr.SetPosition(0, points[0]);
        }
        //그리는 중, 선의 중간좌표를 정함
        else if (Input.GetKey(KeyCode.Space))
        {
            Vector3 pos = transform.position;
            if (Vector3.Distance(points[points.Count - 1], pos) > 0.01f)
            {
                points.Add(pos);
                lr.positionCount++;
                lr.SetPosition(lr.positionCount - 1, pos);

                //좌표가 3개이상 쌓였다면
                if (lr.positionCount >= 3)
                {
                    Vector3 p1 = lr.GetPosition(lr.positionCount - 3);
                    Vector3 p2 = lr.GetPosition(lr.positionCount - 2);
                    Vector3 p3 = lr.GetPosition(lr.positionCount - 1);

                    //상
                    if (p2.x == p3.x && p2.y > p3.y) { if (!(p1.x == p2.x && p1.y > p2.y)) { curvePoint++; print("미분 불가능"); } }
                    //하
                    else if (p2.x == p3.x && p2.y < p3.y) { if (!(p1.x == p2.x && p1.y < p2.y)) { curvePoint++; print("미분 불가능"); } }
                    //좌
                    else if (p2.x < p3.x && p2.y == p3.y) { if (!(p1.x < p2.x && p1.y == p2.y)) { curvePoint++; print("미분 불가능"); } }
                    //우
                    else if (p2.x > p3.x && p2.y == p3.y) { if (!(p1.x > p2.x && p1.y == p2.y)) { curvePoint++; print("미분 불가능"); } }
                    //좌상
                    else if (p2.x < p3.x && p2.y > p3.y) { if (!(p1.x < p2.x && p1.y > p2.y)) { curvePoint++; print("미분 불가능"); } }
                    //우상
                    else if (p2.x > p3.x && p2.y > p3.y) { if (!(p1.x > p2.x && p1.y > p2.y)) { curvePoint++; print("미분 불가능"); } }
                    //좌하
                    else if (p2.x < p3.x && p2.y < p3.y) { if (!(p1.x < p2.x && p1.y < p2.y)) { curvePoint++; print("미분 불가능"); } }
                    //우하 
                    else if (p2.x > p3.x && p2.y < p3.y) { if (!(p1.x > p2.x && p1.y < p2.y)) { curvePoint++; print("미분 불가능"); } }
                }
            }

        }
        //다 그림
        else if(Input.GetKeyUp(KeyCode.Space))
        {
            points.Clear();
            print("커브 포인트 : " + curvePoint.ToString());
            curvePoint = 0;
           // Destroy(go, 3f);
        }
    }

    //원래 코드
    //LineRenderer lr;
    //EdgeCollider2D col;
    //List<Vector2> points = new List<Vector2>();

    //void Update()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        GameObject go = Instantiate(Resources.Load("Prefab/Others/Line")) as GameObject;
    //        lr = go.GetComponent<LineRenderer>();
    //        col = go.GetComponent<EdgeCollider2D>();
    //        points.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
    //        lr.positionCount = 1;
    //        lr.SetPosition(0, points[0]);
    //    }
    //    else if (Input.GetMouseButton(0))
    //    {
    //        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //        if (Vector2.Distance(points[points.Count - 1], pos) > 0.1f)
    //        {
    //            points.Add(pos);
    //            lr.positionCount++;
    //            lr.SetPosition(lr.positionCount - 1, pos);
    //            col.points = points.ToArray();
    //        }
    //    }
    //    else if (Input.GetMouseButtonUp(0))
    //    {
    //        points.Clear();
    //    }
    //}
}
