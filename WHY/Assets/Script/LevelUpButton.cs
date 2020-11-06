using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpButton : MonoBehaviour
{
    int LevelUpPrice; // 레벨업 가격
    Text tmp;


    [SerializeField] Text CostErrorText;
    [SerializeField] Image ErrorPosition;

    private void Start()
    {
        if (LevelUpPrice == 0) LevelUpPrice = 10;
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
        Text t = Instantiate(CostErrorText, ErrorPosition.transform.position, Quaternion.identity) as Text;
        t.transform.parent = ErrorPosition.transform;
        Destroy(t, 1);
    }
}
