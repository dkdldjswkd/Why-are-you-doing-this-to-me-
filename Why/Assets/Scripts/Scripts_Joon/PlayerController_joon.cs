using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_joon : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    Rigidbody myRigid;
    // Start is called before the first frame update
    void Start()
    {
        myRigid = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float InputX = Input.GetAxisRaw("Horizontal");
        float InputZ = Input.GetAxisRaw("Vertical");

        Vector3 Velocity = new Vector3(InputX, 0, InputZ).normalized * moveSpeed;

        myRigid.MovePosition(transform.position + Velocity * Time.deltaTime);

        if (Input.GetKey(KeyCode.Q))
        {
            myRigid.MoveRotation(transform.rotation * Quaternion.Euler(new Vector3(0,-1,0)));
        }
        else if (Input.GetKey(KeyCode.E))
        {
            myRigid.MoveRotation(transform.rotation * Quaternion.Euler(new Vector3(0, 1, 0)));
        }
    }
}
