using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed = 6;
    public float jumpSpeed = 10;
    public bool isGrounded = false;
    // These variables are to hold the Action references
    InputAction moveAction;
    InputAction jumpAction;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Method to find the Rigidbody2D component attached to the GameObject
        // Find the references to the "Move" and "Jump" actions
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");
    }

    void Update() // Each frame e.g. 60 Hz
    {
        // Read the "Move" action value, which is a 2D vector
        Vector2 moveValue = moveAction.ReadValue<Vector2>();

        rb.linearVelocityX = moveValue.x * moveSpeed;

        if (jumpAction.IsPressed())
        {
            Debug.Log("IsPressed");
        }
        //JumpPressed AND IsGrounded
        //if (boolean expression) {CONTENTS} will execute statements following if the bool expression evaluates to true
        if (jumpAction.WasPressedThisFrame() && isGrounded)
        {
            rb.linearVelocityY = jumpSpeed;
           // isGrounded = false;
            Debug.Log("WasPressedThisFrame");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }
}
