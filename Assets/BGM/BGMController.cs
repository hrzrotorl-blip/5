using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : MonoBehaviour
{
    private static BGMManager instance;
    private AudioSource audioSource;

    void Awake()
    {
        // 이미 존재하는 BGMManager가 있다면 새로 생긴 건 파괴
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject); // ✅ 씬 전환 시 파괴되지 않게 유지

        audioSource = GetComponent<AudioSource>();

        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.loop = true;
            audioSource.Play();
        }
    }

    public static BGMManager Instance
    {
        get { return instance; }
    }

    public void SetMute(bool mute)
    {
        if (audioSource != null)
            audioSource.mute = mute;
    }

    public bool IsMuted()
    {
        return audioSource != null && audioSource.mute;
    }

    public void SetVolume(float volume)
    {
        if (audioSource != null)
            audioSource.volume = volume;
    }

    public float GetVolume()
    {
        return audioSource != null ? audioSource.volume : 1f;
    }
}
