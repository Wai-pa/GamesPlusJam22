using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance = null;

    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource effectsSource;
    [SerializeField] private AudioSource narratorSource;

    void Awake()
    {
        if (instance == null) { instance = this; }
        else { Destroy(gameObject); }

        musicSource.volume = 0.4f;
        PauseBackgroundMusic();
    }

    public void PlaySound(AudioClip clip) { effectsSource.PlayOneShot(clip); }

    public void PlayScript(AudioClip clip) { narratorSource.PlayOneShot(clip); }

    public void PlayBackgroundMusic() { musicSource.UnPause(); }

    public void PauseBackgroundMusic() { musicSource.Pause(); }

    public void BackgroundMusicFadeOut() { musicSource.volume = 0.0f; }

    public void BackgroundMusicFadeIn() { musicSource.volume = 0.4f; }

    public void ChangeMasterVolume(float value) { AudioListener.volume = value; }
}
