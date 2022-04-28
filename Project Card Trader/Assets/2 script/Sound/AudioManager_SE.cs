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
    public void PlaySound00()
    {
        audioSource.Stop();
    }  
    
    public void PlaySound01()
    {
        audioSource.clip = listAudio[0];
        audioSource.Play();

        //  AudioManager_SE.instance.PlaySound01(); a metttre la où on joue le son

    }

    public void PlaySound02()
    {
        audioSource.clip = listAudio[1];
        audioSource.Play();
    }    
    
    
    public void PlaySound03()
    {
        audioSource.clip = listAudio[2];
        audioSource.Play();
    }

    public void PlaySound04()
    {
        audioSource.clip = listAudio[3];
        audioSource.Play();
    }

    public void PlaySound05()
    {
        audioSource.clip = listAudio[4];
        audioSource.Play();
    }

    public void PlaySound06()
    {
        audioSource.clip = listAudio[5];
        audioSource.Play();
    }

    public void PlaySound07()
    {
        audioSource.clip = listAudio[6];
        audioSource.Play();
    }

    public void PlaySound08()
    {
        audioSource.clip = listAudio[7];
        audioSource.Play();
    }

    public void PlaySound09()
    {
        audioSource.clip = listAudio[8];
        audioSource.Play();
    }

    public void PlaySound10()
    {
        audioSource.clip = listAudio[9];
        audioSource.Play();
    }

    public void PlaySound11()
    {
        audioSource.clip = listAudio[10];
        audioSource.Play();
    }

    public void PlaySound12()
    {
        audioSource.clip = listAudio[11];
        audioSource.Play();
    }

    public void PlaySound13()
    {
        audioSource.clip = listAudio[12];
        audioSource.Play();
    }

    public void PlaySound14()
    {
        audioSource.clip = listAudio[13];
        audioSource.Play();
    }

    public void PlaySound15()
    {
        audioSource.clip = listAudio[14];
        audioSource.Play();
    }

    public void PlaySound16()
    {
        audioSource.clip = listAudio[15];
        audioSource.Play();
    }

    public void PlaySound17()
    {
        audioSource.clip = listAudio[16];
        audioSource.Play();
    }



}
