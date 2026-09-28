using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    //Movement speed in m/s
    public float moveSpeed = 5.0f;
    public float jumpSpeed = 20.0f;
    public bool isGrounded = false;

    // Reference to Rigidbody2D
    public Rigidbody2D rb;

    // These variables are to hold the Action references
    InputAction moveAction;
    InputAction jumpAction;

    private void Start()
    {
        // Get reference to the Rigidbody2D component attached to this GameObject
        rb = GetComponent<Rigidbody2D>(); 
       
        // Find the references to the "Move" action
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");
    }

    void Update() // called every frame, e.g. 60Hz
    {
        // Read the "Move" action value, which is a 2D vector
        Vector2 moveValue = moveAction.ReadValue<Vector2>(); //function call to the ReadValue method of moveAction
        
        rb.linearVelocityX = moveValue.x * moveSpeed;
        //rb.linearVelocity = new Vector2(moveValue.x * moveSpeed, rb.linearVelocity.y); //altenrative way to do the same as above
        
        if (jumpAction.WasPressedThisFrame() && isGrounded)
        {
            rb.linearVelocityY = jumpSpeed;
            isGrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
    }
}
