using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvUpButton : MonoBehaviour
{

    public void LevelUp()
    {
        if (Defence.Cost >= 10)
        {
            Defence.Cost -= 10;
            Defence.LEVEL++;
        }
    }
}
