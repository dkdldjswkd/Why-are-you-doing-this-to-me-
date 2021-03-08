using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DrawLine : MonoBehaviour
{
    [SerializeField] GameObject ParentObject;

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

            //Interpolation_joon.CreateLine(Interpolation_joon.Interpolation(points));

            //List<Vector3> Interpolation(List<Vector3> points); //보간되기전 Line List를 매개변수로 받아 보간 후의 Line List를 반환해줌
            //void CreateLine(List<Vector3> points); // Line List를 매개변수로 받고, 눈으로 보이는 LineObject를 생성해줌


            Interpolation_joon.returnDirectionList // 문자의 제스처를 판단하고 제스처 리스트에 합당하는 벨류값을 반환함 (제스처 string 반환 (ex. 상 우하 상))
            (
                Interpolation_joon.CreateLine // 벡터3 리스트를 문자 그려줌 (시각화함) (벡터3 리스트 반환)
                (
                    Interpolation_joon.Interpolation // 보간을 진행함 (벡터3 리스트 반환)
                    (
                        LineRotation_joon.BasicLine(points, ParentObject.transform.eulerAngles.y, ParentObject.transform.position) // 문자를 판단하기위해 z축방향으로 문자를 회전시킴 (벡터3 리스트 반환)
                    )
                )
            );

            //Interpolation_joon.returnDirectionList
            //(
            //    Interpolation_joon.CreateLine
            //    (

            //        Interpolation_joon.Interpolation
            //        (
            //            LineRotation_joon.BasicLine(points, ParentObject.transform.eulerAngles.y, ParentObject.transform.position)
            //        )
            //    )
            //);

            points.Clear();
        }
    }



}

