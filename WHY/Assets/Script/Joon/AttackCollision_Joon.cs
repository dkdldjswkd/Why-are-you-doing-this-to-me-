using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollision_Joon : MonoBehaviour
{
    [SerializeField] int AttackDamage;

    //private void OnEnable()
    //{
    //    StartCoroutine("AutoDisable");
    //  //  gameObject.SetActive(false);
    //}

    //private IEnumerator AutoDisable()
    //{
    //    yield return new WaitForSeconds(1f);

    //    gameObject.SetActive(false);
    //}

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Warrior"))
        other.GetComponent<HeroMove>().TakeDamage(AttackDamage);
    }



}
