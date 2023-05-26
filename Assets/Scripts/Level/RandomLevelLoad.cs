using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
using Assets.Scripts.Menus;

namespace Assets.Scripts.Level
{
    /// <summary>
    /// Loads a random level into the scene.
    /// </summary>
    public class RandomLevelLoad : MonoBehaviour
    {
        /// <summary>
        /// Object for Finder
        /// </summary>
        public GameObject TileMap;

        /// <summary>
        /// Upgrade menu
        /// </summary>
        public GameObject upgrade;

        /// <summary>
        /// Player stats
        /// </summary>
        public GameObject playerStatsObj; 

        // Start is called before the first frame update
        void Start()
        {
            // find the tilemap
            TileMap = Finder("TileMap");
            // find the upgrade menu
            upgrade = Finder("UpgradeController");
            // find the stat controller
            playerStatsObj = Finder("StatController");
        }

        /// <summary>
        /// Trigger to determine if the player has reached the end of the level.
        /// </summary>
        /// <param name="collision">COllision that will be detected</param>
        private void OnTriggerEnter2D(Collider2D collision)
        {
            // check if the player is the one inside the box
            if (collision.name == "Player(Clone)")
            {
                // the player stats
                var playerStats = playerStatsObj.GetComponent<PlayerStats>();
                // update the completed level count
                playerStats.CompletedLevels++;

                // enable the upgrade menu, only if it is not already active, and the current level is divisible by 5, and its not the end of the game
                if (!upgrade.GetComponent<UpgradeController>().isDisabled && playerStats.CompletedLevels % 5 == 0 && playerStats.CompletedLevels != 20)
                {
                    upgrade.GetComponent<UpgradeController>().EnableMenu();
                    Time.timeScale = 0f;
                }

                // delete all tiles
                TileMap.GetComponent<Tilemap>().ClearAllTiles();

                // delete all children of tilemap
                foreach(Transform child in TileMap.transform)
                {
                    Destroy(child.gameObject);
                }

                // choose random level to load
                var levels = Resources.LoadAll("Level", typeof(Texture2D));
                Texture2D level = (Texture2D)levels[Random.Range(0, levels.Length)];

                // load random level
                LoadLevel(level);
            }
        }

        /// <summary>
        /// Loads the level into the tilemap
        /// </summary>
        /// <param name="Level">Level to load, as a png.</param>
        public void LoadLevel(Texture2D Level)
        {
            TileMap.GetComponent<WorldGen>().GameMap = Level;
            TileMap.GetComponent<WorldGen>().CreateLevels();
        }

        /// <summary>
        /// Looks for gameobject using tag
        /// </summary>
        public GameObject Finder(string tag)
        {
           return GameObject.FindGameObjectWithTag(tag);
        }
    }

}
