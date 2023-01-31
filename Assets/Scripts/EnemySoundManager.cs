using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Audio;

public class EnemySoundManager : MonoBehaviour
{
    public AudioSource enemyAudioSource;

    [SerializeField] private AudioClip lightAttackClip;
    [SerializeField] private AudioClip heavyAttackClip;
    [SerializeField] private AudioClip deathClip;
    void Start()
    {
        enemyAudioSource = GetComponent<AudioSource>();

        Assert.IsNotNull(enemyAudioSource);
        Assert.IsNotNull(lightAttackClip);
        Assert.IsNotNull(heavyAttackClip);
        Assert.IsNotNull(deathClip);
    }

	public void PlayLightAttackSound()
	{
		enemyAudioSource.PlayOneShot(lightAttackClip);
	}
	public void PlayHeavyAttackSound()
	{
		enemyAudioSource.PlayOneShot(heavyAttackClip);
	}
	public void PlayDeathSound()
	{
		enemyAudioSource.PlayOneShot(deathClip);
	}
}
