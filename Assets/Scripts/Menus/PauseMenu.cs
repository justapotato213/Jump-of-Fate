using UnityEngine;
using UnityEngine.SceneManagement;
// TODO: DOCUMENT
namespace Assets.Scripts.Menu
{
    public class PauseMenu : MonoBehaviour
    {
        public GameObject pauseMenu;

        public GameObject upgradeMenu;

        public bool isPaused = false;


        // Start is called before the first frame update
        void Start()
        {
            Debug.Log(upgradeMenu);
            pauseMenu.SetActive(false);
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

                else if(!upgradeMenu.activeSelf)
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
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            isPaused = true;
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

        /// <summary>
        /// Settings Menu 
        /// </summary>
        public void settingsMenu()
        {
            // SceneManager.LoadScene("Settings");

            // Will be finished at a later data
        }
    }
}

