using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 6f;
    public float jumpForce = 12f;
    public Transform groundCheck;          // the small object under the feet
    public float groundRadius = 0.2f;      // size of the "feeler" circle
    public LayerMask groundLayer;          // which layer counts as ground

    private Rigidbody2D rb;
    private float moveInput;
    private bool isGrounded;
    private PlayerSFX sfx;                 // NEW

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sfx = GetComponent<PlayerSFX>();   // NEW
    }

    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");

        // is there any Ground inside the small circle under our feet?
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundLayer);

        // only jump when standing on the ground
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            if (sfx != null) sfx.PlayJump(); // NEW
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
    }

    void OnDrawGizmosSelected()
    {
        if (groundCheck == null) return;
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(groundCheck.position, groundRadius);
    }
}
