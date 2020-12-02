using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TOPUIManager : MonoBehaviour
{
    private static TOPUIManager _instance;

    public static TOPUIManager Instance
    {
        get
        {
            if (_instance == null)  //유니티에서 찾음
            {
                _instance = FindObjectOfType<TOPUIManager>();
            }
            if (_instance == null)  //그래도 못찾으면 새로운 오브젝트를 만들어서 컴포넌트를 넣음
            {
                var go = new GameObject(nameof(TOPUIManager));
                go.AddComponent<TOPUIManager>();
            }
            return _instance;
        }
    }

    public int raund;   //현제 라운드
    public int SummonsCount;    //오고있는 수

    public Image start;    //스타트위치와 크기
    public Image end;  //골인위치와 크기

    public GameObject canvasbaby;   //캔버스 자식객체로 만들기용
    public GameObject topui;   //TOPUI 이미지용
    Image image;    //위 UI이미지에서 이미지 옵션용
    Color color;    //위 이미지 옵션에서 컬러 값 조정용

    bool setA;  //알파값 조절할지 정하기

    public GameObject startplane;   //소환 첫 위치
    public Transform MainTarget;    //소환된 영웅들이 가야할 최종목표지점
    public int MapHero; //소환된 영웅 수

    void Start()
    {
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        setA = false;
        image = topui.GetComponent<Image>();
        color = image.color;
        topui.SetActive(false);
        raund = 1;  //라운드는 1로 설정 애초에 0라운드는 말이 안되고 아래 나머지 값때문에 영웅이 소환됨.
        SummonsCount = 0;

        MapHero = 0;
    }

    void Update()
    {
        if (topui.activeSelf)   //이미지가 활성화 되어있고
        {
            if (setA)   //모든 유닛이 사라져서 활성화가 되었다면
            {
                Color color = image.color;   //이미지 옵션에서 컬러 값 조정
                color.a -= 0.005f;
                image.color = color;
                if (color.a <= 0)
                {
                    setA = false;
                    topui.SetActive(false);
                }
            }
        }
    }

    public void heroProduce()   //용사 생성 10라운드 마다 영웅 캐릭 소환(버튼용)
    {
        if (topui.activeSelf == false) TOPUIOn();    //소환했을때 이미지가 없다면 띄우기

        if (raund % 10 == 0)
        {
            switch (Random.Range(0, 2))
            {
                case 0:
                    Summons(4);
                    break;
                case 1:
                    Summons(5);
                    break;
            }
        }
        else
        {
            switch (Random.Range(0, 4))
            {
                case 0:
                    Summons(0);
                    break;
                case 1:
                    Summons(1);
                    break;
                case 2:
                    Summons(2);
                    break;
                case 3:
                    Summons(3);
                    break;

            }
        }
    }

    void Summons(int value) //어떤영웅을 소환할지 판단 (0 ~ 1 남자 캐릭),  (2 ~ 3 여자 캐릭), (4 ~ 5 영웅 캐릭)
    {
        switch (value)
        {
            case 0:
                //Resources.Load 유니티에서 제공해주는 소스로 에셋 폴더에 Resources폴더를 생성하고 
                //그안에 있는 프리펩들을 이름만으로 쉽게 복사해줌
                //복사용 게임 오브젝트를 생성하고 이름과 경로를 통해 프리펩을 잡은뒤 강제로 as 로 형변환 해준다.
                //SummonslocalScale함수는 복사된 게임 오브젝트가 생성되었는지 확인한 뒤 canvasbaby라는 게임오브젝트(캔버스넣음) 자식객체로 위치로 생성해준다.
                //Scale 크기를 변경하고 캔버스 좌표는 로컬 좌표계이므로 localPosition으로 위치를 변경 한다.
                GameObject hr1 = Instantiate(Resources.Load("Prefab/hero/hero1")) as GameObject;
                SummonslocalScale(hr1);
                break;
            case 1:
                GameObject hr2 = Instantiate(Resources.Load("Prefab/hero/hero2")) as GameObject;
                SummonslocalScale(hr2);
                break;
            case 2:
                GameObject hr3 = Instantiate(Resources.Load("Prefab/hero/hero3")) as GameObject;
                SummonslocalScale(hr3);
                break;
            case 3:
                GameObject hr4 = Instantiate(Resources.Load("Prefab/hero/hero4")) as GameObject;
                SummonslocalScale(hr4);
                break;
            case 4:
                GameObject hr5 = Instantiate(Resources.Load("Prefab/hero/hero5")) as GameObject;
                SummonslocalScale(hr5);
                break;
            case 5:
                GameObject hr6 = Instantiate(Resources.Load("Prefab/hero/hero6")) as GameObject;
                SummonslocalScale(hr6);
                break;
        }
    }

    void SummonslocalScale(GameObject go)   //좌표와 크기
    {
        if (go != null) go.transform.parent = canvasbaby.transform;
        go.transform.localPosition = start.transform.localPosition;
        //소환된 수를 증가
        SummonsCount++;
    }
    public void TOPUIOn()
    {
        topui.SetActive(true);
        Color color = image.color;   //이미지 옵션에서 컬러 값 조정
        color.a = 1.0f;
        image.color = color;
    }
    //현제 소환된 수 줄이기 모두 사라지면 이미지 서서히 사라짐
    public void DwonSummonsCount(int herotype)
    {
        MapHero++;
        SummonsCount--;
        if(SummonsCount==0)
        {
            setA = true;
        }
        print("반환 :" + herotype);

        if (herotype <= 2)
        {
            GameObject ManHero = Instantiate(Resources.Load("Prefab/hero/ManWarrior")) as GameObject;
            ManHero.transform.position = startplane.transform.position;
        }
        else
        {
            GameObject WomanHero = Instantiate(Resources.Load("Prefab/hero/WomanWarrior")) as GameObject;
            WomanHero.transform.position = startplane.transform.position;
        }
           
    }

    //현제 소환된 수
    public int getSummonsCount()
    {
        return SummonsCount;
    }
}