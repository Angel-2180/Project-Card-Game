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


    public void PlayBGMRandom()
    {
        audioSource.clip = listAudio[Random.Range(0, listAudio.Length)];
        audioSource.Play();
    }

    public void PlayBGM01()
    {
        audioSource.clip = listAudio[0];
        audioSource.Play();
    }

    public void PlayBGM02()
    {
        audioSource.clip = listAudio[1];
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
    public void PlayBGM07()
    {
        audioSource.clip = listAudio[6];
        audioSource.Play();
    }




}
