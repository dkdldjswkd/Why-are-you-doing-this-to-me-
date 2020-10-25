using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Defence : MonoBehaviour
{
    public static int Cost;
    public static int LEVEL;
    public float CostChargeSpeed;

    float Second;

    [SerializeField]
    private Text CostText;
    [SerializeField]
    private Text LevelText;



    void Start()
    {
        Second = 0;
        Cost = 0;
        LEVEL = 1;
    }

    // Update is called once per frame
    void Update()
    {
        CostChange(); // 코스트 최신화
        LevelText.text = LEVEL.ToString(); // 레벨 최신화

        print(Cost);
        print(LEVEL);
    }

    void CostChange()
    {
        Second += Time.deltaTime * (1 + CostChargeSpeed);
        if (Second >= 1)
        {
            Second = 0;
            Cost += 1;
        }
        CostText.text = Cost.ToString();
    }


}
