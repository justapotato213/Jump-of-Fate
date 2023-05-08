using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Assets.Scripts.Menu {
    public class UpgradeMenu : MonoBehaviour
    {
        public GameObject playerStats;
        public GameObject upgradeMenu;

        private void Start()
        {
            
            
        }

        public void Disable()
        {
            upgradeMenu.SetActive(false);
        }

        public void AddSpeed()
        {
            if (playerStats != null)
            {
                playerStats.GetComponent<PlayerStats>().playerSpeed += 10;
                upgradeMenu.SetActive(false);
                Time.timeScale = 1f;
            }

        }

        public void AddHeight()
        {
            if (playerStats != null)
            {
                playerStats.GetComponent<PlayerStats>().jumpingPower += 5;
                upgradeMenu.SetActive(false);
                Time.timeScale = 1f;
            }
        }

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

