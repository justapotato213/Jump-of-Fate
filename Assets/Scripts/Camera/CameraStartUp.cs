﻿using UnityEngine;

namespace Assets.Scripts.Camera
{
    /// <summary>
    /// Assigns proper objects and prefabs to the camera, and deletes itself once done
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
            // found it
            if (foundObj != null ) 
            {
                // set the proper variable
                GetComponent<FollowPlayer>().target = foundObj.transform;
                // delete self from gameObject
                Destroy(this);
            }

        }

        /// <summary>
        /// Looks for objects with the player tag
        /// </summary>
        public void Finder()
        {
            // look for respawn tag
            if (GameObject.FindWithTag("Player"))
            {
                // exists, set as variable
                foundObj = GameObject.FindWithTag("Player");
            }
        }
    }
}