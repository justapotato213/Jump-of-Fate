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

    // Update is called once per frame
    void Update()
    {
        score -= Time.deltaTime;
        // Checks if score is below 0
        if (score < 0)
        {
            score = 0;
        }
        scoreText.text = "Score: " + Mathf.Round(score).ToString();
    }
}
    