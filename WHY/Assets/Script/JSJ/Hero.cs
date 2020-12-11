using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Hero : MonoBehaviour
{
    [SerializeReference]
    private float size = 2.5f;

    [SerializeReference]
    private int herotype;

    private float percent;

    void Start()
    {
        percent = 0.01f;
    }

    void Update()
    {
        //캔버스 크기에 따른 Scale 변경 : x로만 한 이유는 정사각형을 기준으로 캐릭터 크기를 다 정해줘야하는데 직사각형으로 만들어가지고 하나로만 통일하면 끝이라서
        transform.localScale = new Vector3(-TOPUIManager.Instance.start.rectTransform.rect.x * size, -TOPUIManager.Instance.start.rectTransform.rect.x * size, -TOPUIManager.Instance.start.rectTransform.rect.x * size);

        float street = Math.Abs(TOPUIManager.Instance.start.transform.localPosition.x) + TOPUIManager.Instance.end.transform.localPosition.x; //start 와 end 거리를 구함
        float avg = street * percent; //거리의 이동 평균을 구함
        percent += 0.02f;   //스피드 조절 원본 0.0002f

        //print("start 와 end 거리 :" + street);
        //print((percent*100)+"% 이동");
        //print("퍼센트 이동 거리:" + avg);

        //end 이미지좌표까지 도착하지 않았다면 (이동)
        if (this.transform.localPosition.x <= TOPUIManager.Instance.end.transform.localPosition.x)
        {
            transform.localPosition = new Vector3(TOPUIManager.Instance.start.transform.localPosition.x + avg, TOPUIManager.Instance.start.transform.localPosition.y - 8, -20);
        }
        else
        {
            Destroy(gameObject);
            TOPUIManager.Instance.DwonSummonsCount(herotype);
        }
    }
}
