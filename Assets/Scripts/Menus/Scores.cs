using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Controls the score
/// </summary>
public class Scores : MonoBehaviour
{
    /// <summary>
    /// Text object to modify
    /// </summary>
    public TextMeshProUGUI scoreText;
    /// <summary>
    /// Score system using time
    /// </summary>
    public float score;

    private void Start()
    {
        // check if we have a score saved
        if (PlayerPrefs.HasKey("score"))
        {
            // load said score
            score = PlayerPrefs.GetFloat("score");
        }
    }

    // Update is called once per frame
    private void Update()
    {
        score -= Time.deltaTime;
        scoreText.text = "Score: " + Mathf.Round(score).ToString();
    }
}
    