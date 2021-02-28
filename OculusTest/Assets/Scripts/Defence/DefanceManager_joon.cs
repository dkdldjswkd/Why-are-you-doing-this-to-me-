using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefanceManager_joon : MonoBehaviour
{
    static private List<List<GameObject>> Minions = new List<List<GameObject>>();
    //미니언들을 담는 2차원 리스트

    public static int PlayerLevelMax = 5; // 플레이어 최대 래벨
    public static int Cost = 0; // 코스트
    public static int PlayerLevel = 1;
    float CostSpeed = 1; // 코스트 충전속도 ex.x일때 x배속으로 충전됨 (1일때 1배속 2일때 2배속)
    public static GameObject[] HandMinions = new GameObject[4]; //플레이어가 가진 핸드 (미니언을 뜻함)

    //미니언 소환 버튼 이미지
    public static Image[] UnitButtonImage = new Image[4];

    float Second = 0;

    [SerializeField] Text CostText; // 코스트를 나타내는 텍스트
    [SerializeField] Text PlayerLevelText; // 래벨을 나타내는 텍스트
    [SerializeField] Text ReadyMinionText; // 준비된 미니언을 나타내는 텍스트
    [SerializeField] Text ActivatedButtonNumberText; // 소환 대기 버튼 넘버를 나타내는 텍스트

    public static GameObject ReadyMinion = null; // 소환 대기 미니언
    public static int ActivatedButtonNumber = 999; // 소환 대기 버튼 넘버 (999 == null 대체)

    private void Start()
    {
        //유닛소환 이미지 겟 컴포넌트
        GameObject UnitButtonHolder = GameObject.Find("UnitButtonHolder");
        for (int i = 0; i < 4; i++)
            UnitButtonImage[i] = UnitButtonHolder.transform.GetChild(i).GetComponent<Image>();

        //2차원 리스트를 미니언 프리팹으로 채우는 작업
        for (int i = 0; i < PlayerLevelMax; i++)
        {
            Object[] a = Resources.LoadAll("Prefab/Minions/Level" + (i + 1).ToString());
            Minions.Add(new List<GameObject>());
            for (int j = 0; j < a.Length; j++)
            {
                Minions[i].Add(a[j] as GameObject);
            }
        }
        //  Instantiate(Minions[4][0], Vector3.zero, Quaternion.identity); //테스트

        Reroll();


    }

    void Update()
    {
        ChargeCost(CostSpeed); // 코스트 생성

        //추후 삭제
        PlayerLevelText.text = PlayerLevel.ToString();

        //추후 삭제
        if (ReadyMinion != null)
            ReadyMinionText.text = ReadyMinion.name;
        else
            ReadyMinionText.text = "null";

        //추후 삭제
        if (ActivatedButtonNumber < 4)
            ActivatedButtonNumberText.text = ActivatedButtonNumber.ToString();
        else
            ActivatedButtonNumberText.text = "null";

        SummonMinion();
    }

    void ChargeCost(float CostSpeed = 1)
    {
        CostText.text = Cost.ToString();

        if (Cost >= 10)
        {
            Second = 0;
            return;
        }

        Second += Time.deltaTime * CostSpeed;
        if (Second >= 1)
        {
            Second = 0;
            Cost++;
        }
    }

    public static void Reroll()
    {
        for (int i = 0; i < 4; ++i)
        {
            int MinionLevel = Random.Range(0, PlayerLevel);
            int n = Random.Range(0, Minions[MinionLevel].Count);
            HandMinions[i] = Minions[MinionLevel][n];
           // print(i + "번째 핸드 : " + HandMinions[i].name);

            UnitButtonImage[i].sprite = Resources.Load("Image/Minions/" + HandMinions[i].name, typeof(Sprite)) as Sprite;
        }

        ReadyMinionReset();
    }

    public static void SelectReroll(int x)
    {
            int MinionLevel = Random.Range(0, PlayerLevel);
            int n = Random.Range(0, Minions[MinionLevel].Count);
            HandMinions[x] = Minions[MinionLevel][n];

            UnitButtonImage[x].sprite = Resources.Load("Image/Minions/" + HandMinions[x].name, typeof(Sprite)) as Sprite;
    }

    //공간을 비워줌
    public static void ReadyMinionReset()
    {
        ReadyMinion = null;
        ActivatedButtonNumber = 999;
    }

    //레이저를 쏴서 미니언을 소환하는 함수
    void SummonMinion(int pay = 2)
    {

        if(ReadyMinion != null && Cost >= pay) // 준비된 미니언이 있다면, 지불 할 조건이 된다면
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && Input.GetMouseButton(0) && hit.transform.tag == "Ground")
            {
                GameObject SummonedMinion = Instantiate(ReadyMinion, new Vector3(hit.point.x, 1, hit.point.z), Quaternion.identity);
                SummonedMinion.transform.parent = GameObject.Find("Summoned").transform;

                SelectReroll(ActivatedButtonNumber);

                //성공적으로 미니언을 배치후 공간을 비워줌
                ReadyMinionReset();
                Cost -= pay;
            }
        }
    }




}
