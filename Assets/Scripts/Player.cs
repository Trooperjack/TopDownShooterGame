using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Extra using statement to allow us to use the scene management functions
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour {

    // designer variables
    public float speed = 10;
    public Rigidbody2D physicsBody;
    public string horizontalAxis = "Horizontal";
    public string verticalAxis = "Vertical";
    public string fireAxis = "Fire2";
    public string playerControl = "xy";
    public bool enableWeapon;

    public float lives = 3;
    public float health = 100;
    public float maxHealth = 100;
    public float magazine = 0;
    public float maxMagazine = 30;
    public float ammo = 0;
    public float maxAmmo = 120;
    public float bulletForce = 1000;
    public float bulletDamage = 50;
    public float fireRate = 0.2f;
    public float fireTimer = 0.0f;
    public bool weaponReady = true;

    public Animator playerAnimator;
    public SpriteRenderer playerSprite;
    public Collider2D playerCollider;
    
    public GameObject bulletPrefab;
    public Transform bulletSpawn;

    // Use this for initialization
    void Start () {

        health = maxHealth;
        magazine = maxMagazine;
        ammo = maxAmmo;
        fireTimer = fireRate;
        enableWeapon = true;

	}
	
	// Update is called once per frame
	void Update () {


        //Current player movement axis
        if (playerControl == "xy")
        {
            float x = Input.GetAxis(horizontalAxis);
            float y = Input.GetAxis(verticalAxis);
            physicsBody.velocity = new Vector2(x * speed, y * speed);
        }
        else if (playerControl == "x")
        {
            float x = Input.GetAxis(horizontalAxis);
            physicsBody.velocity = new Vector2(x * speed, 0);
        }
        else if (playerControl == "y")
        {
            float y = Input.GetAxis(verticalAxis);
            physicsBody.velocity = new Vector2(0, y * speed);
        }


        //When Fire button pressed
        if (Input.GetButton("Fire1"))
        {
            if (magazine > 0 && enableWeapon == true)
            {
                FireWeapon();
            }
        }
        

        //When reload button pressed
        if (Input.GetButtonDown("Fire2"))
        {
            if (magazine < 30)
            {
                magazine = 30;
                ammo = ammo - 30;
            }
        }


        //Fire rate time delay
        if(weaponReady == false)
        {
            fireTimer -= Time.deltaTime;
            if(fireTimer <= 0)
            {
                fireTimer = fireRate;
                weaponReady = true;
            }
        }




    }



    //Weapon fired
    void FireWeapon()
    {
        if (weaponReady == true)
        {
            weaponReady = false;
            magazine = magazine - 1;

            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = (Vector2)((mousePos - transform.position));
            direction.Normalize();

            var Bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position + (Vector3)(direction * 0.5f), Quaternion.identity);
            Bullet.GetComponent<Rigidbody2D>().AddForce(direction * bulletForce);
            Destroy(Bullet, 2.0f);
        }
    }


    public void damaged()
    {
        health = health - 50;
    }


}