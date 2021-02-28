using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitButton_joon : MonoBehaviour
{
    string Myname;
    int MyNumber;


    // Start is called before the first frame update
    void Start()
    {
        Myname = gameObject.name;
        MyNumber = Myname[Myname.Length - 1] - '0';
    }

    public void SetReadyMinion()
    {
        DefanceManager_joon.ReadyMinion = DefanceManager_joon.HandMinions[MyNumber];
        DefanceManager_joon.ActivatedButtonNumber = MyNumber;
    }

}
