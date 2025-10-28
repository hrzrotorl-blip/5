using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundToggle : MonoBehaviour
{
    public AudioSource bgmSource; // 배경음 오디오 소스
    public Button soundButton;    // 버튼 오브젝트
    public Text buttonText;       // 버튼 안의 텍스트 (TMP라면 TMP_Text로 변경)

    private bool isMuted = false;

    void Start()
    {
        // 씬이 다시 로드되어 bgmSource가 없어졌다면 새로 찾기
        if (bgmSource == null)
            bgmSource = FindObjectOfType<AudioSource>();

        UpdateButtonText();
    }

    public void ToggleSound()
    {
        // 혹시 bgmSource가 씬 전환으로 사라졌다면 다시 찾기
        if (bgmSource == null)
        {
            bgmSource = FindObjectOfType<AudioSource>();
            if (bgmSource == null)
            {
                Debug.LogWarning("🔇 AudioSource not found in this scene!");
                return; // 여전히 없으면 그냥 리턴
            }
        }

        // 음소거 상태 변경
        isMuted = !isMuted;
        bgmSource.mute = isMuted;
        UpdateButtonText();
    }

    void UpdateButtonText()
    {
        if (buttonText != null)
            buttonText.text = isMuted ? "Sound Off" : "Sound On";
    }
}

