using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineScript : MonoBehaviour
{
    public GameObject linePerfab;
    public GameObject linePoint;

    LineRenderer lr;
    EdgeCollider2D col;
    List<Vector3> points = new List<Vector3>();
    
    void Start()
    {
        GameObject go = Instantiate(linePerfab);
        lr = go.GetComponent<LineRenderer>();
        col = go.GetComponent<EdgeCollider2D>();
        points.Add(linePoint.transform.position);
        lr.positionCount = 1;
        lr.SetPosition(0, points[0]);
    }


    void Update()
    {
        Vector3 pos = linePoint.transform.position;
        if (Vector3.Distance(points[points.Count - 1], pos) > 1.0f)
        {
            points.Add(pos);
            lr.positionCount++;
            lr.SetPosition(lr.positionCount - 1, pos);
        }
    }
}
