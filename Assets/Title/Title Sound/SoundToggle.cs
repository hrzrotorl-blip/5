using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundToggle : MonoBehaviour
{
    [Header("UI 연결")]
    public Button soundButton;      // 사운드 버튼
    public Text buttonText;         // 버튼 텍스트 (TMP_Text 가능)
    public Slider volumeSlider;     // 볼륨 조절 슬라이더
    public Image soundIcon;         // 아이콘 이미지

    [Header("아이콘 이미지 설정")]
    public Sprite soundOnSprite;    // 🔊 사운드 켜짐 아이콘
    public Sprite soundOffSprite;   // 🔇 사운드 꺼짐 아이콘

    private bool isMuted = false;

    void Start()
    {
        // 현재 BGMManager 상태에 맞게 초기 설정
        if (BGMManager.Instance != null)
        {
            isMuted = BGMManager.Instance.IsMuted();

            if (volumeSlider != null)
            {
                volumeSlider.minValue = 0f;
                volumeSlider.maxValue = 1f;
                volumeSlider.value = BGMManager.Instance.GetVolume();
                volumeSlider.onValueChanged.AddListener(SetVolume);
            }
        }

        UpdateButtonUI();
    }

    public void ToggleSound()
    {
        if (BGMManager.Instance == null)
            return;

        isMuted = !isMuted;
        BGMManager.Instance.SetMute(isMuted);
        UpdateButtonUI();
    }

    public void SetVolume(float volume)
    {
        if (BGMManager.Instance != null)
            BGMManager.Instance.SetVolume(volume);
    }

    void UpdateButtonUI()
    {
        if (buttonText != null)
            buttonText.text = isMuted ? "Sound Off" : "Sound On";

        if (soundIcon != null)
            soundIcon.sprite = isMuted ? soundOffSprite : soundOnSprite;

        if (volumeSlider != null)
            volumeSlider.gameObject.SetActive(!isMuted);
    }
}
