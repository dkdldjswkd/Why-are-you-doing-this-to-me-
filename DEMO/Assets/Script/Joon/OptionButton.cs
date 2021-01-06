using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionButton : MonoBehaviour
{
    [SerializeField] GameObject OptionCanvas;
    // Start is called before the first frame update

    private void Start()
    {
        OptionCanvas.SetActive(false);
    }
    public void OpenOption()
    {
        if(OptionCanvas.activeSelf == true)
        {
            OptionCanvas.SetActive(false);
        }
        else
        {
            OptionCanvas.SetActive(true);
        }
    }
}
