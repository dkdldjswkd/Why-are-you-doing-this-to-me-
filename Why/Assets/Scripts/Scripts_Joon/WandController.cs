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
        Vector3 MovePosition = new Vector3(PosX ,PosY, 0);

        gameObject.transform.position += MovePosition;

    }
}
