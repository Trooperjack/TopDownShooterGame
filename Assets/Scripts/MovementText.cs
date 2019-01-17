using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Using statement for the unity UI code
using UnityEngine.UI;

public class MovementText : MonoBehaviour {

    public Text movementText;

    public string movementType;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
        if (movementType == "xy")
        {
            movementText.text = "You can move in any direction.";
        }
        else if (movementType == "x")
        {
            movementText.text = "You can only move in the X axis.";
        }
        else if (movementType == "y")
        {
            movementText.text = "You can only move in the Y axis.";
        }
        else if (movementType == "moving")
        {
            movementText.text = "";
        }
        else
        {
            movementText.text = "";
        }

	}



    public void setToXY()
    {
        movementType = "xy";
    }

    public void setToX()
    {
        movementType = "x";
    }

    public void setToY()
    {
        movementType = "y";
    }

    public void setToMoving()
    {
        movementType = "moving";
    }





}
