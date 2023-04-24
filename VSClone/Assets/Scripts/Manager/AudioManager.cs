using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour   //this class also saves player audio in player prefs
{
    public static AudioManager Instance;

    public SoundClass[] musicClips, sfxClips;
    public AudioSource musicSource, sfxSource;

    private const string MUSICKEY = "musicVolume";
    private const string SFXKEY = "sfsxVolume";

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        PlayMusic("IntroDrone");
    }

    private void OnDisable()
    {
        PlayerPrefs.SetFloat(MUSICKEY, musicSource.volume);
        PlayerPrefs.SetFloat(SFXKEY, sfxSource.volume);
    }

    private void Start()
    {
        AdjustMusicVolume(PlayerPrefs.GetFloat(MUSICKEY));
        AdjustSFXVolume(PlayerPrefs.GetFloat(SFXKEY));
    }

    public void PlayMusic(string name)
    {
        SoundClass s = Array.Find(musicClips, x => x.name == name);

        if (s == null)
        {
            Debug.Log($"{name} not found");
        }
        else
        {
            musicSource.clip = s.audioClip;
            musicSource.Play();
        }
    }
    public void PlaySFX(string name)
    {
        SoundClass s = Array.Find(sfxClips, x => x.name == name);

        if (s == null)
        {
            Debug.Log($"{name} not found");
        }
        else
        {
            sfxSource.PlayOneShot(s.audioClip);
        }
    }

    public void AdjustMusicVolume(float volume)
    {
        musicSource.volume = volume;
    }

    public void AdjustSFXVolume(float volume)
    {
        sfxSource.volume = volume;
    }
}
