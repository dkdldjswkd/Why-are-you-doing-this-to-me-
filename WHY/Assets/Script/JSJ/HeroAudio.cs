using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAudio : MonoBehaviour
{
    public AudioClip Attack;
    public AudioClip LoogAttack;

    AudioSource myAudio;

    public static HeroAudio Instance; //static으로 선언하면 동적할당 말고 정적할당으로 선언됨.
    void Awake()
    {
        if (HeroAudio.Instance == null)  //거기에 아무 값이 없다면
            HeroAudio.Instance = this;   //SoundManager.Instance에 나 자신을 집어넣음
    }

    void Start()
    {
        myAudio = GetComponent<AudioSource>();
    }

    //캐릭터 공격 사운드 관리
    public void HeroAttackSound(int value)
    {
        myAudio.Stop();
        if (value == 1)
        {
            myAudio.PlayOneShot(Attack);
        }
        if (value == 2)
        {
            myAudio.PlayOneShot(LoogAttack);
        }
    }
}
