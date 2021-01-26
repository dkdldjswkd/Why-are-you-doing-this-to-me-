using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckScript : MonoBehaviour
{
    Image image;

    void Start()
    {
        image = gameObject.GetComponent<Image>();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Line" && other.gameObject.tag == "PlayerLine")
        {
            image.color = Color.white;
        }
        else if (other.gameObject.tag == "Line")
        {
            image.color = Color.red;
        }
        else if (other.gameObject.tag == "PlayerLine")
        {
            image.color = Color.blue;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        image.color = Color.black;
    }

}
