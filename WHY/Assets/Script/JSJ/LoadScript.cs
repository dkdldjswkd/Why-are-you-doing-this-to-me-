using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadScript : MonoBehaviour
{
    Transform Target;
    [SerializeField]GameObject AttackCollision;

    public float maxhp = 1;
    public float hp = 1;

    // Start is called before the first frame update
    void Start()
    {
        if( null !=GameObject.FindWithTag("Warrior"))
        Target = GameObject.FindWithTag("Warrior").transform;

        TOPUIManager.Instance.mapheroup();
    }

    // Update is called once per frame
    void Update()
    {
        if (Target != null)
        {
            transform.LookAt(new Vector3(Target.transform.position.x,gameObject.transform.position.y,Target.transform.position.z));
        }
        else
        {
            if (null != GameObject.FindWithTag("Warrior"))
                Target = GameObject.FindWithTag("Warrior").transform;
        }
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


    private void OnAttackCollision()
    {
        AttackCollision.SetActive(true);
    }

    private void OffAttackCollision()
    {
        AttackCollision.SetActive(false);
    }
}
