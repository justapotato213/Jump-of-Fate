/*
 * Authors: Tony 
 */
using UnityEngine;

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

// Citations:
// “Unity documentation,” Unity Documentation, https://docs.unity.com/ 