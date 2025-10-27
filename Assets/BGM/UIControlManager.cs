using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControlManager : MonoBehaviour
{
    [Header("Sound UI")]
    public AudioSource bgmSource;
    public Slider volumeSlider;
    public Button soundToggleButton;
    public Sprite soundOnIcon;
    public Sprite soundOffIcon;
    private bool isMuted = false;

    [Header("Screen UI")]
    public Button fullScreenButton;
    public Sprite fullIcon;
    public Sprite windowIcon;

    private void Start()
    {
        if (bgmSource != null && volumeSlider != null)
        {
            volumeSlider.value = PlayerPrefs.GetFloat("Volume", 1f);
            bgmSource.volume = volumeSlider.value;
            volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
        }

        soundToggleButton.onClick.AddListener(OnSoundToggle);
        fullScreenButton.onClick.AddListener(OnFullScreenToggle);

        UpdateSoundIcon();
        UpdateScreenIcon();
    }

    private void OnVolumeChanged(float value)
    {
        bgmSource.volume = value;
        PlayerPrefs.SetFloat("Volume", value);
    }

    private void OnSoundToggle()
    {
        isMuted = !isMuted;
        bgmSource.mute = isMuted;
        UpdateSoundIcon();
    }

    private void OnFullScreenToggle()
    {
        Screen.fullScreen = !Screen.fullScreen;
        UpdateScreenIcon();
    }

    private void UpdateSoundIcon()
    {
        if (soundToggleButton != null)
        {
            soundToggleButton.image.sprite = isMuted ? soundOffIcon : soundOnIcon;
        }
    }

    private void UpdateScreenIcon()
    {
        if (fullScreenButton != null)
        {
            fullScreenButton.image.sprite = Screen.fullScreen ? windowIcon : fullIcon;
        }
    }
}
