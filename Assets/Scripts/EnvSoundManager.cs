using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Audio;

public class EnvSoundManager : MonoBehaviour
{
    public AudioSource EnvAudioSource;

    [SerializeField] private AudioClip menuClip;
    [SerializeField] private AudioClip gameClip;

    // Start is called before the first frame update
    void Start()
    {
        EnvAudioSource = GameObject.Find("Env").GetComponent<AudioSource>();
        EnvAudioSource.loop = true;

        Assert.IsNotNull(EnvAudioSource);
        Assert.IsNotNull(menuClip);
        Assert.IsNotNull(gameClip);
    }

    public void PlayMenuMusic()
    {
        EnvAudioSource.clip = menuClip;
        EnvAudioSource.Play();
    }

    public void PlayGameMusic()
    {
        EnvAudioSource.clip = gameClip;
        EnvAudioSource.Play();
    }

    public void PauseMusic()
    {
        EnvAudioSource.Pause();
    }
    public void ResumeMusic()
    {
        EnvAudioSource.UnPause();
    }
    public void StopMusic()
    {
        EnvAudioSource.Stop();
    }
}
