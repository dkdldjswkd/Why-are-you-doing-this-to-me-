using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.UI;

public class DefanceManager : MonoBehaviour
{
    public static float Cost; // 기물 구매, 래벨업에 상용되는 재화
    public static int Level; // 플레이어 레벨

    [SerializeField] GameObject Unit1;
    [SerializeField] GameObject Unit2;
    [SerializeField] GameObject Unit3;
    [SerializeField] GameObject Unit4;

    int MaxCost; // 최대 코스트 제한
    float Production; // 코스트 생성 속도


    [SerializeField] Text LevelText; // 플레이러 레벨을 화면에 나타내는 텍스트
    [SerializeField] Text CostText; // 코스트를 화면에 나타내는 텍스트

    void Start()
    {
        Cost = 0;
        if (Production == 0) Production = 1;
        if (MaxCost == 0) MaxCost = 10;
        Level = 1;
    }

    // Update is called once per frame
    void Update()
    {
        MakeCost();
        PrintLevel();
        SummonObject();
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

    void SummonObject()
    {
        //유닛 스포너 버튼을 누른게 참일경우
        if (SpawnerButton.ClickedCheck())
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // 메인카메라에서 스크린으로 쏘는 레이저, 마우스 포지션 좌표에
            RaycastHit hit;

            //좌클릭시, ray가 물체에 충돌했으며, 충돌한 물체의 tag가 ground 라면
            if (Physics.Raycast(ray, out hit) && Input.GetMouseButton(0) && hit.transform.tag == "Ground")
            {
                //돈이 1원 이상 있다면
                if (Cost >= 1)
                {                    
                    GameObject summondObject = null;

                    //활성화된 스포너 버튼
                    int tmp = SpawnerButton.whoClickedButton();
                    switch (tmp)
                    {
                        case 0:
                            summondObject = Instantiate(Unit1, new Vector3(hit.point.x, 1, hit.point.z), Quaternion.identity);
                            SpawnerButton.ClickedButton[tmp] = false; // 기물을 배치했으니 눌렸던 버튼 비활성화
                            SpawnerButton.showbuttonsState();
                            Cost--;
                            break;
                        case 1:
                            summondObject = Instantiate(Unit2, new Vector3(hit.point.x, 1, hit.point.z), Quaternion.identity);
                            SpawnerButton.ClickedButton[tmp] = false; // 기물을 배치했으니 눌렸던 버튼 비활성화
                            SpawnerButton.showbuttonsState();
                            Cost--;
                            break;
                        case 2:
                            summondObject = Instantiate(Unit3, new Vector3(hit.point.x, 1, hit.point.z), Quaternion.identity);
                            SpawnerButton.ClickedButton[tmp] = false; // 기물을 배치했으니 눌렸던 버튼 비활성화
                            SpawnerButton.showbuttonsState();
                            Cost--;
                            break;
                        case 3:
                            summondObject = Instantiate(Unit4, new Vector3(hit.point.x, 1, hit.point.z), Quaternion.identity);
                            SpawnerButton.ClickedButton[tmp] = false; // 기물을 배치했으니 눌렸던 버튼 비활성화
                            SpawnerButton.showbuttonsState();
                            Cost--;
                            break;

                        case 100:
                            print("스포너 버튼이 아무것도 눌려있지 않음");
                            break;
                    }


                }
                else
                {
                }
            }
        }
        

    }


}
