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
        /// Loads the platforming game 
        /// </summary>
        public void PlayGame()
        {
            SceneManager.LoadScene("SampleScene");
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
