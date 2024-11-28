using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TMP_Text scoreLabel;

    int score = 0;

    public void AddScore(int givenScore)
    {
        score += givenScore;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreLabel.text = "Score: " + score.ToString();
    }
}
