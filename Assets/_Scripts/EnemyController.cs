using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5f;
    Rigidbody2D enemy_rb;
    SpriteRenderer enemy_sprite;
    private void Start()
    {
        enemy_rb = GetComponent<Rigidbody2D>();
        enemy_sprite = GetComponent<SpriteRenderer>();
        RamdomSizeEnemy();
    }
    private void Update()
    {
        GetSpeed();
        RespawnEnemy();

    }

    void RespawnEnemy()
    {
        if (this.transform.position.y < -8)
        {
            int RamdomPos = Random.Range(-8, 9);
            this.transform.position = new Vector2(RamdomPos, 7);
        }
    }
    void GetSpeed()
    {
        int speedUpdate = PlayerPrefs.GetInt("Level");
        enemy_rb.velocity = Vector2.down * (speed + speedUpdate);
    }
    void RamdomSizeEnemy()
    {
        float ramdomSize = Random.Range(1f, 1.4f);
        this.transform.localScale = new Vector2(ramdomSize, ramdomSize);
        
    }
}
