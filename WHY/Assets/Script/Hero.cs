using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hero : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(0.0f, -50.0f * Time.deltaTime, 0.0f);  //회전 임시 -> 캐릭터로 바꿀때는 애니메이터 넣을거라 걍 눈 즐거움 용
        transform.localScale = TOPUIManager.Instance.start.transform.localScale * 8;

        if (this.transform.localPosition.x < TOPUIManager.Instance.end.transform.localPosition.x)
        {
            transform.localPosition = new Vector3(transform.localPosition.x + 30.0f * Time.deltaTime, TOPUIManager.Instance.start.transform.localPosition.y, 0);
        }
        else
        {
            Destroy(gameObject);
            TOPUIManager.Instance.DwonSummonsCount();
        }
    }
}
