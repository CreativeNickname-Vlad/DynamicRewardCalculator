using UnityEngine.Audio;
using System;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
	/// <summary>
	/// This Audio System was added to the project for the reason to help
	/// with the fluidity of the UI menuin and to make it more pleasing to use
	/// Use to play - AudioManager.Play("Insert_NameOfSound_Here");
	/// Use to stop - AudioManager.Stop("Insert_NameOfSound_Here");
	/// </summary>
	/// 

	[Header("Audio Set Up")]
	private static AudioManager instance;
	public AudioMixerGroup mixerGroup;

	[SerializeField] private Sound[] sounds;

	private Dictionary<string, Sound> _soundDictionary;

	void Awake()
	{
		if (instance != null)
		{
			Destroy(gameObject);
			return;
		}

		instance = this;
		DontDestroyOnLoad(gameObject);

		// Create dictionary - preallocating length
		_soundDictionary = new Dictionary<string, Sound>(sounds.Length);

		foreach (Sound s in sounds)
		{
			Sound sound = new Sound();
			sound.source = gameObject.AddComponent<AudioSource>();
			sound.source.clip = s.clip;
			sound.source.loop = s.loop;
			sound.source.outputAudioMixerGroup = mixerGroup;
			sound.name = s.name;

			// Add to dictionary here
			_soundDictionary.Add(sound.name, sound);

			
		}
	}

	private void OnDestroy()
	{
		if (instance != this) return;
		instance = null;
	}

	private void PlayInstance(string sound)
	{
		if (!_soundDictionary.ContainsKey(sound))
		{
			Debug.LogWarning("Sound: " + name + " not found!");
			return;
		}

		
		Sound s = _soundDictionary[sound];
		

		s.source.volume = s.volume * (1f);
		s.source.pitch = s.pitch * (1f );

		s.source.Play();

	}


	public static void Play(string sound)
	{
		if (instance == null)
		{
			Debug.LogWarning("No audio Manager");

			return;
		}
        
		instance.PlayInstance(sound);
	}
	private void StopInstance(string sound)
	{
		if (!_soundDictionary.ContainsKey(sound))
		{
			Debug.LogWarning("Sound: " + name + " not found!");
			return;
		}

		Sound s = _soundDictionary[sound];
		s.source.Stop();
	}

	public static void Stop(string sound)
	{
		if (instance == null)
		{
			Debug.LogWarning("No audio Manager");

			return;
		}

		instance.StopInstance(sound);
	}
}
