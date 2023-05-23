using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyShooting : MonoBehaviour
{
    /// <summary>
    /// Projectile GameObject
    /// </summary>
    public GameObject projectile;
    /// <summary>
    /// Position of the projectile
    /// </summary>
    public Transform projectilePos;
    /// <summary>
    /// The range of where the enemy will start shooting from
    /// </summary>
    public float range;
    /// <summary>
    /// Calculates in-game time
    /// </summary>
    private float timer;
    /// <summary>
    /// Player GameObject
    /// </summary>
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            float distance = Vector2.Distance(transform.position, player.transform.position);
            // Debug.Log(distance);

            if (distance < range)
            {
                timer += Time.deltaTime;

                if (timer > 2)
                {
                    timer = 0;
                    shoot();
                }
            }
        }  
    }

    /// <summary>
    /// Creates a projectile from the enemy
    /// </summary>
    void shoot()
    {
        Instantiate(projectile, projectilePos.position, Quaternion.identity);
    }

}
