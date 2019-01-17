using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Using statement for the unity UI code
using UnityEngine.UI;

public class Enemy : MonoBehaviour {


    // designer variables
    public Transform playerPosition;
    public Transform enemyPosition;
    public Rigidbody2D enemyBody;
    public float randomPositionX = 0;
    public float randomPositionY = 0;
    public float randomPositionZ = 0;

    public float speed = 2;
    public Rigidbody2D physicsBody;
    public bool enableWeapon;
    public bool enableMovement;

    public float health = 100;
    public float magazine = 0;
    public float maxMagazine = 30;
    public float bulletForce = 1000;
    public float weaponDelay = 0.2f;
    public float fireRate = 0.2f;
    public float fireTimer = 0.0f;
    public bool weaponReady = false;
    public bool weaponDelayDone = false;
    public float movementTime = 5;
    public int scoreValue;

    public GameObject enemyBulletPrefab;
    public Transform enemyBulletSpawn;
    public Score scoreObject;
    public Player playerObject;

    Vector2 spawnPosition;
    Vector2 playerVectorPosition;


    // Use this for initialization
    void Start () {
        //score = GameObject.Find("/score_text");
        spawnPosition = transform.position;
        randomPositionX = Random.Range(-5, 5);
        randomPositionY = Random.Range(-5, 0);
        enemyBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

        playerVectorPosition = playerPosition.position;

        if (enableMovement == true)
        {
            movementTime -= Time.deltaTime;
            if (movementTime > 0)
            {
                chasePlayer();
            }
        }


        //Weapon Fire Delayed from spawned
        weaponDelay -= Time.deltaTime;
        if (weaponDelay < 0 && weaponDelayDone == false)
        {
            weaponDelayDone = true;
            weaponReady = true;
            FireWeapon();
        }




        //Fire rate time delay
        if (weaponReady == false)
        {
            fireTimer -= Time.deltaTime;
            if (fireTimer <= 0)
            {
                fireTimer = fireRate;
                weaponReady = true;
                FireWeapon();
            }
        }


        if (health <= 0)
        {
            scoreObject.AddScore(scoreValue);
            playerObject.enemyKilled();
            respawn();
            //Destroy(gameObject);
        }

        
        
            
	}


    



    public void damaged ()
    {
        health = health - 50;
    }


    public void chasePlayer ()
    {
        Vector2 posPlayer;
        posPlayer = new Vector2((playerVectorPosition.x + randomPositionX), (playerVectorPosition.y + randomPositionY));
        enemyPosition.position = Vector2.MoveTowards(enemyPosition.position, posPlayer, Time.deltaTime * speed);
    }



    //Weapon fired
    void FireWeapon()
    {
        if (weaponReady == true)
        {
            weaponReady = false;
            //magazine = magazine - 1;

            //Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 posPlayer;
            posPlayer = new Vector3(playerVectorPosition.x, playerVectorPosition.y);
            Vector2 direction = (Vector2)((posPlayer - transform.position));
            direction.Normalize();

            var Bullet = (GameObject)Instantiate(enemyBulletPrefab, enemyBulletSpawn.position + (Vector3)(direction * 0.5f), Quaternion.identity);
            Bullet.GetComponent<Rigidbody2D>().AddForce(direction * bulletForce);
            Destroy(Bullet, 2.0f);
        }
    }


    public void respawn()
    {
        movementTime = 5;
        health = 100;
        transform.position = spawnPosition;
        randomPositionX = Random.Range(-5, 5);
        randomPositionY = Random.Range(-5, 0);
    }



    public void newRespawnPositions()
    {
        spawnPosition = new Vector2((Random.Range(8, 12)), (Random.Range(-15, -30)));
    }


}
