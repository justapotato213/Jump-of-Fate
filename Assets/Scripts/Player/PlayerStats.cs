using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Player;
using UnityEngine.SceneManagement;
using System.IO;
using Assets.Scripts.Menu;

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
    public FinishText finishedTextController;

    /// <summary>
    /// Load player data on start
    /// </summary>
    public void Start()
    {
        // save file path
        string destination = Application.persistentDataPath + "/save.dat";
        // check if it exists
        if (File.Exists(destination))
        {
            // overwrite it with the loaded save data
            string json = File.ReadAllText(destination);
            JsonUtility.FromJsonOverwrite(json, this);

            // sadly, game objects can't be serialized so we have to make a controller, and use that
            var canvas = GameObject.FindWithTag("Canvas");
            finishedTextController = canvas.GetComponent<FinishText>();
        }
    }

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

                // delete save file
                string path = Application.persistentDataPath + "/save.dat";
                if (File.Exists(path))
                {
                    Debug.Log(path);
                    File.Delete(path);
                }
                
                // show the finished game screen
                finishedTextController.EnableText();
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
