using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;


public class BulletController : MonoBehaviour
{
    public float bullet_speed = 2f;

    public GameController gameController;

    AudioSource aus;
    public AudioClip hitSound;

    private void Start()
    {
        gameController = FindObjectOfType<GameController>();
        aus = FindObjectOfType<AudioSource>();
    }
    private void Update()
    {
        bulletSpeed();
    }

    void bulletSpeed()
    {
        this.transform.Translate( Vector2.up * bullet_speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            GetScoreGame();
            SoundHit();
            CameraShake();
            if (gameController.score == 17)
            {
                gameController.levelNext.SetActive(true);
            }
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }

    void SoundHit()
    {
        if (aus && hitSound)
        {
            aus.PlayOneShot(hitSound);
        }
    }
    void CameraShake()
    {
        gameController.ShakeCamera();
    }
    void GetScoreGame()
    {
        gameController.score++;
        gameController.scoreText.text = "Score: " + gameController.score;
    }
}
