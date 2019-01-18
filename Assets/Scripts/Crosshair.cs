using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Using statement for the unity UI code
using UnityEngine.UI;

public class Crosshair : MonoBehaviour {

    public GameObject crosshair;
    public Rigidbody2D physicsBody;

    public bool isControllerActive;
    public float speed = 5;

	// Use this for initialization
	void Start () {
        isControllerActive = false;
        crosshair.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

        if(isControllerActive == true)
        {
            float x = Input.GetAxis("XBOX Mouse X");
            float y = Input.GetAxis("XOBX Mouse Y");
            physicsBody.velocity = new Vector2(x * speed, y * speed);
            crosshair.SetActive(true);
        }
        else
        {
            crosshair.SetActive(false);
        }

    }




    public void activateController()
    {
        isControllerActive = true;
    }

    public void removeController()
    {
        isControllerActive = false;
    }


}
