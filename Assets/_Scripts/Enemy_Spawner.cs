using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawner : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject Enemy1;
    public GameObject Enemy2;
    public GameObject Enemy3;
    public GameObject Enemy4;

    float intSpawn = 0f;

    private void Start()
    {
        InvokeRepeating(nameof(GetSpawnPoint),1f,1f);
    }

    void GetSpawnPoint()
    {
        if (intSpawn > 16)
        {
            return;
        }
        intSpawn++;
        int RamdomPos = Random.Range(-8,9);
        Instantiate(RamdomEnemy(),new Vector2(RamdomPos, this.transform.position.y),Quaternion.identity,this.transform);
    }

    GameObject RamdomEnemy()
    {
        int ramdomEnemy = Random.Range(0,5);
        switch (ramdomEnemy)
        {
            case 0: return Enemy;
            case 1: return Enemy1;
            case 2: return Enemy2;
            case 3: return Enemy3;
        }
        return Enemy4;
    }
    
}
