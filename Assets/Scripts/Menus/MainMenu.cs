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
        public GameObject mainMenu;

        public GameObject settingsMenu;

        public GameObject tutorialMenu;

        /// <summary>
        /// Loads the platforming game 
        /// </summary>
        public void PlayGame()
        {
            SceneManager.LoadScene("SampleScene");
        }

        public void Settings()
        {
            Debug.Log("Settings Button Pressed");
            settingsMenu.SetActive(true);
            mainMenu.SetActive(false);
        }

        public void frontMenu()
        {
            mainMenu.SetActive(true);
            settingsMenu.SetActive(false);
        }

        public void Tutorial()
        {

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
