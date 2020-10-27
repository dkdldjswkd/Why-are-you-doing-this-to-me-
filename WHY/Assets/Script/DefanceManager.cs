using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefanceManager : MonoBehaviour
{
    public static float Cost; // 기물 구매, 래벨업에 상용되는 재화
    public static int Level; // 플레이어 레벨

    int MaxCost; // 최대 코스트 제한
    float Production; // 코스트 생성 속도
    

    [SerializeField] Text LevelText; // 플레이러 레벨을 화면에 나타내는 텍스트
    [SerializeField] Text CostText; // 코스트를 화면에 나타내는 텍스트

    void Start()
    {
        Cost = 0;
        if (Production == 0) Production = 1;
        if (MaxCost == 0) MaxCost = 10;
        Level = 1;
    }

    // Update is called once per frame
    void Update()
    {
        MakeCost();
        PrintLevel();
    }

    // 시간에 따른 코스트 생성 함수
    void MakeCost()
    {
        //코스트가 10미만이라면 코스트를 생성함
        if (!(Cost >= 10))
        {
            Cost += Time.deltaTime * (Production);
        }

        CostText.text = "Cost : " + ((int)Cost).ToString();
    }

    void PrintLevel()
    {
        LevelText.text = "Level : " + (Level).ToString();
    }
}
