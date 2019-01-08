using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Using statement for the unity UI code
using UnityEngine.UI;



public class Lives : MonoBehaviour
{

    // Variable to track the visible text lives
    //      Public to let us drag and drop in the editor
    public Text livesText;

    // Variable to track the numerical lives
    //      Private because other scripts should not 
    //          change it directly
    //      Default to 3 
    //          lives when starting
    private int numericalLives = 3;



    // Use this for initialization
    void Start()
    {
        // Get the lives from the prefs database
        // Use a default of 3 of no lives was saved
        // Store the result in our numerical lives variable
        numericalLives = PlayerPrefs.GetInt("lives", 3);

        // Update the visual lives
        livesText.text = numericalLives.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }







    // Function to lose a live
    //      Public so other scripts can use it
    public void LoseLife()
    {
        // Reduce the amount to the numerical lives
        numericalLives = numericalLives - 1;

        // Update the visual lives
        livesText.text = numericalLives.ToString();
    }



    // Function to save the lives to the player preferences
    //      Public so it can be triggered from another script (aka door)
    public void SaveLives()
    {
        PlayerPrefs.SetInt("lives", numericalLives);
    }



    public bool IsGameOver()
    {
        if (numericalLives <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }




}
