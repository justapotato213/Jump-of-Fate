using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Camera
{
    public class PlayerStartUp : MonoBehaviour
    {
        public GameObject foundObj;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            Finder();
            if (foundObj != null)
            {
                GetComponent<PlayerController>().respawnPoint = foundObj;
                Destroy(this);
            }

        }

        public void Finder()
        {
            if (GameObject.FindWithTag("Respawn"))
            {
                foundObj = GameObject.FindWithTag("Respawn");
            }
        }
    }
}