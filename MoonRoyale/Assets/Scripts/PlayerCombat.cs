using Unity.Netcode;
using UnityEngine;

public class PlayerCombat : NetworkBehaviour
{
    [SerializeField] GameObject bulletPrefab;
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
            Vector3 direction = new Vector3(transform.position.x, 1.25f, transform.position.z);
            FireBulletServerRpc();
        }
    }

    [ServerRpc]
    void FireBulletServerRpc()
    {
        if (!IsServer) return;

        GameObject bulletGameObject = Instantiate(bulletPrefab, new Vector3(transform.position.x, 1.25f, transform.position.z), transform.rotation);

        NetworkObject bulletNetworkObject = bulletGameObject.GetComponent<NetworkObject>();
        bulletNetworkObject.Spawn();

        Rigidbody rb = bulletGameObject.GetComponent<Rigidbody>();
        rb.linearVelocity = transform.forward * speed;

        Destroy(bulletGameObject, 2.0f);
    }
}
