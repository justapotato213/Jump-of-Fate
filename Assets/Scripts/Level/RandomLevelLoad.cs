using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

namespace Assets.Scripts.Level
{
    public class RandomLevelLoad : MonoBehaviour
    {
        /// <summary>
        /// BoxCollider trigger this object refers to. 
        /// </summary>
        private BoxCollider2D bc;
        /// <summary>
        /// Object for Finder
        /// </summary>
        public GameObject FoundObj;


        // Start is called before the first frame update
        void Start()
        {
            bc = gameObject.GetComponent<BoxCollider2D>();
            Finder();
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            // check if the player is the one inside the box
            if (collision.name == "Player(Clone)")
            {

                // delete all tiles
                FoundObj.GetComponent<Tilemap>().ClearAllTiles();

                // delete all children of tilemap
                foreach(Transform child in FoundObj.transform)
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

        public void LoadLevel(Texture2D Level)
        {
           
            Debug.Log(FoundObj);
            FoundObj.GetComponent<WorldGen>().GameMap = Level;
            FoundObj.GetComponent<WorldGen>().CreateLevels();
        }

        public void Finder()
        {
            if (GameObject.FindWithTag("TileMap"))
            {
                FoundObj = GameObject.FindWithTag("TileMap");
            }
        }
    }

}