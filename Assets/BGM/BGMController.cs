using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMController : MonoBehaviour
{
    private static BGMController instance;
    private AudioSource audioSource;

    void Awake()
    {
        // 다른 씬으로 전환돼도 음악 유지
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            audioSource = GetComponent<AudioSource>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // 재생
    public void PlayBGM()
    {
        if (!audioSource.isPlaying)
            audioSource.Play();
    }

    // 일시정지
    public void PauseBGM()
    {
        if (audioSource.isPlaying)
            audioSource.Pause();
    }

    // 볼륨 조절
    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }
}
