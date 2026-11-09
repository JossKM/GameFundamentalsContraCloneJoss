using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCharacterControls : MonoBehaviour
{
    public Spawner gun = null; // by default a null reference. 

    InputAction attackAction;
    InputAction moveAimAction;

    private void Start()
    {
        attackAction = InputSystem.actions.FindAction("Attack");
        moveAimAction = InputSystem.actions.FindAction("Move");
    }

    // Update is called once per frame
    void Update()
    {
        gun.isSpawning = attackAction.IsPressed();
        Vector2 moveAimValue = moveAimAction.ReadValue<Vector2>();
        gun.transform.right = moveAimValue;
        Debug.DrawRay(gun.transform.position, moveAimValue * 2, Color.red); // draw the input vector
    }
}
