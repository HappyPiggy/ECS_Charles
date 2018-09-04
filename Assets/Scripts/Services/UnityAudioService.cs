using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
/// <summary>
/// 音乐管理
/// </summary>
public class UnityAudioService : IAudioService
{
    private AudioSource musicAudioSource;
    private AudioSource soundAudioSource;
    private AudioSource extraSource;

    private float musicVolume=0.5f;
    private float soundVolume =1f;

    public UnityAudioService()
    {
        AudioSource[] list = Camera.main.GetComponents<AudioSource>();

        musicAudioSource = list[0];
        musicAudioSource.playOnAwake = false;
        musicAudioSource.loop = true;
        musicAudioSource.volume = musicVolume;

        soundAudioSource = list[1];
        soundAudioSource.playOnAwake = false;
        soundAudioSource.loop = false;
        soundAudioSource.volume = soundVolume;

        extraSource = list[2];
        extraSource.playOnAwake = false;
        extraSource.loop = false;
        extraSource.volume = soundVolume;
    }

    public bool isPlayingMusic()
    {
        return true;
    }

    public void PlayMusic(AudioClip clip)
    {
        if (clip != null)
        {
            musicAudioSource.clip = clip;
            musicAudioSource.Play();
        }
    }

    public void StopMusic()
    {
        musicAudioSource.Stop();
    }

    public void PlaySound(AudioClip clip, bool isLoop = false)
    {
        if (clip != null)
        {
            if (soundAudioSource.isPlaying)
            {
                extraSource.loop = isLoop;
                extraSource.clip = clip;
                extraSource.Play();
            }
            else
            {
                soundAudioSource.loop = isLoop;
                soundAudioSource.clip = clip;
                soundAudioSource.Play();
            }
        }
    }

    public void StopSound()
    {
        soundAudioSource.Stop();
    }
}