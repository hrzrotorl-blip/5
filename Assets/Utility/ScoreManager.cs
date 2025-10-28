using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance; // ½Ì±ÛÅæÀ¸·Î ¾îµð¼­³ª Á¢±Ù °¡´É
    public TextMeshProUGUI scoreText;
    private int score = 0;

    void Awake()
    {
        // ½Ì±ÛÅæ ¼³Á¤
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        UpdateScoreText();
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
