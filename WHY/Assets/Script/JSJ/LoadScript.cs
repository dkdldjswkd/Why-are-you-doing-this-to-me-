using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadScript : MonoBehaviour
{
    public float maxhp = 1;
    public float hp = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damge)
    {
        hp -= damge;
        StartCoroutine("OnHittColor");
    }

    public IEnumerator OnHittColor()
    {
        yield return new WaitForSeconds(0.1f);
    }
}
