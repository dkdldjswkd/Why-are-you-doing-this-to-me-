using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController_mouse : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    GameObject tmp;
    GameObject tmp2;

    // Start is called before the first frame update
    void Start()
    {
        transform.localPosition = new Vector3(0, 0, 3);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
            transform.localPosition = new Vector3(0, 0, 3);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            tmp = GameObject.Find("Line(Clone)");
            tmp2 = GameObject.Find("new Line");
            if(tmp != null)
            {
                Destroy(tmp);
            }   
            if(tmp2 != null)
            {
                Destroy(tmp2);
            }

            LineScript.TemplateClear();
        }

        float MouseX = Input.GetAxisRaw("Mouse X") * moveSpeed * Time.deltaTime;
        float MouseY = Input.GetAxisRaw("Mouse Y") * moveSpeed * Time.deltaTime;

        transform.Translate(MouseX, MouseY, 0);
    }
}
