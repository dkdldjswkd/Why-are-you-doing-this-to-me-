using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hero : MonoBehaviour
{
    public int size = 30;

    void Update()
    {
        transform.localScale = TOPUIManager.Instance.start.transform.localScale * size;

        if (this.transform.localPosition.x < TOPUIManager.Instance.end.transform.localPosition.x)
        {
            transform.localPosition = new Vector3(transform.localPosition.x + 30.0f * Time.deltaTime, TOPUIManager.Instance.start.transform.localPosition.y-8, -20);
        }
        else
        {
            Destroy(gameObject);
            TOPUIManager.Instance.DwonSummonsCount();
        }
    }
}
