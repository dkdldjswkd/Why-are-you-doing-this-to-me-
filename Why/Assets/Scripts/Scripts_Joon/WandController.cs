using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WandController : MonoBehaviour
{

    float MoveSpeed = 3;

    // Update is called once per frame
    void Update()
    {
        float PosX = MoveSpeed * Time.deltaTime * Input.GetAxisRaw("Horizontal");
        float PosY = MoveSpeed * Time.deltaTime * Input.GetAxisRaw("Vertical");
        float PosZ = 0;
        if (Input.GetKey(KeyCode.Keypad8))
            PosZ = 1;
        else if (Input.GetKey(KeyCode.Keypad2))
            PosZ = -1;
        PosZ *= MoveSpeed * Time.deltaTime;
        Vector3 MovePosition = new Vector3(PosX ,PosY, PosZ);



        gameObject.transform.position += MovePosition;
    }
}
