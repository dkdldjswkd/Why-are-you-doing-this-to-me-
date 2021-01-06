using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Dogmove : MonoBehaviour
{
    private static Dogmove _instance;

    public static Dogmove Instance
    {
        get
        {
            if (_instance == null)  //유니티에서 찾음
            {
                _instance = FindObjectOfType<Dogmove>();
            }
            if (_instance == null)  //그래도 못찾으면 새로운 오브젝트를 만들어서 컴포넌트를 넣음
            {
                var go = new GameObject(nameof(Dogmove));
                go.AddComponent<Dogmove>();
            }
            return _instance;
        }
    }

    NavMeshAgent agent;
    [SerializeField]
    Transform MainTarget;   //최종 목표지점
    public LayerMask targetmask;    //추격용마스크

    private Animator anim;
    public GameObject camera;

    bool ok;
    

    // Start is called before the first frame update
    void Start()
    {
        ok = true;
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(MainTarget.position);

        if (ok)
        {      
            Collider[] attackcoll = Physics.OverlapSphere(transform.position, 5.0f, targetmask);
            if (attackcoll.Length != 0)
            {
                camera.SetActive(true);
                anim.SetBool("onIdel", true);
                TextUI.Instance.setbox();
                TextUI.Instance.nextText();
            }
        }
    }
    public void run()
    {
        agent.speed = 5.0f;
    }
}
