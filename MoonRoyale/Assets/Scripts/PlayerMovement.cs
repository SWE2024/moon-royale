using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : NetworkBehaviour
{
    [SerializeField] private Rigidbody playerRb;
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
        
    }

    private void FixedUpdate()
    {
        if (!IsOwner) return; // stop the player being able to move other characters

        Vector3 direction = playerControls.ReadValue<Vector3>();
        Vector3 newPlayerPosition = transform.position + (direction * walkSpeed * Time.deltaTime);

        if (InBounds(newPlayerPosition))
        {
            playerRb.MovePosition(newPlayerPosition); // move the player rigidbody
            Camera.main.transform.position = new Vector3(newPlayerPosition.x, 10f, newPlayerPosition.z - 5f); // move the camera above and behind the player
        }
    }

    private bool InBounds(Vector3 position)
    {
        return position.x > -4 && position.x < 4 && position.z > -4 && position.z < 4;
    }
}
