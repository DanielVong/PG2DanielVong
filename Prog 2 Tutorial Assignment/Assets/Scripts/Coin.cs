using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    Collectables coin;

    private void Awake()
    {
        coin = new Collectables("Coin", 1, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            coin.UpdateScore();
            Destroy(gameObject);
        }
    }
}
