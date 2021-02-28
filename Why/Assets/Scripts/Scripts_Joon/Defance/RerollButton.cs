using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RerollButton : MonoBehaviour
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
        if (DefanceManager.Cost < 2)
            return;

        DefanceManager.Cost -= 2;
        DefanceManager.Reroll();
    }
}
