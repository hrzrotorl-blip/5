using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowDescription : MonoBehaviour
{
    public GameObject descriptionPanel; // 설명 이미지(패널)

    // 설명 버튼 클릭 시 실행
    public void ShowPanel()
    {
        descriptionPanel.SetActive(true);
    }

}
