using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpButton : MonoBehaviour
{
    int LevelUpPrice; // 레벨업 가격
    Text ErrorText;

    [SerializeField] Image ErrorPosition;

    private void Start()
    {
        if (LevelUpPrice == 0) LevelUpPrice = 10;
        ErrorText = ErrorPosition.transform.GetChild(0).GetComponent<Text>();
    }


    public void LevelUp()
    {
        if (DefanceManager.Cost >= 10)
        {
            DefanceManager.Cost -= LevelUpPrice;
            DefanceManager.Level++;
        }
        else
        {
            CostError();
        }

    }

    public void CostError()
    {
        ErrorText.text = "레벨업에 필요한 코스트가 부족합니다.";
        Invoke("ErrorTextFormat", 1f);
    }

    void ErrorTextFormat()
    {
        ErrorText.text = "";
    }

}
