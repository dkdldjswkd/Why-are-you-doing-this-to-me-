using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RerollButton : MonoBehaviour
{
    [SerializeField] int HowMuchReroll;

    public void Reroll()
    {
        if (DefanceManager.Cost < HowMuchReroll)
            return;

        DefanceManager.Cost -= HowMuchReroll;
        for(int i = 0; i < 4; ++i)
        {
            while (true)
            {
                SpawnerButton.RandomX = Random.Range(0, DefanceManager.Level); SpawnerButton.RandomY = Random.Range(0, 3);
                if (DefanceManager.MinionActCheck[SpawnerButton.RandomX, SpawnerButton.RandomY] != 3)
                {
                    break;
                }
            }
            //자신버튼의 미니언으로 지정하고 활성화 시킴
            SpawnerButton.MyMinion[i] = DefanceManager.Minions[SpawnerButton.RandomX, SpawnerButton.RandomY];
            DefanceManager.MinionActCheck[SpawnerButton.RandomX, SpawnerButton.RandomY] = 1;
        }

        print("리롤");
    }
}
