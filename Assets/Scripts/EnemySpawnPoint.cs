using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnPoint : MonoBehaviour {





    public float spawnTime = 5f;
    //The amount of time between each spawn.

    public float spawnDelay = 3f;
    //The amount of time before spawning starts.

    public GameObject[] enemies;
    //Array of enemy prefabs.

    public Vector3 enposition;





    // Use this for initialization
    void Start () {
        //Start calling the Spawn function repeatedly after a delay.
        InvokeRepeating("Spawn", spawnDelay, spawnTime);
    }
	
	// Update is called once per frame
	void Update () {
        spawnTime -= Time.deltaTime;
        if (spawnTime < 0)
        {
            spawnTime = spawnDelay;
            //Instantiate a random enemy.
            int enemyIndex = Random.Range(0, enemies.Length);
            Instantiate(enemies[enemyIndex], enposition, transform.rotation);
        }
    }
}
