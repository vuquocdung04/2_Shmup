using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject Bullet;
    public bool gameOver;

    // musci
    public GameObject BulletSpawn;
    public AudioSource aus;
    public AudioClip shootingSource;
    private void Update()
    {
        if (gameOver)
        {
            return;
        }
        GetMousePos();
        Shoot();    

    }

    void GetMousePos()
    {
        Vector3 mouseScreenPosition = Input.mousePosition;
        mouseScreenPosition.z = 10f;
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);
        this.transform.position = mouseWorldPosition;
    }
    void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (shootingSource && aus)
            {
                aus.PlayOneShot(shootingSource);

            }
            float ramdomScale = Random.Range(1.1f, 1.3f);
            Instantiate(Bullet, new Vector2(this.transform.position.x, this.transform.position.y + 1), Quaternion.identity, BulletSpawn.transform);
            this.transform.localScale = new Vector2(ramdomScale, ramdomScale);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            this.transform.localScale = new Vector2(1,1);
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Time.timeScale = 0f;
            gameOver = true;
        }
    }
}
