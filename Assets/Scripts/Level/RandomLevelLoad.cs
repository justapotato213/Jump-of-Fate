using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
using Assets.Scripts.Menu;

namespace Assets.Scripts.Level
{
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


        // Start is called before the first frame update
        void Start()
        {
            // find the tilemap
            TileMap = Finder("TileMap");
            // find the upgrade menu
            upgrade = Finder("UpgradeMenu");
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
                Debug.Log(upgrade.activeSelf);
                // enable the upgrade menu, only if it is not already active
                if (!upgrade.activeSelf)
                {
                    upgrade.SetActive(true);
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
           
            Debug.Log(TileMap);
            TileMap.GetComponent<WorldGen>().GameMap = Level;
            TileMap.GetComponent<WorldGen>().CreateLevels();
        }

        /// <summary>
        /// Looks for gameobject using tag
        /// </summary>
        public GameObject Finder(string tag)
        {
            if (GameObject.FindWithTag(tag))
            {
                return GameObject.FindWithTag(tag);
            }
            return null;
        }
    }

}
