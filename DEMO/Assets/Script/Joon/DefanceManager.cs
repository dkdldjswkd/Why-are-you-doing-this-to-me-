using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.UI;

public class DefanceManager : MonoBehaviour
{
    public static float Cost; // 기물 구매, 래벨업에 상용되는 재화
    public static int Level; // 플레이어 레벨

    public static GameObject WatingMinion;

    int MaxCost; // 최대 코스트 제한
    [SerializeField]float Production; // 코스트 생성 속도
    [SerializeField] static public int MaxLevel;

    [SerializeField] Camera RayCamera;

    [SerializeField] Text LevelText; // 플레이러 레벨을 화면에 나타내는 텍스트
    [SerializeField] Text CostText; // 코스트를 화면에 나타내는 텍스트

    static public int[,] MinionActCheck = new int[5, 3]; // 1은 활성화, 0는 비활성화, 3은 없음
    public static GameObject[,] Minions = new GameObject[5, 3]; //실제 미니언 오브젝트
    public static Sprite[,] MinionsSprite = new Sprite[5, 3]; //미니언 이미지

    void Start()
    {
        Cost = 0;
        if (Production == 0) Production = 1;
        if (MaxCost == 0) MaxCost = 10;
        Level = 1;

        //모든 미니언들을 비활성화
        for (int i = 0; i < 5; ++i)
        {
            for (int j = 0; j < 3; ++j)
            {
                MinionActCheck[i, j] = 0;
            }
        }
        //존재하지 않는 미니언을 구분
        MinionActCheck[1, 2] = 3;
        MinionActCheck[2, 2] = 3;
        MinionActCheck[3, 1] = 3;
        MinionActCheck[3, 2] = 3;
        MinionActCheck[4, 1] = 3;
        MinionActCheck[4, 2] = 3;

        //레벨 1 : 강아지 워리어(1), 원거리 토끼(1), 공사장표지판(1)
        //레벨 2 : 바나나 원숭이(2), 힐(4)
        //레벨 3 : 고릴라(4), 메테오(3)
        //레벨 4 : 변이(5),      
        //레벨 5 : 레드 드래곤(10코스트)
        Minions[0, 0] = Resources.Load("prefab/Minions/Minion_dog") as GameObject;
        Minions[0, 1] = Resources.Load("prefab/Minions/Minion_rabbit") as GameObject;
        Minions[0, 2] = Resources.Load("prefab/Minions/Minion_obstacle") as GameObject;
        Minions[1, 0] = Resources.Load("prefab/Minions/Minion_monkey") as GameObject;
        Minions[1, 1] = Resources.Load("prefab/Minions/Minion_heal") as GameObject;
        Minions[2, 0] = Resources.Load("prefab/Minions/Minion_gorilla") as GameObject;
        Minions[2, 1] = Resources.Load("prefab/Minions/Minion_meteor") as GameObject;
        Minions[3, 0] = Resources.Load("prefab/Minions/Minion_change") as GameObject;
        Minions[4, 0] = Resources.Load("prefab/Minions/Minion_dragon") as GameObject;

        MinionsSprite[0, 0] = Resources.Load<Sprite>("Minion's Image/Minion_image_dog");
        MinionsSprite[0, 1] = Resources.Load<Sprite>("Minion's Image/Minion_image_rabbit");
        MinionsSprite[0, 2] = Resources.Load<Sprite>("Minion's Image/Minion_image_obstacle");
        MinionsSprite[1, 0] = Resources.Load<Sprite>("Minion's Image/Minion_image_monkey");
        MinionsSprite[1, 1] = Resources.Load<Sprite>("Minion's Image/Minion_image_heal");
        MinionsSprite[2, 0] = Resources.Load<Sprite>("Minion's Image/Minion_image_gorilla");
        MinionsSprite[2, 1] = Resources.Load<Sprite>("Minion's Image/Minion_image_meteor");
        MinionsSprite[3, 0] = Resources.Load<Sprite>("Minion's Image/Minion_image_change");
        MinionsSprite[4, 0] = Resources.Load<Sprite>("Minion's Image/Minion_image_dragon");
    }

    // Update is called once per frame
    void Update()
    {
        MakeCost();
        PrintLevel();
        SummonObject();

        //다른 객체의 스크립트 가져오기
        //SpawnerButton a = GameObject.Find("SpawnerButton_0").GetComponent<SpawnerButton>();
        //a.Sample();        
    }

    // 시간에 따른 코스트 생성 함수
    void MakeCost()
    {
        //코스트가 10미만이라면 코스트를 생성함
        if (!(Cost >= 10))
        {
            Cost += Time.deltaTime * (Production);
        }

        CostText.text = "Cost : " + ((int)Cost).ToString();
    }

    void PrintLevel()
    {
        LevelText.text = "Level : " + (Level).ToString();
    }

    //유닛소환 함수
    void SummonObject()
    {
        //활성화된 버튼이 있다면
        if (SpawnerButton.ActButton != 100)
        {
            // 카메라에서 스크린으로 쏘는 레이저, 마우스 포지션 좌표에
            Ray ray = RayCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            //좌클릭시, ray가 물체에 충돌했으며, 충돌한 물체의 tag가 ground 라면
            if (Physics.Raycast(ray, out hit) && Input.GetMouseButton(0) && (hit.transform.tag == "Ground" || hit.transform.tag == "Warrior"  || hit.transform.tag == "Monster"))
            {
                //돈이 1원 이상 있다면
                if (Cost >= 1)
                {
                    //실질적으로 미니언이 생성되는 구간
                    GameObject summondObject = null;

                    summondObject = Instantiate(WatingMinion, new Vector3(hit.point.x, 0, hit.point.z), Quaternion.identity) as GameObject;
                    for (int i = 0; i < 4; ++i)
                    {
                        SpawnerButton.ClickedButton[i] = false;
                    }
                    SpawnerButton.showbuttonsState();
                    Cost--;

                    GameObject.Find("SpawnerButton_" + SpawnerButton.ActButton).GetComponent<SpawnerButton>().roll();
                    SpawnerButton.ActButton = 100;

                    TOPUIManager.Instance.mapheroup();
                }
                else
                {
                }
            }
        }


    }


}

//레벨 1 : 강아지 워리어(1), 원거리 토끼(1), 공사장표지판(1)
//레벨 2 : 바나나 원숭이(2), 힐(4)
//레벨 3 : 고릴라(4), 메테오(3)
//레벨 4 : 변이(5),      
//레벨 5 : 레드 드래곤(10코스트)