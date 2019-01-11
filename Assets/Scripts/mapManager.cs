using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapManager : MonoBehaviour {


    public int zone;
    public int kills;
    public int killsRequired;
    public string playerState;


    public Player playerObject;


	// Use this for initialization
	void Start () {
        zone = 1;
        kills = 0;
        killsRequired = 10;
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void addKill()
    {
        kills = kills + 1;
        checkKills();
        Debug.Log(kills);
    }


    public void zone1Passed()
    {
        zone = 2;
        killsRequired = killsRequired + 10;
        playerObject.moveToZone2();
    }


    public void checkKills()
    {
        if(kills == killsRequired)
        {
            zone1Passed();
        }
    }


}
