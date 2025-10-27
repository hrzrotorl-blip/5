using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToTitle : MonoBehaviour
{
    // ���� Ÿ��Ʋ �� �̸� (�� �̸� ��Ȯ�� �Է�!)
    public string titleSceneName = "MainTitle";

    void Update()
    {
        // ESC Ű �Է� ����
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // ���� Ÿ��Ʋ�� ��ȯ
            SceneManager.LoadScene(titleSceneName);
        }
    }

    // ���� �ٲ� �� ������Ʈ�� �ı����� �ʵ��� ����
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
