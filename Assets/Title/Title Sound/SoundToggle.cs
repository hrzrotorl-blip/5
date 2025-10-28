using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundToggle : MonoBehaviour
{
    public AudioSource bgmSource; // ����� ����� �ҽ�
    public Button soundButton;    // ��ư ������Ʈ
    public Text buttonText;       // ��ư ���� �ؽ�Ʈ (TMP��� TMP_Text�� ����)

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
