using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroSoundManager : MonoBehaviour
{
    public static HeroSoundManager Instance; //static으로 선언하면 동적할당 말고 정적할당으로 선언됨.
    void Awake()
    {
        if (HeroSoundManager.Instance == null)  //거기에 아무 값이 없다면
            HeroSoundManager.Instance = this;   //SoundManager.Instance에 나 자신을 집어넣음
    }

    public HeroAudio[] heroAudio;

    public void OnSound(int value)
    {
        heroAudio[value].HeroAttackSound();
    }
}
