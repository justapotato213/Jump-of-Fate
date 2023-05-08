using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Assets.Scripts.Menu
{
    public class MainMenu : MonoBehaviour
    {
        /// <summary>
        /// Loads the platforming game 
        /// </summary>
        public void PlayGame()
        {
            Debug.Log("Play Button Pressed");
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
