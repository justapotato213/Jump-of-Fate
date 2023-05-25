using UnityEngine;
using UnityEngine.SceneManagement;

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
        /// Whether the game is currently paused
        /// </summary>
        public bool isPaused = false;


        // Start is called before the first frame update
        void Start()
        {
            Time.timeScale = 1f;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (isPaused)
                {
                    ResumeGame();
                }
                else if (Time.timeScale == 1 && !isPaused)
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
            SceneManager.LoadScene("MainMenu");
        }

        /// <summary>
        /// Pauses the game
        /// </summary>
        public void PauseGame()
        { 
            Time.timeScale = 0f;
            isPaused = true;
            pauseMenu.SetActive(true);
        }

        /// <summary>
        /// Resumes the game
        /// </summary>
        public void ResumeGame()
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
            isPaused = false;
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

