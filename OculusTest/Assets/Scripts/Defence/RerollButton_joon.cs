using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RerollButton_joon : MonoBehaviour
{
   // DefanceManager DefanceManagerScript;
   // GameObject DefanceManagerObject;
    void Start()
    {
       // DefanceManagerObject = GameObject.Find("DefanceManager");
      //  DefanceManagerScript = DefanceManagerObject.GetComponent<DefanceManager>();
    }

    public void Reroll()
    {
        if (DefanceManager_joon.Cost < 2)
            return;

        DefanceManager_joon.Cost -= 2;
        DefanceManager_joon.Reroll();
    }
}
