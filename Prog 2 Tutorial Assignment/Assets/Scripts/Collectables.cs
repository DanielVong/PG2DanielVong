using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    public int score;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            ScoreManager.scoreManager.UpdateScore(score);
            Destroy(gameObject);

        }
    }
}
