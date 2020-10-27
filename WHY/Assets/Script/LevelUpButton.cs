using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpButton : MonoBehaviour
{
    int LevelUpPrice; // 레벨업 가격
    Text tmp;

    GameObject g;
    GameObject a;
    [SerializeField]GameObject b;

    private void Start()
    {
        if (LevelUpPrice == 0) LevelUpPrice = 10;
    }


    public void LevelUp()
    {
        if(DefanceManager.Cost >= 10)
        {
            DefanceManager.Cost -= LevelUpPrice;
            DefanceManager.Level++;
        }
        else
        {

            g = GameObject.Find("Defance_UI");
            a = Instantiate(b, g.transform.position, Quaternion.identity) as GameObject;
            a.transform.parent = g.transform;
        }

    }
}
