using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager_SE : MonoBehaviour
{
    public AudioClip[] listAudio;
    public AudioSource audioSource;

    public static AudioManager_SE instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de AudioFeedBack dans la scène");
        }

        instance = this;
    }

    public void StopSound()
    {
        audioSource.Stop();
    }

    //public void PlayNext()
    //{
    //    for (int i = 1; i < listAudio.Length; i++)
    //    {
    //        audioSource.clip = listAudio[i+1])];
    //    audioSource.Play();
    //    }
    //    //  AudioManager_BGM.instance.PlayBGM01(); a metttre la où on joue le son
    //}

    public void PlaySERandom()
    {
        audioSource.clip = listAudio[Random.Range(0, listAudio.Length)];
        audioSource.Play();
    }

    public void Play_Battle_SFX_Buff()
    {
        audioSource.clip = listAudio[0];
        audioSource.Play();

        //  AudioManager_SE.instance.PlaySound01(); a metttre la où on joue le son
    }

    public void Play_Battle_SFX_Debuff()
    {
        audioSource.clip = listAudio[1];
        audioSource.Play();
    }

    public void Play_Card_Discard()
    {
        audioSource.clip = listAudio[2];
        audioSource.Play();
    }

    public void Play_Card_Draw()
    {
        audioSource.clip = listAudio[3];
        audioSource.Play();
    }

    public void Play_Card_Exhaust()
    {
        audioSource.clip = listAudio[4];
        audioSource.Play();
    }

    public void Play_Card_Select()
    {
        audioSource.clip = listAudio[5];
        audioSource.Play();
    }

    public void Play_Card_Hover()
    {
        audioSource.clip = listAudio[6];
        audioSource.Play();
    }

    public void Play_Event_BattleStart()
    {
        audioSource.clip = listAudio[7];
        audioSource.Play();
    }

    public void Play_Event_DealMoney()
    {
        audioSource.clip = listAudio[8];
        audioSource.Play();
    }

    public void Play_Event_DealVO()
    {
        audioSource.clip = listAudio[9];
        audioSource.Play();
    }

    public void Play_Event_EndDay()
    {
        audioSource.clip = listAudio[10];
        audioSource.Play();
    }

    public void Play_Event_EndTurn()
    {
        audioSource.clip = listAudio[11];
        audioSource.Play();
    }

    public void Play_Event_EnemyTurn()
    {
        audioSource.clip = listAudio[12];
        audioSource.Play();
    }

    public void Play_Event_PlayerTurn()
    {
        audioSource.clip = listAudio[13];
        audioSource.Play();
    }

    public void Play_UI_ButtonClick()
    {
        audioSource.clip = listAudio[14];
        audioSource.Play();
    }

    public void Play_UI_ButtonNo()
    {
        audioSource.clip = listAudio[15];
        audioSource.Play();
    }

    public void Play_UI_ButtonYes()
    {
        audioSource.clip = listAudio[16];
        audioSource.Play();
    }

    public void Play_UI_ViewDeck()
    {
        audioSource.clip = listAudio[16];
        audioSource.Play();
    }
}