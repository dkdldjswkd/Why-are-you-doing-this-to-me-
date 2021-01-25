using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaneScript : MonoBehaviour
{

    void Start()
    {
        
    }


    void Update()
    {
        if(Input.GetKeyUp(KeyCode.P))
        {
            print("판단시작");
        }
    }
}
