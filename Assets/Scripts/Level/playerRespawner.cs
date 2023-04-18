using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Player;


namespace Assets.Scripts.Level
{
    public class playerRespawner : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            // respawn player
            if (collision.name == "Player(Clone)")
            {
                collision.gameObject.GetComponent<PlayerController>().Respawn();
            }
        }
    }

}
