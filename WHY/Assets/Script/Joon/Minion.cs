using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minion : MonoBehaviour
{
    Transform Target;

    public float maxhp=1;
    public float hp=1;

    private void Start()
    {
         Target = GameObject.FindWithTag("Warrior").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Target != null)
        {
            transform.LookAt(Target);
        }
        else
        {
            Target = GameObject.FindWithTag("Warrior").transform;
        }
       
    }
}
