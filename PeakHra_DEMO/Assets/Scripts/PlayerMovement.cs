using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 moveInput = Vector2.zero;
    private Rigidbody2D playerRigidbody;

    private float movementSpeed = 5f;
    public float jumpForce = 7f;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float groundCheckRadius = 0.15f;

    private bool isGrounded;



    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }
    void Start()
    {

    }

    void Update()
    {

    }

    private void FixedUpdate()
    {
        playerRigidbody.linearVelocity = new Vector2(
            moveInput.x * movementSpeed,
            playerRigidbody.linearVelocity.y
        );

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer) != null;
    }

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();

    }

    public void OnJump(InputValue value)
    {
        if (value.isPressed && isGrounded)
        {
            playerRigidbody.linearVelocity = new Vector2(
                playerRigidbody.linearVelocity.x,
                jumpForce
            );
        }
        // Shorten the jump when Space is released
        if (!value.isPressed && playerRigidbody.linearVelocity.y > 0)
        {
            playerRigidbody.linearVelocity = new Vector2(
                playerRigidbody.linearVelocity.x,
                playerRigidbody.linearVelocity.y * 0.7f
            );
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (groundCheck == null)
        {
            return;
        }

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
