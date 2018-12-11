using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {


    // designer variables
    public Transform playerPosition;
    public Transform enemyPosition;

    public float speed = 10;
    public Rigidbody2D physicsBody;
    public bool enableWeapon;
    public bool enableMovement;

    public float health = 100;
    public float magazine = 0;
    public float maxMagazine = 30;
    public float bulletForce = 1000;


    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {

        if (enableMovement == true)
        {
            //transform.position = Vector2.MoveTowards(transform.position, playerPosition.position, speed * Time.deltaTime);
            chasePlayer();
        }



        if(health <= 0)
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
        posPlayer = new Vector2(playerPosition.position.x, playerPosition.position.y);
        enemyPosition.position = Vector2.MoveTowards(enemyPosition.position, posPlayer, Time.deltaTime * speed);
    }


}
