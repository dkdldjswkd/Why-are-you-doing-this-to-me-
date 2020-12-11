using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPbar : MonoBehaviour
{
    [SerializeField] GameObject m_goHPPrefab = null;  //HP바 만들기 히어로
    [SerializeField] GameObject m_goHPPrefab2 = null;  //HP바 만들기 몬스터

    List<GameObject> m_objectList = new List<GameObject>();   //HP바가 나올 위치
    List<GameObject> M_hpBarList = new List<GameObject>();  //HP바가 들어간 리스트


    //히어로HP관리
    HeroMove heromove;
    //몬스터HP관리
    LoadScript loadscript;

    Slider slider;

    Camera m_cam = null;

    [SerializeField] private int HeroValue = 0;

    void Start()
    {
        m_cam = Camera.main;

        TestHPbar();
    }


    void Update()
    {
        //소환 또는 삭제 판단
        if(HeroValue!=TOPUIManager.Instance.MapHero)
        {
            setHPbar();
            HeroValue = TOPUIManager.Instance.MapHero;
        }

        //HP바의 위치를 항상 맞춰줌
        for(int i = 0; i<m_objectList.Count; i++)
        {
            slider = M_hpBarList[i].GetComponent<Slider>();

            if (m_objectList[i].tag != "Monster")
            {
                heromove = m_objectList[i].GetComponent<HeroMove>();
                slider.value = heromove.hp / heromove.maxhp;
            }
            else
            {
                loadscript = m_objectList[i].GetComponent<LoadScript>();
                slider.value = loadscript.hp / loadscript.maxhp;
            }
            
            if (slider.value != 0)
            {
                M_hpBarList[i].transform.position = m_cam.WorldToScreenPoint(m_objectList[i].transform.position + new Vector3(0f, 3f, 0));
            }
            else
            {
                TOPUIManager.Instance.mapherodwon();
                Destroy(m_objectList[i]);
                Destroy(M_hpBarList[i]);
                m_objectList.RemoveAt(i);
                M_hpBarList.RemoveAt(i);
            }
        }   
    }

    public void TestHPbar()
    {
        GameObject[] t_objects = GameObject.FindGameObjectsWithTag("Warrior");
        for (int i = 0; i < t_objects.Length; i++)
        {
            m_objectList.Add(t_objects[i]);
            GameObject t_hpbar = Instantiate(m_goHPPrefab, t_objects[i].transform.position, Quaternion.identity, transform);
            M_hpBarList.Add(t_hpbar);
        }

        GameObject[] t_objects2 = GameObject.FindGameObjectsWithTag("Monster");
        for (int i = 0; i < t_objects2.Length; i++)
        {
            m_objectList.Add(t_objects2[i]);
            GameObject t_hpbar = Instantiate(m_goHPPrefab2, t_objects2[i].transform.position, Quaternion.identity, transform);
            M_hpBarList.Add(t_hpbar);
        }
    }

    public void setHPbar()
    {
        for (int i = 0; i < M_hpBarList.Count; i++)
        {
            Destroy(M_hpBarList[i]);
        }
        m_objectList.Clear();
        M_hpBarList.Clear();
        GameObject[] t_objects = GameObject.FindGameObjectsWithTag("Warrior");
        for (int i = 0; i < t_objects.Length; i++)
        {
            m_objectList.Add(t_objects[i]);
            GameObject t_hpbar = Instantiate(m_goHPPrefab, t_objects[i].transform.position, Quaternion.identity, transform);
            M_hpBarList.Add(t_hpbar);
        }

        GameObject[] t_objects2 = GameObject.FindGameObjectsWithTag("Monster");
        for (int i = 0; i < t_objects2.Length; i++)
        {
            m_objectList.Add(t_objects2[i]);
            GameObject t_hpbar = Instantiate(m_goHPPrefab2, t_objects2[i].transform.position, Quaternion.identity, transform);
            M_hpBarList.Add(t_hpbar);
        }
    }
}
