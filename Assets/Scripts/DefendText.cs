using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Using statement for the unity UI code
using UnityEngine.UI;

//This allows us to use the scene loading function
using UnityEngine.SceneManagement;

public class DefendText : MonoBehaviour {

    public Text defendText;
    public bool startTimer;

    public Score scoreObject;

    public float defendTime = 10;
    public float MaxDefendTime = 10;

    public string timeText;

    // Use this for initialization
    void Start () {
        startTimer = false;
        defendTime = MaxDefendTime;
        removeDefendText();
	}
	
	// Update is called once per frame
	void Update () {
		
        if (startTimer == true)
        {
            defendTime -= Time.deltaTime;
            timeText = defendTime.ToString("0");
            defendText.text = "Defend for " + timeText.ToString() + " seconds!";
        }

        if (defendTime <= 0)
        {
            scoreObject.SaveScore();
            SceneManager.LoadScene("Win");
        }

	}



    public void beginDefendTimer()
    {
        startTimer = true;
    }

    public void removeDefendText()
    {
        defendText.text = "";
    }


}
