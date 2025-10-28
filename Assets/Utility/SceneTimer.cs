using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // TextMeshPro를 사용하기 위해 필요합니다.

public class SceneTimer : MonoBehaviour
{
    // 인스펙터 창에서 연결할 텍스트 UI
    public TextMeshProUGUI timerText;

    // Update는 매 프레임마다 호출됩니다.
    void Update()
    {
        // timeSinceLevelLoad는 현재 씬이 로드된 후 경과한 시간을 초 단위로 반환합니다.
        float timeInScene = Time.timeSinceLevelLoad;

        // 시간을 분과 초로 변환합니다.
        float minutes = Mathf.FloorToInt(timeInScene / 60);
        float seconds = Mathf.FloorToInt(timeInScene % 60);

        // "00:00" 형식으로 텍스트 UI를 업데이트합니다.
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}