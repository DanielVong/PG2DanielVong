using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour, IDataPersistance
{
    public static ScoreManager scoreManager;
    public TextMeshProUGUI scoreUI;
    int totalScore = 0;
    private void Awake()
    {
        if (scoreManager == null)
        {
            scoreManager = this;
        }

        scoreUI.text = "Score: 0";
    }
    private void Start()
    {
        scoreUI.text = "Score: " + totalScore;
    }
    public void UpdateScore(int score)
    {
        totalScore += score;

        Debug.Log(totalScore);
        scoreUI.text = "Score: " + totalScore.ToString();
    }
    public void SaveData(ref GameData data)
    {
        data.score = this.totalScore;
    }
    public void LoadData(GameData data)
    {
        this.totalScore = data.score;
    }
}
