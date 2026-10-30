using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 moveInput = Vector2.zero;
    private Rigidbody2D playerRigidbody;

    private float movementSpeed = 5f;



    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        playerRigidbody.linearVelocity = new Vector2(
            moveInput.x * movementSpeed,
            playerRigidbody.linearVelocity.y
        );
    }

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        
    }
}
