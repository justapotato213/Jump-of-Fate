/*
 * Authors: Tony 
 */
using UnityEngine;

namespace Assets.Scripts.Menus {
    /// <summary>
    /// Controls the various stats of the player
    /// </summary>
    public class UpgradeMenu : MonoBehaviour
    {
        /// <summary>
        /// The object which contains the players stats
        /// </summary>
        public GameObject playerStats;
        /// <summary>
        /// The upgrade menu object
        /// </summary>
        public GameObject upgradeMenu;

        /// <summary>
        /// Increase the speed of the player by 10
        /// </summary>
        public void AddSpeed()
        {
            if (playerStats != null)
            {
                playerStats.GetComponent<PlayerStats>().playerSpeed += 10;
                upgradeMenu.SetActive(false);
                Time.timeScale = 1f;
            }
        }

        /// <summary>
        /// Increase the jumping power of the player by 5
        /// </summary>
        public void AddHeight()
        {
            if (playerStats != null)
            {
                playerStats.GetComponent<PlayerStats>().jumpingPower += 5;
                upgradeMenu.SetActive(false);
                Time.timeScale = 1f;
            }
        }

        /// <summary>
        /// Increase the number of jumps
        /// </summary>
        public void AddJumps()
        {
            if (playerStats != null)
            {
                playerStats.GetComponent<PlayerStats>().numberofJumps += 1;
                upgradeMenu.SetActive(false);
                Time.timeScale = 1f;
            }
        }
    }
}

// Citations: 
// “Unity documentation,” Unity Documentation, https://docs.unity.com/ 