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
        UpdateButtonText();
    }

    public void ToggleSound()
    {
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
