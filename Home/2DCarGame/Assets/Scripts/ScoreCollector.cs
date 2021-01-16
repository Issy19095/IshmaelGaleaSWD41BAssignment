using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCollector : MonoBehaviour
{
    [SerializeField] int scoreValue = 5;

    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        FindObjectOfType<GameSession>().AddToScore(scoreValue);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print(collision.gameObject.name);
        FindObjectOfType<GameSession>().AddToScore(scoreValue);
    }
}
