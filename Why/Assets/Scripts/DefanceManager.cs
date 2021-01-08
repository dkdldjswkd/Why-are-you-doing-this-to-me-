using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefanceManager : MonoBehaviour
{
    private List<List<GameObject>> Minions = new List<List<GameObject>>();
    //미니언들을 담는 2차원 리스트

    public static int PlayerLevelMax = 5; // 플레이어 최대 래벨

    private void Start()
    {
        //2차원 리스트를 미니언 프리팹으로 채우는 작업
        for (int i = 0; i < PlayerLevelMax; i++)
        {
            Object[] a = Resources.LoadAll("Prefab/Minions/Level" + (i + 1).ToString());

            Minions.Add(new List<GameObject>());
            for (int j = 0; j < a.Length; j++)
            {
                Minions[i].Add(a[j] as GameObject);
            }
        }

       // Instantiate(Minions[4][0], Vector3.zero, Quaternion.identity); //테스트
    }

    void Update()
    {

    }
}
