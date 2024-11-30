using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : NetworkBehaviour
{
    private float walkSpeed;
    public InputAction playerControls;

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    private void Awake()
    {
        walkSpeed = 3.5f;
    }

    private void Update()
    {
        if (!IsOwner) return; // stop the player being able to move other characters
        Vector3 newPosition = new Vector3(0, 0, 0);

        newPosition = playerControls.ReadValue<Vector3>();

        transform.position += newPosition * walkSpeed * Time.deltaTime; // move the player
        Camera.main.transform.position += newPosition * walkSpeed * Time.deltaTime; // move the camera
    }
}
