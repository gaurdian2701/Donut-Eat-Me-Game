using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Audio;

public class PlayerSoundManager : MonoBehaviour
{
	public AudioSource playerAudioSource;

	[SerializeField] private AudioClip spawnClip;
	[SerializeField] private AudioClip lightAttackClip;
	[SerializeField] private AudioClip heavyAttackClip;
	[SerializeField] private AudioClip hurtClip;
	[SerializeField] private AudioClip dodgeClip;
	[SerializeField] private AudioClip deathClip;
	void Start()
	{
		playerAudioSource = GetComponent<AudioSource>();

		Assert.IsNotNull(playerAudioSource);
		Assert.IsNotNull(spawnClip);
		Assert.IsNotNull(lightAttackClip);
		Assert.IsNotNull(heavyAttackClip);
		Assert.IsNotNull(hurtClip);
		Assert.IsNotNull(dodgeClip);
		Assert.IsNotNull(deathClip);
	}

	public void PlaySpawnSound()
    {
		if(spawnClip != null)
			playerAudioSource.PlayOneShot(spawnClip);
    }
	public void PlayLightAttackSound()
	{
		playerAudioSource.PlayOneShot(lightAttackClip);
	}
	public void PlayHeavyAttackSound()
	{
		playerAudioSource.PlayOneShot(heavyAttackClip);
	}
	public void PlayHurtSound()
	{
		playerAudioSource.PlayOneShot(hurtClip);
	}
	public void PlayDodgeSound()
	{
		playerAudioSource.PlayOneShot(dodgeClip);
	}
	public void PlayDeathSound()
	{
		playerAudioSource.PlayOneShot(deathClip);
	}
}