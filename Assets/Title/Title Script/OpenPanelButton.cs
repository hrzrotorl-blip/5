using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPanelButton : MonoBehaviour
{
    public GameObject targetPanel; // 열고 싶은 패널 오브젝트

    private bool isOpen = false;

    public void TogglePanel()
    {
        isOpen = !isOpen;
        targetPanel.SetActive(isOpen);
    }
}
