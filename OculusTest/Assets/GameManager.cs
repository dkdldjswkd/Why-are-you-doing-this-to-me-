using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)  //유니티에서 찾음
            {
                _instance = FindObjectOfType<GameManager>();
            }
            if (_instance == null)  //그래도 못찾으면 새로운 오브젝트를 만들어서 컴포넌트를 넣음
            {
                var go = new GameObject(nameof(GameManager));
                go.AddComponent<GameManager>();
            }
            return _instance;
        }
    }

    public GameObject DefensePackage;
    public GameObject VRPackage;

    // Start is called before the first frame update
    void Start()
    {
        NetworkManager.Instance.GameStart();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnVR()
    {
        DefensePackage.SetActive(false);
        VRPackage.SetActive(true);
    }

    public void OffVR()
    {
        VRPackage.SetActive(false);
        DefensePackage.SetActive(true);
    }
}
