using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefanceManager : MonoBehaviour
{
    static private List<List<GameObject>> Minions = new List<List<GameObject>>();
    //미니언들을 담는 2차원 리스트

    public static int PlayerLevelMax = 5; // 플레이어 최대 래벨
    public static int Cost = 0; // 코스트
    public static int PlayerLevel = 1;
    float CostSpeed = 1; // 코스트 충전속도 ex.x일때 x배속으로 충전됨 (1일때 1배속 2일때 2배속)
    static GameObject[] HandMinions = new GameObject[4]; //플레이어가 가진 핸드 (미니언을 뜻함)

    float Second = 0;

    [SerializeField] Text CostText; // 코스트를 나타내는 텍스트
    [SerializeField] Text PlayerLevelText; // 래벨을 나타내는 텍스트

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

        Reroll();
    }

    void Update()
    {
        ChargeCost(CostSpeed); // 코스트 생성

        PlayerLevelText.text = PlayerLevel.ToString(); // 추후 삭제할것
    }

    void ChargeCost(float CostSpeed = 1)
    {
        CostText.text = Cost.ToString();

        if (Cost >= 10)
        {
            Second = 0;
            return;
        }

        Second += Time.deltaTime * CostSpeed;
        if (Second >= 1)
        {
            Second = 0;
            Cost++;
        }
    }

    static public void Reroll()
    {
        for(int i=0; i < 4; ++i)
        {
            int MinionLevel = Random.Range(0, PlayerLevel);
            int n = Random.Range(0, Minions[MinionLevel].Count);
            HandMinions[i] = Minions[MinionLevel][n];
            print(i + "번째 핸드 : " + HandMinions[i].name);
        }
    }
}
