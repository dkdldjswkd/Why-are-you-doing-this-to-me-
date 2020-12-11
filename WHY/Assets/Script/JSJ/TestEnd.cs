using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnd : MonoBehaviour
{
    public GameObject end;

    Camera m_cam = null;
    // Start is called before the first frame update
    void Start()
    {
        m_cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        transform.transform.position = m_cam.WorldToScreenPoint(end.transform.position + new Vector3(20f, 20f, 0));
    }
}
