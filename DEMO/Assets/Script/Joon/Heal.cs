using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Monster"))
        {
            //상대 스크립트에 대미지입히는 스크립트로
            other.GetComponent<LoadScript>().TakeDamage(-200);
        }
    }

    private void Start()
    {
        Destroy(gameObject, 1f);
    }
}
