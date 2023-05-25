using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Player;

/// <summary>
/// Controls the projectile itself.
/// </summary>
public class ProjectileScript : MonoBehaviour
{
    /// <summary>
    /// Player GameObject
    /// </summary>
    private GameObject player;
    /// <summary>
    /// Body of the projectile
    /// </summary>
    private Rigidbody2D rb;
    /// <summary>
    /// The speed of the projectile
    /// </summary>
    public float force;
    /// <summary>
    /// The layer of the ground
    /// </summary>
    public LayerMask layer;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectsWithTag("Player")[0];
        // apply a force towards the player on startup
        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        // destroy itself if it times out
        if (timer > 10)
        {
            Destroy(gameObject);
        }
        
        // hit the ground, destroy itself
        if (Physics2D.OverlapCircle(rb.position, 0.25f, layer))
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Detects collisions between player and projectile
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // respawn player
        if (collision.name == "Player(Clone)")
        {
            collision.gameObject.GetComponent<PlayerController>().Respawn();
            Destroy(gameObject);
        }
    }
}
