﻿using UnityEngine;

public struct Defs
{
    public static readonly string AndroidAppID = "com.crazylabs.monsteryumm";
    public static readonly string iOSApp_ID = "id1192223024";

    public static MyNativeShare Share;
    public static Share ShareVoxel;
    public static Rate Rate;

    // Sound
    public static AudioSource AudioSource;

    public static AudioSource AudioSourceMusic;
    public static bool Mute;

    public static void PlaySound(AudioClip audioClip, float volume = 1f)
    {
        AudioSource.volume = volume * AudioListener.volume;
        if (AudioSource.volume > 0f) AudioSource.PlayOneShot(audioClip);
    }

    public static void MuteSounds(bool flag)
    {
        if (Mute == flag)
            return;

        Mute = flag;

        if (Mute)
        {
            AudioListener.volume = 0f;
        }
        else
        {
            AudioListener.volume = PlayerPrefs.GetFloat("SoundVolume", 1f);
            if (AudioListener.volume > 0f) AudioSourceMusic.Play();
        }
    }

    public static void SwitchSounds()
    {
        if (AudioListener.volume > 0f)
        {
            //Camera.main.GetComponent<AudioListener> ().enabled = false;
            AudioListener.volume = 0f;
            //audioSource.enabled = false;
            //audioSourceMusic.enabled = false;
            D.Log("Sound OFF");
        }
        else
        {
            //Camera.main.GetComponent<AudioListener> ().enabled = true;
            AudioListener.volume = 1f;
            //audioSource.enabled = true;
            //audioSourceMusic.enabled = true;
            AudioSourceMusic.Play();
            D.Log("Sound ON");
        }

        PlayerPrefs.SetFloat("SoundVolume", AudioListener.volume);
    }
}