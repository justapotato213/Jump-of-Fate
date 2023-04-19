using UnityEngine;

// TODO: 
// Optimize, currently will run forever, needed due to level loading reseting the player

namespace Assets.Scripts.Player
{
    /// <summary>
    /// Assigns proper objects and prefabs to the PlayerController, and deletes itself once done
    /// </summary>
    public class PlayerStartUp : MonoBehaviour
    {
        /// <summary>
        /// Object script looks for
        /// </summary>
        public GameObject foundObj;

        // Update is called once per frame
        void Update()
        {
            // find the object
            Finder();
            // found it
            if (foundObj != null)
            {
                // set the proper variable
                GetComponent<PlayerController>().respawnPoint = foundObj;
                // delete self from gameObject
                // Destroy(this);
            }

        }
        /// <summary>
        /// Looks for objects with the respawn tag
        /// </summary>
        public void Finder()
        {
            // look for respawn tag
            if (GameObject.FindWithTag("Respawn"))
            {
                // exists, set as variable
                foundObj = GameObject.FindWithTag("Respawn");
            }
        }
    }
}