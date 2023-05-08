using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Player;

public class PlayerStats : MonoBehaviour
{
    // janky workaround to get upgrades to work
    /// <summary>
    /// The players speed
    /// </summary>
    public int playerSpeed = 13;

    /// <summary>
    /// The players jumping power
    /// </summary>
    public int jumpingPower = 26;

    /// <summary>
    /// How many jumps the player can make
    /// </summary>
    public int numberofJumps = 0;

    // if we ever polish, change this to be more efficient, run only once level has finished loading
    // or change to different system rather than a workaround
    private void Update()
    {
        GameObject player = GameObject.FindWithTag("Player");

        if (player != null)
        {
            var script = player.GetComponent<PlayerController>();

            script.speed = playerSpeed;
            script.jumpingPower = jumpingPower;
            script.numberOfAdditionalJumps = numberofJumps;
        }
    }
}
