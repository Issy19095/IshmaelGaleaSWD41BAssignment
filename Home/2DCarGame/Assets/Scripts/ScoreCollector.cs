using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCollector : MonoBehaviour
{
    [SerializeField] int scoreValue = 5;

    [SerializeField] AudioClip pointGainSound;
    [SerializeField] [Range(0, 1)] float pointGainSoundVolume = 0.75f;

    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        AudioSource.PlayClipAtPoint(pointGainSound, Camera.main.transform.position, pointGainSoundVolume);
        FindObjectOfType<GameSession>().AddToScore(scoreValue);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(pointGainSound, Camera.main.transform.position, pointGainSoundVolume);
        print(collision.gameObject.name);
        FindObjectOfType<GameSession>().AddToScore(scoreValue);
    }
}
