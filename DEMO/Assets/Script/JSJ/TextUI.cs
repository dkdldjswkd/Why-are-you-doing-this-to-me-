using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextUI : MonoBehaviour
{
    private static TextUI _instance;

    public static TextUI Instance
    {
        get
        {
            if (_instance == null)  //유니티에서 찾음
            {
                _instance = FindObjectOfType<TextUI>();
            }
            if (_instance == null)  //그래도 못찾으면 새로운 오브젝트를 만들어서 컴포넌트를 넣음
            {
                var go = new GameObject(nameof(TextUI));
                go.AddComponent<TextUI>();
            }
            return _instance;
        }
    }
    public GameObject TextBox;
    public Text nametx;
    public Text tx;

    public struct TextManager
    {
        public int imagecode;
        public string text;

        public TextManager(int imagecode, string text)
        {
            this.imagecode = imagecode;
            this.text = text;
        }
    };

    public Sprite[] sprites;
    List<TextManager> textlist = new List<TextManager>();

    public Image image;
    public Image fade;

    //텍스트 순서
    int texttime;

    float time = 0f;
    float F_time = 1f;

    void Start()
    {
        fade.gameObject.SetActive(true);
        texttime = 0;

        //0은 ???이미지 처음
        textlist.Add(new TextManager(0, "헥..헥..헥....."));

        //1는 멍멍기사
        textlist.Add(new TextManager(0, "어서 마왕님께 알려야해!! 헥..헥.."));
        textlist.Add(new TextManager(1, "마왕님!!!"));

        //2은 마왕
        textlist.Add(new TextManager(2, "멍멍기사 어서오고~"));
        textlist.Add(new TextManager(2, "근데 왜 이렇게 힘들게 뛰어온거야?"));

        //1는 멍멍기사
        textlist.Add(new TextManager(1, "용사놈들이 지금 쳐들어오고 있습니다 어서 도망가셔야 합니다!."));

        //2은 마왕
        textlist.Add(new TextManager(2, "왜 어째서 쳐들어 오는거야?? 나 나쁜짓이라도 한거야??"));

        //1는 멍멍기사
        textlist.Add(new TextManager(1, "그럴리가 없잖습니까!!! 마왕님이 얼마나 착하신데요!!"));
        textlist.Add(new TextManager(1, "용사놈들이 계략을 부리고 저희를 잡으러 온것같습니다."));
        textlist.Add(new TextManager(1, "이럴 시간이 없습니다. 마왕님은 어서 피신하십시요."));
        textlist.Add(new TextManager(1, "모두 전투준비!!"));

        nextText();
    }

    public void nextText()
    {
        if (textlist[texttime].imagecode == 0)
        {
            image.sprite = sprites[0];
            nametx.text = "???";
        }
        else if (textlist[texttime].imagecode == 1)
        {
            image.sprite = sprites[1];
            nametx.text = "멍멍기사";
        }
        else
        {
            image.sprite = sprites[2];
            nametx.text = "마왕";
        }

        tx.text = textlist[texttime].text;
    }
    public void setbox()
    {
        TextBox.SetActive(true);
    }

    public void texttimeUp()
    {
        print(texttime);
        if(texttime==10)
        {
            SceneManager.LoadScene(2);
        }
        texttime++;
        nextText();
        if(texttime == 2)
        {
            Dogmove.Instance.run();
            TextBox.SetActive(false);
        }
    }
    public void skip()
    {
        SceneManager.LoadScene(2);
    }

    public int gettexttime()
    {
        return texttime;
    }

    public void Faid()
    {
        StartCoroutine(FadeFlow());
    }
    IEnumerator FadeFlow()
    {
        Color alpha = fade.color;
        while(alpha.a>0f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(1, 0, time);
            fade.color = alpha;
        }

        if (alpha.a==0)
        {
            fade.gameObject.SetActive(false);
        }
      
        yield return null;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(texttime>=2)
        {
            if (fade.gameObject.activeSelf)
            {
                Faid();
            }
        }
    }
}
