using System.Collections;
using System.Collections.Generic;
// SceneTrigger.cs
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTrigger : MonoBehaviour
{
    [Tooltip("전환할 씬 이름 (Build Settings에 추가된 이름)")]
    public string sceneName;

    [Tooltip("태그가 'Player'인 오브젝트만 전환을 트리거합니다.")]
    public string requiredTag = "Player";

    // 옵션: 트리거 중복 방지
    bool triggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (triggered) return;
        if (other.CompareTag(requiredTag))
        {
            triggered = true;
            // 즉시 씬 전환
            SceneManager.LoadScene(sceneName);
        }
    }
}

