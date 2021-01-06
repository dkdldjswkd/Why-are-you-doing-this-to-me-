using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Warrior"))
            other.GetComponent<HeroMove>().TakeDamage(200);

      
    }

    private void Start()
    {
        Destroy(gameObject, 1);
    }

}
