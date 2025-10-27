using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToTitle : MonoBehaviour
{
    // 메인 타이틀 씬 이름 (씬 이름 정확히 입력!)
    public string titleSceneName = "MainTitle";

    void Update()
    {
        // ESC 키 입력 감지
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // 메인 타이틀로 전환
            SceneManager.LoadScene(titleSceneName);
        }
    }

    // 씬이 바뀌어도 이 오브젝트가 파괴되지 않도록 설정
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
