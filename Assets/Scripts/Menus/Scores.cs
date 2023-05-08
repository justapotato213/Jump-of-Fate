using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        score -= Time.deltaTime;
        scoreText.text = "Score: " + Mathf.Round(score).ToString();
    }
}
    