using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioFeedback : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip audioClip;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioClip;
    }

    public void PlayAudio()
    {
        audioSource.Play();
    }
}
