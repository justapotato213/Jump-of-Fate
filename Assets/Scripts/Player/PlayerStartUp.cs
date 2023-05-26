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
            foundObj = GameObject.FindWithTag("Respawn");
            if (foundObj != null)
            {
                // set the proper variable
                GetComponent<PlayerController>().respawnPoint = foundObj;
            }

        }
    }
}