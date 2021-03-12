using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputedMagic_joon : MonoBehaviour
{
    public static GameObject printMagic;
    public static Text tmpText;

    public static void setInputMagic(string canvasName = "Canvas", float locationX = 200, float locationY = 150)
    {
        //제스처를 출력할 객체 동적 생성 및 설정
        printMagic = new GameObject();
        printMagic.name = "ShowMyMagic";
        printMagic.AddComponent<Text>();
        printMagic.layer = 5;

        //객체의 Text 컴포넌트 설정
        tmpText = printMagic.GetComponent<Text>();
        tmpText.text = "Null";
        tmpText.font = Resources.GetBuiltinResource<Font>("Arial.ttf"); //?
        tmpText.horizontalOverflow = HorizontalWrapMode.Overflow;

        //캔버스의 하위 객체로 설정
        GameObject canvas = GameObject.Find(canvasName);

        //객체의 transform 설정
        printMagic.transform.parent = canvas.transform;
        printMagic.transform.localPosition = new Vector3(locationX, locationY, 0);
        printMagic.transform.localScale = new Vector3(1, 1, 1);
    }

    public static void setMagicText(string Gesture = "Null")
    {
        tmpText = printMagic.GetComponent<Text>();
        tmpText.text = Gesture;
    }
}
