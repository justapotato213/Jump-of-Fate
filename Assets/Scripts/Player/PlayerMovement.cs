using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    /// <summary>
    /// Direction of the character
    /// </summary>
    private float horizontal;
    /// <summary>
    /// Speed of the character
    /// </summary>
    public float speed = 8f;
    /// <summary>
    /// Jumping force of the character
    /// </summary>
    public float jumpingPower = 16f;
    /// <summary>
    /// Direction of the character
    /// </summary>
    private bool isFacingRight = true;

    /// <summary>
    /// How long the character can get a jump in, after walking off an edge
    /// </summary>
    public float hangTime = 0.15f;
    /// <summary>
    /// Counts how long since the character was grounded
    /// </summary>
    private float hangCounter = 0.2f;

    /// <summary>
    /// Respawn point of the character
    /// </summary>
    public Transform respawnPoint;


    /// <summary>
    /// Rigidbody belonging to character
    /// </summary>
    [SerializeField] private Rigidbody2D rb;
    /// <summary>
    /// GroundCheck object belonging to character
    /// </summary>
    [SerializeField] private Transform groundCheck;
    /// <summary>
    /// Ground layer
    /// </summary>
    [SerializeField] private LayerMask groundLayer;

    void Update()
    {
        // checking direction of character
        horizontal = Input.GetAxisRaw("Horizontal");

        // hang time
        CalcHangTime();
        // jumping 
        Jump();
        // check for flip, and flip them
        Flip();
        // TODO: change later to reflect proper level y positions
        if (rb.position.y <= -50)
        {
            Respawn();
        }
    }

    private void FixedUpdate()
    {
        // changing their velocity
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    /// <summary>
    /// Checks if they are grounded, using an OverlapCircle, and whether it intersected with the ground layer
    /// </summary>
    /// <returns></returns>
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    /// <summary>
    /// Checks if character is going to flip, and if so changes necessary variables
    /// </summary>
    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    /// <summary>
    /// Calculates how much hang time the player has
    /// </summary>
    private void CalcHangTime()
    {
        // checks if its grounded, and if so reset their hang counter
        if (IsGrounded())
        {
            hangCounter = hangTime;
        }
        // otherwise, minus the elapsed time
        else
        {
            hangCounter -= Time.deltaTime;
        }
    }

    /// <summary>
    /// Allows the player to jump, checking for hangtime as well as velocity
    /// </summary>
    private void Jump()
    {
        // allows them to jump if they are hanging, and don't already have a positive y velocity
        if (Input.GetButtonDown("Jump") && hangCounter > 0 && rb.velocity.y <= 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }
        // checking if they let go during their jump, if so, make them lose y velocity
        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

    }

    /// <summary>
    /// Forces character class to teleport to its respawnPoint
    /// </summary>
    public void Respawn()
    {

        rb.position = respawnPoint.position;
    }
}
