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

    // Start is called before the first frame update
    void Awake()
    {
        // do not delete this 
        DontDestroyOnLoad(transform.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        score -= Time.deltaTime;
        scoreText.text = "Score: " + Mathf.Round(score).ToString();
    }
}
    