using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    public string nameCollectable;
    public int score;
    public int restoreHP;

    public Collectables(string name, int scoreValue, int restoreHPValue)
    {
        this.nameCollectable = name;
        this.score = scoreValue;
        this.restoreHP = restoreHPValue;
    }
    public void UpdateScore()
    {
        ScoreManager.scoreManager.UpdateScore(score);
    }
    public void UpdateHealth()
    {
        PlayerManager.playerManager.player.GetComponent<CharacterStats>().RestoreHealth(this.restoreHP);
    }
}
