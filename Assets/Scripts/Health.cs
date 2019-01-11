using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Using statement for the unity UI code
using UnityEngine.UI;



public class Health : MonoBehaviour
{

    // Variable to track the visible text health
    //      Public to let us drag and drop in the editor
    public Text healthText;

    // Variable to track the numerical health
    //      Private because other scripts should not 
    //          change it directly
    //      Default to 100 
    //          health when starting
    private int numericalHealth = 100;
    private int numericalMaxHealth = 100;



    // Use this for initialization
    void Start()
    {
        // Get the health from the prefs database
        // Use a default of 100 of no lives was saved
        // Store the result in our numerical health variable
        numericalHealth = PlayerPrefs.GetInt("health", 100);
        //numericalHealth = numericalMaxHealth;

        ResetHealth();

        // Update the visual health
        healthText.text = numericalHealth.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        // Update the visual health
        healthText.text = numericalHealth.ToString();
    }






    // Function to lose a live
    //      Public so other scripts can use it
    public void LoseHealth()
    {
        // Reduce the amount to the numerical health
        numericalHealth = numericalHealth - 10;

        // Update the visual health
        healthText.text = numericalHealth.ToString();
    }



    // Function to save the health to the player preferences
    //      Public so it can be triggered from another script (aka door)
    public void SaveHealth()
    {
        PlayerPrefs.SetInt("health", numericalHealth);
    }


    public void ResetHealth()
    {
        //PlayerPrefs.SetInt("health", 100);
        numericalHealth = numericalMaxHealth;
    }



    public void UpdateHealthText()
    {
        healthText.text = numericalHealth.ToString();
    }


    public bool IsNoHealth()
    {
        if (numericalHealth <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }




}
