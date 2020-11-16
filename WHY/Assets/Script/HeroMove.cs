using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HeroMove : MonoBehaviour
{
    private Animator anim;

    NavMeshAgent agent;

    [SerializeField]
    private float speed = 4f;
    [SerializeField]
    private float Powerspeed = 15f;

    [SerializeField]
    Transform target;

    public LayerMask targetmask;

    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        isRun();
        agent.SetDestination(target.position);
    }

    void isRun()
    {
        Collider[] movecoll = Physics.OverlapSphere(transform.position, 50.0f, targetmask);

        if (movecoll.Length != 0)
        {
            Collider[] attackcoll = Physics.OverlapSphere(transform.position, 15.0f, targetmask);
            if (attackcoll.Length != 0)
            {
                anim.SetBool("isRun", false);
                anim.SetBool("isWalka", false);

                anim.SetBool("isAttack", true);
                agent.speed = 0.0f;
            }
            else
            {
                anim.SetBool("isWalka", false);
                anim.SetBool("isAttack", false);

                anim.SetBool("isRun", true);
                agent.speed = Powerspeed;
            }
        }
        else
        {
            anim.SetBool("isRun", false);
            anim.SetBool("isAttack", false);

            anim.SetBool("isWalka", true);
            agent.speed = speed;
        }
    }

}
