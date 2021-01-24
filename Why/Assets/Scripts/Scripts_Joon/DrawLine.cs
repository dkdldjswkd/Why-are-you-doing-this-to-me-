using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    LineRenderer lr;
    List<Vector2> points = new List<Vector2>();

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow)
           || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            GameObject go = Instantiate(Resources.Load("Prefab/Others/Line")) as GameObject;
            lr = go.GetComponent<LineRenderer>();

             go.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

            points.Add(new Vector2(transform.position.x, transform.position.y));
            lr.positionCount = 1;
            lr.SetPosition(0, points[0]);
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)
                || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
        {
            Vector2 pos = new Vector2(transform.position.x, transform.position.y);
            if (Vector2.Distance(points[points.Count - 1], pos) > 0.1f)
            {
                points.Add(pos);
                lr.positionCount++;
                lr.SetPosition(lr.positionCount - 1, pos);
            }
        }
        else
        {
            points.Clear();
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
