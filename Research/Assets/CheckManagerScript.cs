using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckManagerScript : MonoBehaviour
{
    public GameObject manager;
    public Image checkimage;
    public int length;

    Vector3 vector3 = new Vector3(0, 0, 0);

    void Start()
    {
        print("체크박스생성");
        for (int i = 0; i < length; ++i)
        {
            for (int s = 0; s < length; ++s)
            {
                Image go = Instantiate(checkimage);
                go.transform.SetParent(manager.transform);
                go.transform.localPosition = vector3;
                vector3 = new Vector3(vector3.x + 1, vector3.y, vector3.z);
            }
            vector3 = new Vector3(0, vector3.y-1, vector3.z);
        }
    }
}
