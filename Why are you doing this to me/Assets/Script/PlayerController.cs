using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    Rigidbody PlayerRigid;
    [SerializeField] float PlayerSpeed;
    // Start is called before the first frame update
    void Start()
    {
        PlayerRigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        float MoveX = Input.GetAxisRaw("Horizontal");
        float MoveZ = Input.GetAxisRaw("Vertical");
        Vector3 Velocity = new Vector3(MoveX, 0, MoveZ).normalized * PlayerSpeed;

        PlayerRigid.MovePosition(transform.position + Velocity * Time.deltaTime);
        
    }
}
