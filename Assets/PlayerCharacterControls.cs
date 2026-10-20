using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCharacterControls : MonoBehaviour
{
    public Spawner gun = null; // by default a null reference. 

    InputAction attackAction;

    private void Start()
    {
        attackAction = InputSystem.actions.FindAction("Attack");
    }

    // Update is called once per frame
    void Update()
    {
        gun.isSpawning = attackAction.IsPressed();
    }
}
