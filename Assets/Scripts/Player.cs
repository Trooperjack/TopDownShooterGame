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
    public bool enableMovement;
    public bool godMode;
    public bool traveling;

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

    private Vector2 playerPosition;
    public bool movingToNewZonePos = false;
    public float posPart = 0;

    public float zone = 1;
    public float travelTime = 8;
    public float maxTravelTime = 8;
    public float kills = 0;
    public float killsRequired = 10;

    public bool isDefending = false;

    public Animator playerAnimator;
    public SpriteRenderer playerSprite;
    public Collider2D playerCollider;
    
    public GameObject bulletPrefab;
    public Transform bulletSpawn;

    public Lives livesObject;
    public Health healthObject;
    public MovingText movingTextObject;
    public DefendText defendTextObject;
    public KillsText killsTextObject;
    public MovementText movementTextObject;
    public Enemy enemyObject;

    Vector2 newZonePos;

    // Use this for initialization
    void Start () {

        traveling = false;
        godMode = false;
        //health = maxHealth;
        magazine = maxMagazine;
        ammo = maxAmmo;
        fireTimer = fireRate;
        kills = 0;
        killsRequired = 10;
        travelTime = maxTravelTime;
        zone = 1;
        enableWeapon = true;
        enableMovement = true;
        movingToNewZonePos = false;
        isDefending = false;
        posPart = 0;
        playerControl = "x";
        movementTextObject.setToX();
        movingTextObject.removeMovingText();
        defendTextObject.removeDefendText();

	}
	
	// Update is called once per frame
	void Update () {

        playerPosition = transform.position;

        //Current player movement axis
        if (playerControl == "xy" && enableMovement == true)
        {
            float x = Input.GetAxis(horizontalAxis);
            float y = Input.GetAxis(verticalAxis);
            physicsBody.velocity = new Vector2(x * speed, y * speed);
        }
        else if (playerControl == "x" && enableMovement == true)
        {
            float x = Input.GetAxis(horizontalAxis);
            physicsBody.velocity = new Vector2(x * speed, 0);
        }
        else if (playerControl == "y" && enableMovement == true)
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


        //Travel to next point
        if(traveling == true)
        {
            travelTime -= Time.deltaTime;
            godMode = true;
            enableWeapon = false;
            enableMovement = false;
            weaponReady = false;
            movingToNewZonePos = true;
            movingTextObject.activateMovingText();
            if (playerPosition == newZonePos && posPart == 0)
            {
                newZonePos = new Vector2(0, -18);
                posPart = 1;
            }
            if (playerPosition == newZonePos && posPart == 1)
            {
                newZonePos = new Vector2(-22, -18);
                posPart = 2;
            }
            if (playerPosition == newZonePos && posPart == 2)
            {
                traveling = false;
                godMode = false;
                enableWeapon = true;
                enableMovement = true;
                weaponReady = true;
                movingToNewZonePos = false;
                isDefending = true;
                playerControl = "y";
                posPart = 3;
                travelTime = maxTravelTime;
                movementTextObject.setToY();
                movingTextObject.removeMovingText();
                defendTextObject.beginDefendTimer();
                enemyObject.newRespawnPositions();
                enemyObject.respawn();
            }
        }

        if (movingToNewZonePos == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, newZonePos, Time.deltaTime * speed);
        }



        if (isDefending == true)
        {

        }



    }



    //Weapon fired
    void FireWeapon()
    {
        if (weaponReady == true)
        {
            weaponReady = false;
            //magazine = magazine - 1;

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
        if (godMode == false)
        {
            healthObject.LoseHealth();
            healthObject.UpdateHealthText();

            bool noHealth = healthObject.IsNoHealth();

            if (noHealth == true)
            {
                Kill();
            }
        }
    }




    // Our own function for handling player death
    public void Kill()
    {

        //Take away a life and save the change
        healthObject.ResetHealth();
        livesObject.LoseLife();
        livesObject.SaveLives();


        // Check if it's game over
        bool gameOver = livesObject.IsGameOver();


        if (gameOver == true)
        {
            //If it IS game over...
            //Load the game over scene
            SceneManager.LoadScene("GameOver");
        }
        else
        {
            //If it is NOT game over...
            //Reset the current level to restart from



            // Reset the current level to restart from the beginning.

            // First, ask unity what the current level is
            Scene currentLevel = SceneManager.GetActiveScene();

            // Second, tell unity to load the current again
            // by passing the build index of our level
            SceneManager.LoadScene(currentLevel.buildIndex);
        }
    }




    public void enemyKilled()
    {
        kills = kills + 1;
        killsTextObject.addKillToText();
        Debug.Log(kills);
        //When amount of kills meet the requirements
        if (kills >= killsRequired && zone == 1)
        {
            Debug.Log("OBJECTIVE MET");
            zone = 2;
            newZonePos = new Vector2(0, -5);
            traveling = true;
            killsRequired = killsRequired + 10;
            killsTextObject.removeObjective();
            movementTextObject.setToMoving();
        }
    }





}