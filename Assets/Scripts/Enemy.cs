using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {


    // designer variables
    public float speed = 10;
    public Rigidbody2D physicsBody;
    public bool enableWeapon;

    public float health = 100;
    public float magazine = 0;
    public float maxMagazine = 30;
    public float bulletForce = 1000;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if(health <= 0)
        {
            Destroy(gameObject);
        }


	}



    public void damaged ()
    {
        health = health - 50;
    }



}
