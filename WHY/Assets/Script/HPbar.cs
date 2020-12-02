using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPbar : MonoBehaviour
{
    [SerializeField] GameObject m_goHPPrefab = null;  //HP바 만들기

    List<Transform> m_objectList = new List<Transform>();   //HP바가 나올 위치
    List<GameObject> M_hpBarList = new List<GameObject>();  //HP바가 들어간 리스트

    Camera m_cam = null;

    [SerializeField] private int HeroValue = 0;

    void Start()
    {
        m_cam = Camera.main;

        TestHPbar();
    }


    void Update()
    {
        if(HeroValue!=TOPUIManager.Instance.MapHero)
        {
            setHPbar();
            HeroValue = TOPUIManager.Instance.MapHero;
        }

        //HP바의 위치를 항상 맞춰줌
        for(int i = 0; i<m_objectList.Count; i++)
        {
            M_hpBarList[i].transform.position = m_cam.WorldToScreenPoint(m_objectList[i].position + new Vector3(5.5f, 24f, 0));
        }
    }

    public void TestHPbar()
    {
        GameObject[] t_objects = GameObject.FindGameObjectsWithTag("Warrior");
        for (int i = 0; i < t_objects.Length; i++)
        {
            m_objectList.Add(t_objects[i].transform);
            GameObject t_hpbar = Instantiate(m_goHPPrefab, t_objects[i].transform.position, Quaternion.identity, transform);
            M_hpBarList.Add(t_hpbar);
        }
    }

    public void setHPbar()
    {
        GameObject[] t_objects = GameObject.FindGameObjectsWithTag("Warrior");
        m_objectList.Add(t_objects[HeroValue].transform);
        GameObject t_hpbar = Instantiate(m_goHPPrefab, t_objects[HeroValue].transform.position, Quaternion.identity, transform);
        M_hpBarList.Add(t_hpbar);

    }
}
