using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageTrigger : MonoBehaviour
{
    public string nextSceneName = "NextScene"; // 이동할 씬 이름

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // 플레이어 태그 확인
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
