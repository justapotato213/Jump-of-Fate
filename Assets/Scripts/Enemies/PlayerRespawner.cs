/*
 * Authors: Tony 
 */
using UnityEngine;
using Assets.Scripts.Player;


namespace Assets.Scripts.Level
{
    /// <summary>
    /// Respawns the player if it enters this trigger
    /// </summary>
    public class PlayerRespawner : MonoBehaviour
    {
        /// <summary>
        /// Respawns the player
        /// </summary>
        /// <param name="collision">The collider which collided with this object</param>
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

// Citations:
// “Unity documentation,” Unity Documentation, https://docs.unity.com/ 
