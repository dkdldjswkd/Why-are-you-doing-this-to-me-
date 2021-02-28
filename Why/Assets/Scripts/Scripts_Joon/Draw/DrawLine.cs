using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DrawLine : MonoBehaviour
{
    LineRenderer lr;
    List<Vector3> points = new List<Vector3>();
    //int curvePoint = 0;
    public GameObject Line; // 라인렌더러로 그린 오브젝트
    LineScript LS;

    void Update()
    {
        //그리기 시작, 선의 첫 좌표를 정함
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Line = Instantiate(Resources.Load("Prefab/Others/Line")) as GameObject;
            lr = Line.GetComponent<LineRenderer>();

            LS = Line.GetComponent<LineScript>();
            LS.complete = false;

            points.Add(transform.position);
            lr.positionCount = 1;
            lr.SetPosition(0, points[0]);
        }
        //그리는 중, 선의 중간좌표를 정함
        else if (Input.GetKey(KeyCode.Space))
        {
            Vector3 pos = transform.position;
            if (Vector3.Distance(points[points.Count - 1], pos) > 0.1f)
            {
                points.Add(pos);
                lr.positionCount++;
                lr.SetPosition(lr.positionCount - 1, pos);
            }

        }
        //다 그림
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            //// 그려진 라인의 상, 하, 좌, 우 포지션값을 입력함, 아래는 그냥 초기화
            //LS.Location_Up = points[0].y;
            //LS.Location_Down = points[0].y;
            //LS.Location_Left = points[0].x;
            //LS.Location_Right = points[0].x;

            //for (int i = 0; i < lr.positionCount - 1; i++)
            //{
            //    if (LS.Location_Up < points[i].y)
            //        LS.Location_Up = points[i].y;
            //    if (LS.Location_Down > points[i].y)
            //        LS.Location_Down = points[i].y;

            //    if (LS.Location_Left > points[i].x)
            //        LS.Location_Left = points[i].x;
            //    if (LS.Location_Right < points[i].x)
            //        LS.Location_Right = points[i].x;
            //}
            
            ////라인 오브젝트가 전부 그려졌다는것을 알림
            //LS.complete = true;
            //LS.SetInfomation();
            //LS.Interpolation(); // 문제있음

            Interpolation_joon.CreateLine(Interpolation_joon.Interpolation(points));
            points.Clear();
        }
    }
}
