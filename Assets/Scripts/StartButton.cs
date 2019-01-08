using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This allows us to use the scene loading function
using UnityEngine.SceneManagement;


public class StartButton : MonoBehaviour
{

    //This will be called by the Button Component when the button is clicked
    public void StartGame()
    {
        //Reset the score
        PlayerPrefs.DeleteKey("score");

        //Reset the lives
        PlayerPrefs.DeleteKey("lives");

        //Reset the playe heath
        PlayerPrefs.DeleteKey("health");

        //Load the first level
        SceneManager.LoadScene("Testing");
    }




}
