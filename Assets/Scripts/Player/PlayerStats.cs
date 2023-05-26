using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Player;
using UnityEngine.SceneManagement;

/// <summary>
/// Allows for runtime modification of the player stats, as the player object gets destroyed between levels. 
/// </summary>
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
    /// How many jumps the player can make, after the original one 
    /// </summary>
    public int numberofJumps = 0;

    /// <summary>
    /// The game finished text.
    /// </summary>
    public GameObject finishedText;

    /// <summary>
    /// How many levels the player has beaten (backing store)
    /// </summary>
    [SerializeField]
    private int _completedLevels;

    /// <summary>
    /// Public counter for completed levels. Displays game finished text once 20 levels have been beat.
    /// </summary>
    public int CompletedLevels
    {
        get => _completedLevels;
        set
        {
            _completedLevels = value;
            // if we have beaten the game
            if (_completedLevels == 20)
            {
                // show the finished game screen
                finishedText.SetActive(true);
                // freeze time
                Time.timeScale = 0f;
                // wait time
                StartCoroutine(Wait());
            }
        }
    }

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

    /// <summary>
    /// Waits 5 seconds
    /// </summary>
    private IEnumerator Wait()
    {
        yield return new WaitForSecondsRealtime(5);
        // load scene
        SceneManager.LoadScene("MainMenu");
    }

}
