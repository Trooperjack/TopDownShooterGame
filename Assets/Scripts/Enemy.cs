﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {


    // designer variables
    public Transform playerPosition;
    public Transform enemyPosition;
    public Rigidbody2D enemyBody;
    public float randomPositionX = 0;
    public float randomPositionY = 0;
    public float randomPositionZ = 0;

    public float speed = 5;
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

    public GameObject enemyBulletPrefab;
    public Transform enemyBulletSpawn;



    // Use this for initialization
    void Start () {
        randomPositionX = Random.Range(-5, 5);
        randomPositionY = Random.Range(-5, 0);
        enemyBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

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
            Destroy(gameObject);
        }

        
        
            
	}


    



    public void damaged ()
    {
        health = health - 50;
    }


    public void chasePlayer ()
    {
        Vector2 posPlayer;
        posPlayer = new Vector2((playerPosition.position.x + randomPositionX), (playerPosition.position.y + randomPositionY));
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
            posPlayer = new Vector3(playerPosition.position.x, playerPosition.position.y);
            Vector2 direction = (Vector2)((posPlayer - transform.position));
            direction.Normalize();

            var Bullet = (GameObject)Instantiate(enemyBulletPrefab, enemyBulletSpawn.position + (Vector3)(direction * 0.5f), Quaternion.identity);
            Bullet.GetComponent<Rigidbody2D>().AddForce(direction * bulletForce);
            Destroy(Bullet, 2.0f);
        }
    }


}
