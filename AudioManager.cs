using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using Random = UnityEngine.Random;


public class AudioManager :MonoBehaviour
{

	public Sound[] sounds;

	private void Awake()
	{
		foreach (var s in sounds)
		{
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;

			s.source.volume = s.volume;
			s.source.pitch = s.pitch;
		}  
	}

	public void Play(String name)
	{
		Sound s = Array.Find(sounds, sounds => sounds.name == name);
		s.source.pitch = s.pitch;

		s.source.Play();
	}

	public void Play(Sound sound)
	{
		sound.source.pitch = sound.pitch;

		sound.source.Play();
		
	}

	public void PlayWithExtraAudioSource(string name)
	{
		Sound s = Array.Find(sounds, sounds => sounds.name == name);
		s.source = gameObject.AddComponent<AudioSource>();
		s.source.clip = s.clip;
		s.source.volume = s.volume;
		s.source.pitch = s.pitch;
		s.source.Play();
		StartCoroutine(deleteSource(s.source, s.clip.length));

	}

	public void PlayRandomPitch(string name, float min, float max)
	{
		Sound s = Array.Find(sounds, sounds => sounds.name == name);
		s.source.pitch = s.pitch;

		float range = Random.Range(min, max);
		s.source.pitch += range;
		s.source.Play();


	}

	public void Stop(AudioSource audioSource = null)
	{
		if (audioSource != null)
		{
			audioSource.Stop();
		}

	}
	
	public void Stop(String name)
	{
		Sound s = Array.Find(sounds, sounds => sounds.name == name);
		s.source.pitch = s.pitch;
		if (s.source.isPlaying)
			s.source.Stop();

	}

	IEnumerator deleteSource(AudioSource s, float length)
	{
		yield return new WaitForSeconds(length);
		Destroy(s);
	}

}
