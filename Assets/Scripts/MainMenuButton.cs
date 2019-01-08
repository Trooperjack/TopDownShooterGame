﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This allows us to use the scene loading function
using UnityEngine.SceneManagement;


public class MainMenuButton : MonoBehaviour
{

    //This will be called by the Button Component when the button is clicked
    public void GoToMainMenu()
    {
        //Load the high score menu
        SceneManager.LoadScene("MainMenu");
    }




}
