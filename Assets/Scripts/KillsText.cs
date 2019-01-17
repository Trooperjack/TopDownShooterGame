using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Using statement for the unity UI code
using UnityEngine.UI;

public class KillsText : MonoBehaviour {

    public Text killsText;

    public float kills = 0;
    public float killsRequired = 10;

    public bool killsObjective;

    // Use this for initialization
    void Start () {
        killsObjective = true;
        kills = 0;
        killsRequired = 10;
	}
	
	// Update is called once per frame
	void Update () {
		
        if (killsObjective == true)
        {
            killsText.text = "Enimies Eliminated: " + kills.ToString() + "/" + killsRequired.ToString();
        }
        else
        {
            killsText.text = "";
        }

	}

    public void removeObjective()
    {
        killsRequired = killsRequired + 10;
        killsObjective = false;
    }

    public void addKillToText()
    {
        kills = kills + 1;
    }




}
