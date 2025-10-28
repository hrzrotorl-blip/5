using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToTitle : MonoBehaviour
{
    // 메인 타이틀 씬 이름 (씬 이름 정확히 입력!)
    public string titleSceneName = "MainTitle";
    private static ReturnToTitle instance;

    void Awake()
    {
        // 이미 인스턴스가 존재하면 자신은 제거
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        // 처음 만들어진 인스턴스라면 유지
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        // ESC 키 입력 감지
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // 메인 타이틀로 전환
            SceneManager.LoadScene(titleSceneName);
            Cursor.lockState = CursorLockMode.Confined;
        }
    }
}
