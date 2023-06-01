using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Assets.Scripts.Menu
{
    /// <summary>
    /// Controls the main menu, and its buttons
    /// </summary>
    public class MainMenu : MonoBehaviour
    {
        /// <summary>
        /// Main menu object
        /// </summary>
        public GameObject mainMenu;

        /// <summary>
        /// Settings menu object
        /// </summary>
        public GameObject settingsMenu;

        /// <summary>
        /// Tutorials menu object
        /// </summary>
        public GameObject tutorialMenu;

        /// <summary>
        /// Loads the platforming game 
        /// </summary>
        public void PlayGame()
        {
            SceneManager.LoadScene("SampleScene");
        }

        /// <summary>
        /// Opens the settings menu
        /// </summary>
        public void Settings()
        {
            Debug.Log("Settings Button Pressed");
            settingsMenu.SetActive(true);
            tutorialMenu.SetActive(false);
            mainMenu.SetActive(false);
        }

        /// <summary>
        /// Opens the main menu
        /// </summary>
        public void frontMenu()
        {
            mainMenu.SetActive(true);
            settingsMenu.SetActive(false);
            tutorialMenu.SetActive(false);
        }

        /// <summary>
        /// Opens the tutorial menu
        /// </summary>
        public void Tutorial()
        {
            mainMenu.SetActive(false);
            tutorialMenu.SetActive(true);
            settingsMenu.SetActive(false);
        }
        /// <summary>
        /// Closes the application
        /// </summary>
        public void QuitGame()
        {
            Application.Quit();
        }
    }

}
