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

    // Update is called once per frame
    void Update()
    {
        
    }
}
