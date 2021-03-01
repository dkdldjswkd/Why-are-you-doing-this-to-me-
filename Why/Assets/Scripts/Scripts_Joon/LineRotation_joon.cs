using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class LineRotation_joon : MonoBehaviour
{

    public static List<Vector3> BasicLine(List<Vector3> Line, double Angle, Vector3 PlayerPosition) // 1. 대상으로 삼을 Line List, 2.Player의 Y축 회전값, 3.Player의 Position(Vector3)
    {
        List<Vector3> CloneLine = new List<Vector3>();
        CloneLine = Line;

        //회전이동 하기 위해 좌표를 원점으로함
        for(int i = 0; i < CloneLine.Count; i++)
        {
            CloneLine[i] = new Vector3(CloneLine[i].x - PlayerPosition.x, CloneLine[i].y, CloneLine[i].z - PlayerPosition.z);
        }

        for(int i=0; i< CloneLine.Count; i++)
        {
            Double tmpX = CloneLine[i].x * Cos(Angle) - CloneLine[i].z * Sin(Angle);
            Double tmpZ = CloneLine[i].x * Sin(Angle) + CloneLine[i].z * Cos(Angle);

            CloneLine[i] = new Vector3((float)tmpX, CloneLine[i].y, (float)tmpZ);
           // CloneLine[i] = new Vector3((float)tmpX, CloneLine[i].y, 100);
        }

        return CloneLine;
    }

    public static double Sin(double Theta)
    {
        double radians = Theta * Math.PI / 180; //라디안으로 바꿈
        return Math.Sin(radians);
    }

    public static double Cos(double Theta)
    {
        double radians = Theta * Math.PI / 180; //라디안으로 바꿈
        return Math.Cos(radians);
    }

    public static double Tan(double Theta)
    {
        double radians = Theta * Math.PI / 180; //라디안으로 바꿈
        return Math.Tan(radians);
    }
}
