using Unity.Netcode;
using UnityEngine;

public class PlayerCombat : NetworkBehaviour
{
    [SerializeField] Rigidbody bullet;
    private float speed;

    void Start()
    {
        speed = 20.0f;
    }

    void Update()
    {
        if (!IsOwner) return;

        if (Input.GetMouseButtonDown(0))
        {
            Rigidbody p = Instantiate(bullet, new Vector3(transform.position.x, 1.25f, transform.position.z), transform.rotation, transform); // create the bullet at players position
            p.linearVelocity = transform.forward * speed;

            
            Destroy(p.gameObject, 2.0f); // destroy the bullet from memory after 2s 
        }
    }
}
