using UnityEngine;

// TODO: 
// Optimize, currently will run forever, needed due to level loading reseting the player

namespace Assets.Scripts.Camera
{
    /// <summary>
    /// Assigns proper objects and prefabs to the camera on startup.
    /// </summary>
    public class CameraStartUp : MonoBehaviour
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

            if (foundObj != null)
            {
                // set the proper variable
                GetComponent<FollowPlayer>().target = foundObj.transform;
            }
        }

        /// <summary>
        /// Looks for objects with the player tag
        /// </summary>
        public void Finder()
        {
            // look for player tag
            if (GameObject.FindWithTag("Player"))
            {
                // exists, set as variable
                foundObj = GameObject.FindWithTag("Player");
            }
        }
    }
}