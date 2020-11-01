using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hero : MonoBehaviour
{
    void Update()
    {
        transform.localScale = TOPUIManager.Instance.start.transform.localScale * 30;

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
