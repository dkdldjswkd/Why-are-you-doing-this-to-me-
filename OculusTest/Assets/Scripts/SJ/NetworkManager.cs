using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.SceneManagement;
using Photon.Realtime;
using Photon.Pun;
using ExitGames.Client.Photon;

public class NetworkManager : MonoBehaviourPunCallbacks, IOnEventCallback
{
    private static NetworkManager _instance;

    public static NetworkManager Instance
    {
        get
        {
            if (_instance == null)  //유니티에서 찾음
            {
                _instance = FindObjectOfType<NetworkManager>();
            }
            if (_instance == null)  //그래도 못찾으면 새로운 오브젝트를 만들어서 컴포넌트를 넣음
            {
                var go = new GameObject(nameof(NetworkManager));
                go.AddComponent<NetworkManager>();
            }
            return _instance;
        }
    }

    bool vr = false;

    public void Onvr()
    {
        XRSettings.LoadDeviceByName("Oculus");
        XRSettings.enabled = true;
        vr = true;
    }

    public void GameStart()
    {
        if (vr)
        {
            GameManager.Instance.OnVR();
        }
        else
        {
            GameManager.Instance.OffVR();
        }
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        StartCoroutine(WaitForIt());
    }

    public void OnEvent(EventData photonEvent)
    {
        if (photonEvent.Code == 0)
        {
            object[] data = (object[])photonEvent.CustomData;
            for (int i = 0; i < data.Length; i++) print(data[i]);
        }
    }

    public void Connect() => PhotonNetwork.ConnectUsingSettings();  //서버의 접속

    public override void OnConnectedToMaster()  //위 서버 접속후 콜백함수
    {
        print("서버접속");
        PhotonNetwork.JoinOrCreateRoom("RoomName", new RoomOptions { MaxPlayers = 2 }, null);
    }

    public override void OnJoinedRoom() //위에 방 접속후 콜백함수
    {
        Spawn();
    }

    void Update()
    {
    }

    public override void OnDisconnected(DisconnectCause cause)  //포톤에 연결 해제되면 콜백함수
    {
        print("접속해제");
    }

    public void Spawn()
    {
        SceneManager.LoadScene("Game");
    }

    IEnumerator WaitForIt()
    {
        vr = true;
        Connect();
        yield return new WaitForSeconds(5.0f);
        SceneManager.LoadScene("Game");
    }

}
