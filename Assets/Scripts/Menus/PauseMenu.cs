/*
 * Authors: Edison and Tony
 */
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

namespace Assets.Scripts.Menu
{
    /// <summary>
    /// Controls the pause menu, and its various buttons functions. 
    /// </summary>
    public class PauseMenu : MonoBehaviour
    {
        /// <summary>
        /// The pause menu object
        /// </summary>
        public GameObject pauseMenu;

        /// <summary>
        /// Gameobject which holds the playerStats script.
        /// </summary>
        public GameObject PlayerStats;

        /// <summary>
        /// Current score
        /// </summary>
        public float score;

        /// <summary>
        /// Gameobject that stores the score
        /// </summary>
        public GameObject scoreObject;

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (Time.timeScale == 0f && pauseMenu.activeSelf)
                {
                    ResumeGame();
                }
                // timescale is modified by other things, check if it is not 0 the game is not being frozen by another thing.
                else if (Time.timeScale == 1 && !pauseMenu.activeSelf)
                {
                    PauseGame();
                }
            }
        }

        /// <summary>
        /// Returns to Main Menu
        /// </summary>
        public void mainMenu()
        {
            
            score = scoreObject.GetComponent<Scores>().score;
            PlayerPrefs.SetFloat("score", score);


            PlayerStats = GameObject.FindGameObjectWithTag("StatController");

            // save all our data
            // setup our paths and variables
            string json = JsonUtility.ToJson(PlayerStats.GetComponent<PlayerStats>());
            string destination = Application.persistentDataPath + "/save.dat";

            // check if we already have a save
            if (!File.Exists(destination)) File.Create(destination).Dispose();
   
            // write the save data
            File.WriteAllText(destination, json);

            // reset the time
            Time.timeScale = 1f;

            SceneManager.LoadScene("MainMenu");
        }

        /// <summary>
        /// Pauses the game
        /// </summary>
        public void PauseGame()
        { 
            Time.timeScale = 0f;
            pauseMenu.SetActive(true);
        }

        /// <summary>
        /// Resumes the game
        /// </summary>
        public void ResumeGame()
        {
            Time.timeScale = 1f;
            pauseMenu.SetActive(false);
        }

        /// <summary>
        /// Quits Application
        /// </summary>
        public void QuitGame()
        {
            Application.Quit();
        }
    }
}

// Citations:
// B. Zgeb, “Persistent data: How to save your game states and settings,” Unity Blog, https://blog.unity.com/games/persistent-data-how-to-save-your-game-states-and-settings 
// “Unity documentation,” Unity Documentation, https://docs.unity.com/ 

