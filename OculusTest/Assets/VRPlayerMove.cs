﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRPlayerMove : MonoBehaviour
{
    private static VRPlayerMove _instance;

    public static VRPlayerMove Instance
    {
        get
        {
            if (_instance == null)  //유니티에서 찾음
            {
                _instance = FindObjectOfType<VRPlayerMove>();
            }
            if (_instance == null)  //그래도 못찾으면 새로운 오브젝트를 만들어서 컴포넌트를 넣음
            {
                var go = new GameObject(nameof(VRPlayerMove));
                go.AddComponent<VRPlayerMove>();
            }
            return _instance;
        }
    }
    //라인
    public GameObject linePerfab;
    public GameObject linePoint;
    public GameObject linetransform;

    GameObject online;
    bool setline;

    LineRenderer lr;
    EdgeCollider2D col;
    List<Vector3> points = new List<Vector3>();

    public static List<Vector3> finishedDrawing = new List<Vector3>();  //라인 좌표 넘겨줄 완성된 좌표 리스트
    public static bool finshed = false;
    //끝

    public Rigidbody PlayerMoveRg; //카메라를 기준으로함
    public GameObject PlayergameObject;
    private CapsuleCollider PlayerCollider;


    public GameObject SubMove;

    private Animator moveanimator;

    public float speed = 1.0f;
    Vector3 moveDirection;

    void Start()
    {
        online = Instantiate(linePerfab);
        online.transform.parent = linetransform.transform;

        lr = online.GetComponent<LineRenderer>();
        col = online.GetComponent<EdgeCollider2D>();
        points.Add(linePoint.transform.position);

        PlayerMoveRg.GetComponent<Rigidbody>();
        PlayerCollider = GetComponent<CapsuleCollider>();
        moveanimator = PlayergameObject.GetComponent<Animator>();
    }

    void LateUpdate()
    {
        //PlayerCollider.center = new Vector3(PlaterTr.position.x, PlayerCollider.center.y,0);
        transform.position = new Vector3(SubMove.transform.position.x, 0, SubMove.transform.position.z);
        SubMove.transform.rotation = Quaternion.Euler(0, PlayergameObject.transform.rotation.eulerAngles.y, 0);
    }

    public void playermove(float x, float y)
    {
        if (points.Count == 1)
        {
            moveanimator.SetBool("iswalking", true);
            moveDirection = new Vector3(x, 0, y);
            SubMove.transform.Translate(moveDirection * (speed * Time.deltaTime), Space.Self); // AddForce 적용
        }
    }

    public void nomove()
    {
        moveanimator.SetBool("iswalking", false);
    }

    float saveZ;

    public void goline()
    {
        Vector3 pos;
        finshed = false;

        if (points.Count > 1)
        {
            pos = new Vector3(linePoint.transform.position.x, linePoint.transform.position.y, saveZ);
        }
        else
        {
            pos = new Vector3(linePoint.transform.position.x, linePoint.transform.position.y, linePoint.transform.position.z);
            saveZ = linePoint.transform.position.z;
        }

        if (Vector3.Distance(points[points.Count - 1], pos) > 0.01f)
        {
            points.Add(pos);
            lr.positionCount++;
            lr.SetPosition(lr.positionCount - 1, pos);
        }
    }

    public void noline()
    {
        if (points.Count > 1)   //그림이 다 그려지면
        {
            finishedDrawing.Clear();

            for (int i = 0; i < points.Count; i++)
            {
                finishedDrawing.Add(points[i]);
            }

            finshed = true;
            //최준영스크립트.마법발동함수();
            //finishedDrawing준영이 싱글톤 함수로 넘기고 판단 + 마법 나옴
        }
        points.Clear();
        points.Add(linePoint.transform.position);
        points[0] = new Vector3(linePoint.transform.position.x, linePoint.transform.position.y, linePoint.transform.position.z);
        lr.positionCount = 1;
        lr.SetPosition(0, points[0]);
    }
}
