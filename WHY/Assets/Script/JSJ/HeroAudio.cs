using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAudio : MonoBehaviour
{
    public AudioClip Attack;

    AudioSource myAudio;

    void Start()
    {
        myAudio = GetComponent<AudioSource>();
    }

    //캐릭터 공격 사운드 관리
    public void HeroAttackSound()
    {
        myAudio.PlayOneShot(Attack);
    }
}
