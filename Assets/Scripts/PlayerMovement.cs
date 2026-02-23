using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 8f; //speed of player movement z axis
    public float jumpForce = 12f; // how much itll jump y axis
    public Transform groundCheck; // check it if its grounded so it wont jump alot
    public float groundCheckDistance = .12f;
    public Vector2 groundCheckOffset = new Vector2(0f, -.5f); //moves perpendecular line
    public LayerMask groundLayer;

    private Rigidbody2D rb; //physics
    private float horizInput; //z axis
    private bool isGrounded; //is on ground
    private SpriteRenderer spriteRenderer; //sees if sprite is rendered

    private Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //links with the rigidbody in unity scene
        spriteRenderer = GetComponent<SpriteRenderer>(); // links with the sprite renderer in unity scene
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizInput = Input.GetAxisRaw("Horizontal"); //horizin. gets the unity premade thingy

        Vector2 rayOrigin = groundCheck != null ? (Vector2)groundCheck.position : (Vector2)transform.position + groundCheckOffset;
        RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.down, groundCheckDistance, groundLayer);
        isGrounded = hit.collider != null;

        if(Input.GetButtonDown ("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
        if(spriteRenderer!=null)
        {
            if (horizInput > .1f) spriteRenderer.flipX = true;
            else if (horizInput < .1f) spriteRenderer.flipX = false;
        }

        if(animator != null)
        {
            animator.SetFloat("moveInput", Mathf.Abs(horizInput));
            animator.SetBool("isGrounded", isGrounded);

        }


    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizInput * speed, rb.linearVelocity.y);
    }
void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(groundCheck.position, groundCheck.position + Vector3.down * groundCheckDistance);
        }
        else
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position + (Vector3)groundCheckOffset, transform.position + (Vector3)groundCheckOffset + Vector3.down * groundCheckDistance);
        }
    }
}
