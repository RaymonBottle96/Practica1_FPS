using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject[] enemies;
    public Transform spawnPoint;

    [Range(1,1000)]
    public int numberOfEnemies = 1;
    [Range(1,60)]
    public float spawnDelay = 1;
    public int counter = 0;
    
    void Start() {
        InvokeRepeating("EnemySpawn",0,spawnDelay);
    }

    public void EnemySpawn() {
        Instantiate(enemies[Random.Range(0,enemies.Length)], spawnPoint.position, spawnPoint.rotation);
        counter++;
        if(counter == numberOfEnemies) {
            CancelInvoke();
        }

    }
}