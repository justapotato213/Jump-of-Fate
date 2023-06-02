using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Disables object on startup
/// </summary>
public class DisableOnStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.gameObject.SetActive(false);
    }
}

// Citations: 
// “Unity documentation,” Unity Documentation, https://docs.unity.com/ 