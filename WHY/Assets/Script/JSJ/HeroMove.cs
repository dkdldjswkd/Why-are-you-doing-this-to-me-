using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HeroMove : MonoBehaviour
{
    private Animator anim;

    NavMeshAgent agent;
    [SerializeField]
    private GameObject attackcollision;   //어택콜라이더

    [SerializeField]
    private float speed = 4f;   //처음 스피드
    [SerializeField]
    private float Powerspeed = 15f; //목표 발견 스피드

    public float maxhp;   //최대체력
    public float hp;   //현재체력체력

    [SerializeField]
    Transform MainTarget;   //최종 목표지점
    [SerializeField]
    Transform subtarget;    //중간 몬스터만나면 타겟변경

    public LayerMask targetmask;    //추격용마스크

    void Start()
    {
        MainTarget = TOPUIManager.Instance.MainTarget;
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();

        subtarget = MainTarget;
    }

    void Update()
    {
        isRun();
        agent.SetDestination(subtarget.position);
    }

    void isRun()
    {
        Collider[] attackcoll = Physics.OverlapSphere(transform.position, 15.0f, targetmask);
        if (attackcoll.Length != 0)
        {
            //print("어택 배열 수 :" + attackcoll.Length);
            //for (int i = 0; i < attackcoll.Length; i++)
            //{
            //    print(i + "번째 어택 콜라이더 :" + attackcoll[i].ToString());
            //}

            subtarget = attackcoll[attackcoll.Length - 1].transform;

            anim.SetBool("isRun", false);
            anim.SetBool("isWalka", false);

            anim.SetBool("isAttack", true);
            
            agent.speed = 0.0f;
        }
        else
        {
            Collider[] movecoll = Physics.OverlapSphere(transform.position, 50.0f, targetmask);
            if (movecoll.Length != 0)
            {
                //print("런 배열 수 :" + movecoll.Length);
                //for (int i = 0; i < movecoll.Length; i++)
                //{
                //    print(i + "번째 런 콜라이더 :" + movecoll[i].ToString());
                //}
                subtarget = movecoll[movecoll.Length - 1].transform;
                anim.SetBool("isWalka", false);
                anim.SetBool("isAttack", false);

                anim.SetBool("isRun", true);
                agent.speed = Powerspeed;
            }
            else
            {
                anim.SetBool("isRun", false);
                anim.SetBool("isAttack", false);

                anim.SetBool("isWalka", true);
                agent.speed = speed;

                subtarget = MainTarget;
            }
        }
    }

    //공격때 공격 콜라이더 생성
    public void OnAttack()
    {
        attackcollision.SetActive(true);
    }

    //데미지를 받을시
    public void TakeDamage(float damge)
    {
        hp -= damge;
        StartCoroutine("OnHittColor");
    }

    public IEnumerator OnHittColor()
    {
        yield return new WaitForSeconds(0.1f);
    }

    public void OnAttackAudio(int value)
    {
        HeroAudio.Instance.HeroAttackSound(value);
    }


}


