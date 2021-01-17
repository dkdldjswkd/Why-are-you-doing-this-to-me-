using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitButton : MonoBehaviour
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
        DefanceManager.ReadyMinion = DefanceManager.HandMinions[MyNumber];
        DefanceManager.ActivatedButtonNumber = MyNumber;
    }

}
