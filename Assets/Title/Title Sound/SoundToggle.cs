using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundToggle : MonoBehaviour
{
    [Header("UI 연결")]
    public AudioSource bgmSource;   // 배경음 오디오 소스
    public Button soundButton;      // 사운드 버튼
    public Text buttonText;         // 버튼 텍스트 (TMP_Text 가능)
    public Slider volumeSlider;     // 볼륨 조절 슬라이더
    public Image soundIcon;         // 🎵 버튼에 표시될 아이콘 이미지

    [Header("아이콘 이미지 설정")]
    public Sprite soundOnSprite;    // 🔊 사운드 켜짐 아이콘
    public Sprite soundOffSprite;   // 🔇 사운드 꺼짐 아이콘

    private bool isMuted = false;

    void Start()
    {
        if (bgmSource == null)
            bgmSource = FindObjectOfType<AudioSource>();

        if (volumeSlider != null)
        {
            volumeSlider.minValue = 0f;
            volumeSlider.maxValue = 1f;
            volumeSlider.value = bgmSource != null ? bgmSource.volume : 1f;
            volumeSlider.onValueChanged.AddListener(SetVolume);
        }

        UpdateButtonUI();
    }

    public void ToggleSound()
    {
        if (bgmSource == null)
        {
            bgmSource = FindObjectOfType<AudioSource>();
            if (bgmSource == null) return;
        }

        isMuted = !isMuted;
        bgmSource.mute = isMuted;
        UpdateButtonUI();
    }

    public void SetVolume(float volume)
    {
        if (bgmSource != null)
        {
            // 오직 볼륨만 설정
            bgmSource.volume = volume;

            // isMuted 변수나 bgmSource.mute 상태는 건드리지 않습니다.
            // UI 업데이트(UpdateButtonUI)도 호출하지 않습니다.
        }
    }

    void UpdateButtonUI()
    {
        // 🔤 텍스트 변경
        if (buttonText != null)
            buttonText.text = isMuted ? "Sound Off" : "Sound On";

        // 🎵 아이콘 변경
        if (soundIcon != null)
            soundIcon.sprite = isMuted ? soundOffSprite : soundOnSprite;


        // ✅ 슬라이더 표시를 '음소거 상태의 반대'로 설정
        // isMuted가 false(사운드 켜짐)일 때만 슬라이더가 보이게 됩니다.
        if (volumeSlider != null)
            volumeSlider.gameObject.SetActive(!isMuted);

    }

}
