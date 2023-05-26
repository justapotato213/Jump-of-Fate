using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls the Finish text
/// </summary>
public class FinishText : MonoBehaviour
{
    /// <summary>
    /// finishedText Game Object
    /// </summary>
    public GameObject finishText;

    /// <summary>
    /// Enables the finish text in unity
    /// </summary>
    public void EnableText()
    {
        finishText.SetActive(true);
    }
}
