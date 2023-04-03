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
    /// Controls how offset the camera is in the x direction
    /// </summary>
    public float camOffset = 4;
    /// <summary>
    /// Controls how fast the camera shifts to the new offset
    /// </summary>
    public float camSpeed = 3;
    /// <summary>
    /// The camera's target position
    /// </summary>
    public Transform cameraTarget;



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
}
