using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Using statement for the unity UI code
using UnityEngine.UI;

public class MovingText : MonoBehaviour {


    public Text movingText;


	// Use this for initialization
	void Start () {
        removeMovingText();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void activateMovingText()
    {
        movingText.text = "MOVING TO NEW LOCATION";
    }

    public void removeMovingText()
    {
        movingText.text = "";
    }

}
