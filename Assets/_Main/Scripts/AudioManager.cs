﻿using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager ins;

    public Slider musicSlider;
    public Slider soundSlider;
    public Button musicButton;
    public Button soundButton;

    private AudioSource backgroundMusic;
    private AudioSource blockSound;
    private AudioSource destroySound;

    public void PlayBlockSound()
    {
        blockSound.Play();
    }

    public void PlayDestroySound()
    {
        destroySound.Play();
    }

    public bool[] GetAudioMutes()
    {
        bool[] av = new bool[2];

        av[0] = backgroundMusic.mute;
        av[1] = blockSound.mute;

        return av;
    }

    public float[] GetAudioVolumes()
    {
        float[] av = new float[2];

        av[0] = backgroundMusic.volume;
        av[1] = blockSound.volume;

        return av;
    }

    public void ChangeMusicVolume(float v = -1)
    {
        if (v < 0)
            v = musicSlider.value;

        backgroundMusic.volume = v;

        if (v == 0)
            MuteMusic();
        else if (backgroundMusic.mute)
            UnmuteMusic();
    }

    public void ChangeSoundVolume(float v = -1)
    {
        if (v < 0)
            v = soundSlider.value;

        blockSound.volume = v;
        destroySound.volume = v;

        if (v == 0)
            MuteSound();
        else if (blockSound.mute)
            UnmuteSound();
    }

    public void ChangeSliderValues(float[] v)
    {
        musicSlider.value = v[0];
        soundSlider.value = v[1];
    }

    public void MuteMusic()
    {
        float v = backgroundMusic.volume;

        backgroundMusic.volume = v;
        backgroundMusic.mute = true;
    }

    public void UnmuteMusic()
    {
        backgroundMusic.mute = false;
    }

    public void MuteSound()
    {
        float v = blockSound.volume;

        blockSound.volume = destroySound.volume = v;
        blockSound.mute = destroySound.mute = true;
        
    }

    public void UnmuteSound()
    {
        blockSound.mute = false;
        destroySound.mute = false;
    }

    public void OnSliderButtonClick(int i)
    {
        if (i == 0)
        {
            if (!backgroundMusic.mute && backgroundMusic.volume > 0)
                MuteMusic();
            else if (backgroundMusic.mute && backgroundMusic.volume > 0)
                UnmuteMusic();
        }
        else if (i == 1)
        {
            if (!blockSound.mute && blockSound.volume > 0)
                MuteSound();
            else if (blockSound.mute && blockSound.volume > 0)
                UnmuteSound();
        }
    }

    private void Awake()
	{
        if (!ins)
            ins = this;

        backgroundMusic = GetComponents<AudioSource>()[0];
        blockSound = GetComponents<AudioSource>()[1];
        destroySound = GetComponents<AudioSource>()[2];
    }
}
