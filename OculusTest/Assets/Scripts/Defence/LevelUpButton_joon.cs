using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpButton_joon : MonoBehaviour
{


    public void LevelUp()
    {
        //플레이어의 레벨이 5미만이고, 레벨업에 필요한 10코스트가 충족됬다면
        if(DefanceManager_joon.Cost >= 10 && DefanceManager_joon.PlayerLevel < 5 )
        {
            //10코스트를 지불하고 레벨업
            DefanceManager_joon.Cost = 0;
            DefanceManager_joon.PlayerLevel++;
        }
    }
}
