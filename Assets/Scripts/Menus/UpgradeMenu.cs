using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Player;



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

        private void Start()
        {
            // when we start, get the user to choose an upgrade
            upgradeMenu.SetActive(true);
            Time.timeScale = 0f;
        }

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

