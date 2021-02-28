using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicText_joon : MonoBehaviour
{
    public static Dictionary<string, string> Magics = new Dictionary<string, string>() { 
        {"좌하 우 좌하 ", "번개"},

        {"우 하 ", "ㄱ"},

        {"하 우 ", "ㄴ"},

        {"좌 하 우 ", "ㄷ" },

        { "우 하 좌 상 ", "ㅁ(시계방향)"}
    };

    private void Start()
    {
        //Magics.Add("좌하 우 좌하 ", "번개");

        //Magics.Add("우 하 ", "ㄱ");

        //Magics.Add("하 우 ", "ㄴ");

        //Magics.Add("좌 하 우 ", "ㄷ");

        //Magics.Add("우 하 좌 상 ", "ㅁ(시계방향)");

        Magics.Add("좌하 하 우 우상 상 좌 ", "반시계 원");
        Magics.Add("좌하 우하 우 우상 좌상 좌 ", "반시계 원");
        Magics.Add("좌하 하 우하 우 우상 상 좌 ", "반시계 원");
        Magics.Add("좌하 하 우하 우 우상 상 좌상 ", "반시계 원");
        Magics.Add("좌하 하 우하 우 우상 좌상 좌 ", "반시계 원");
        Magics.Add("좌하 우하 우 우상 상 좌상 좌 ", "반시계 원");
        Magics.Add("좌하 하 우하 우 우상 상 좌상 좌 ", "반시계 원");
        Magics.Add("좌 좌하 하 우하 우 우상 상 좌상 좌 ", "반시계 원");
        Magics.Add("좌하 하 우하 우 우상 상 좌상 좌 좌상 ", "반시계 원");

        Magics.Add("하 우상 좌 우하 좌상 ", "별");
        Magics.Add("좌하 우상 좌 우하 상 ", "별");
        Magics.Add("좌하 우상 좌 우하 좌상 ", "별");
        Magics.Add("하 우상 좌 우하 상 좌상 ", "별");
        Magics.Add("좌하 우상 우 좌 우하 상  ", "별");
        Magics.Add("좌하 우상 좌 우하 좌상 상 ", "별");
        Magics.Add("좌하 하 우상 좌 우하 좌상 ", "별");
        Magics.Add("좌하 우 좌 우하 우하 상 좌상 ", "별");
        Magics.Add("하 우상 우상 우 좌 우하 우하 좌상 ", "별");
        Magics.Add("좌하 우상 우 우상 좌 우하 우 좌상 상 ", "별");
        Magics.Add("좌하 하 좌하 우 우 우상 우 우상 좌 우하 우하 상 좌상 ", "별");
    }

    //Dictionary[Key]로 Value를 취득할 수 있다.
    public static void MagicChecking(string inputed)
    {
        string whatMagic;
        if (Magics.TryGetValue(inputed, out whatMagic))
            print(whatMagic);
        else
            print("일치하는 마법이 없습니다.");

        //if (Magics[inputed] == null)
        //    print("일치하는 문자 없음");
        //else
        //    print(Magics[inputed]);
    }



    ////직선이 2개인 마법문자들
    //public static List<List<string>> _2sticks1 = new List<List<string>>();//산 모양
    //public static List<List<string>> _2sticks2 = new List<List<string>>();

    ////직선이 3개인 마법문자들
    //public static List<List<string>> _3sticks1 = new List<List<string>>();//번개 모양
    //public static List<List<string>> _3sticks2 = new List<List<string>>();
    //public static List<List<string>> _3sticks3 = new List<List<string>>();

    ////직선이 4개인 마법문자들
    //public static List<List<string>> _4sticks1 = new List<List<string>>();

    ////직선이 5개인 마법문자들
    //public static List<List<string>> _5sticks1 = new List<List<string>>();

    //void Start()
    //{
    //    AddList(_2sticks1, "우상 우하");
    //}

    //void AddList(List<List<string>> list, string word)
    //{
    //    string[] split_word;
    //    split_word = word.Split(' ');

    //    List<string> l = new List<string>();
    //    for (int i = 0; i < split_word.Length; i++)
    //    {
    //        l.Add(split_word[i]);
    //    }

    //    list.Add(l);

    //    for (int i = 0; i < list.Count; i++)
    //    {
    //        for (int j = 0; j < list[i].Count; j++)
    //        {
    //            print(list[i][j]);
    //        }
    //    }
    //}
}
