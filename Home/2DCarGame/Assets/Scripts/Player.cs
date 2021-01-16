using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float padding = 0.7f;
    [SerializeField] int health = 50;

    [SerializeField] GameObject deathVFX;
    [SerializeField] float explosionDuration = 1f;

    [SerializeField] AudioClip obstacleHitSound;
    [SerializeField] [Range(0, 1)] float obstacleHitSoundVolume = 0.75f;

    float xMin, xMax;

    public GameSession gameSession;

    void Start()
    {
        SetUpMoveBoundaries();
    }

    private void SetUpMoveBoundaries()
    {
        //get the main camera from Unity
        Camera gameCamera = Camera.main;
        //set boundaries on the x-axis
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;

    }

    public void OnTriggerEnter2D(Collider2D otherObject)
    {
        DamageDealer dmg = otherObject.gameObject.GetComponent<DamageDealer>();
        if (!dmg)
        {
            return;
        }
        ProcessHit(dmg);
    }

    private void ProcessHit(DamageDealer dmg)
    {
        gameSession = FindObjectOfType<GameSession>();
        int score = gameSession.GetScore();
        health -= dmg.GetDamage();
        dmg.Hit();

        AudioSource.PlayClipAtPoint(obstacleHitSound, Camera.main.transform.position, obstacleHitSoundVolume);
        
        if (health <= 0 && score < 100)
        {
            Die();
        }
    }

    public int GetHealth()
    {
        return health;
    }

    void Update()
    {
        Move();
        CheckGame();
    }

    private void Die()
    {
        Destroy(gameObject);
        GameObject explosion = Instantiate(deathVFX, transform.position, Quaternion.identity);
        Destroy(explosion, explosionDuration);
        FindObjectOfType<Level>().LoadGameOVer();
    }

    private void Move()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var newXPos = transform.position.x + deltaX;
        newXPos = Mathf.Clamp(newXPos, xMin, xMax);


        this.transform.position = new Vector2(newXPos, -2.3f);
    }

    public void CheckGame()
    {
        gameSession = FindObjectOfType<GameSession>();
        int score = gameSession.GetScore();

        if (health > 0 && score >= 100)
        {
            FindObjectOfType<Level>().LoadWinner();
        }
    }
}
