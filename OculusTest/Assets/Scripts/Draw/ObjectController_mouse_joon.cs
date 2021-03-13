using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController_mouse_joon : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    GameObject tmp;

    // Start is called before the first frame update
    void Start()
    {
        transform.localPosition = new Vector3(0, 0.5f, 3.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
            transform.localPosition = new Vector3(0, 0.5f, 3.5f);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            tmp = GameObject.Find("Line(Clone)");
            if (tmp != null)
                Destroy(tmp);
            tmp = GameObject.Find("new Line");
            if (tmp != null)
                Destroy(tmp);

            //LineScript_joon.TemplateClear();
        }

        float MouseX = Input.GetAxisRaw("Mouse X") * moveSpeed * Time.deltaTime;
        float MouseY = Input.GetAxisRaw("Mouse Y") * moveSpeed * Time.deltaTime;

        transform.Translate(MouseX, MouseY, 0);
    }
}
