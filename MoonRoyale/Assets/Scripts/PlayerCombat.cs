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
            Rigidbody bulletObject = Instantiate(bullet, new Vector3(transform.position.x, 1.25f, transform.position.z), transform.rotation); // create the bullet at players position

            Bullet bulletScript = bulletObject.GetComponent<Bullet>();
            bulletScript.SetAttacker(OwnerClientId);

            Debug.Log($"{OwnerClientId} shot a bullet");

            bulletObject.linearVelocity = transform.forward * speed;

            Destroy(bulletObject.gameObject, 2.0f); // destroy the bullet from memory after 2s 
        }
    }
}
