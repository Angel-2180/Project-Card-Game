using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager_BGM : MonoBehaviour
{
    public AudioClip[] listAudio;
    public AudioSource audioSource;

    public static AudioManager_BGM instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de AudioFeedBack dans la scène");
        }

        instance = this;
    }


    public void PlayBGM00()
    {
        audioSource.Stop();

        //  AudioManager_BGM.instance.PlayBGM01(); a metttre la où on joue le son
    }

    public void PlayNext()
    {
        audioSource.clip = listAudio[Random.Range(0, listAudio.Length)];
        audioSource.Play();

        //  AudioManager_BGM.instance.PlayBGM01(); a metttre la où on joue le son
    }


    public void PlayBGM01()
    {
        //float rnd = Random.Range(0, 5);
        //rnd = Mathf.Round(rnd * 10) / 10;
        //Debug.Log("rnd");
        //<  >
        //if(rnd > 1)
        //{
        //    audioSource.clip = listAudio[0];
        //}
        //if ( 1 > rnd > 2)
        //{
        //    audioSource.clip = listAudio[0];
        //}


        audioSource.clip = listAudio[Random.Range(0, 6)];
        audioSource.Play();

        //  AudioManager_BGM.instance.PlayBGM01(); a metttre la où on joue le son
    }

    public void PlayBGM02()
    {
        audioSource.clip = listAudio[Random.Range(6, 8)];
        audioSource.Play();
    }

    public void PlayBGM03()
    {
        audioSource.clip = listAudio[2];
        audioSource.Play();
    }

    public void PlayBGM04()
    {
        audioSource.clip = listAudio[3];
        audioSource.Play();
    }

    public void PlayBGM05()
    {
        audioSource.clip = listAudio[4];
        audioSource.Play();
    }

    public void PlayBGM06()
    {
        audioSource.clip = listAudio[5];
        audioSource.Play();
    }

 

}
