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
        if (IsOwner && Input.GetMouseButtonDown(0))
        {
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

        Bullet bulletScript = bulletGameObject.GetComponent<Bullet>();
        bulletScript.SetAttacker(OwnerClientId);

        Rigidbody rb = bulletGameObject.GetComponent<Rigidbody>();
        rb.linearVelocity = transform.forward * speed;

        Destroy(bulletGameObject, 2.0f);
    }
}
