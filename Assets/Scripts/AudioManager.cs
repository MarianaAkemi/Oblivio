using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("--------------------------------")]
    public static AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("--------------------------------")]
    public AudioClip Background;
    public AudioClip Death;
    public AudioClip CollectMemory;
    public AudioClip Door;
    public AudioClip Walking;

    private void OnCollisionEnter2D(Collision2D collision)
    {
            musicSource.clip = Background;
            musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
