using TMPro;
using Unity.Netcode;
using UnityEngine;

public class PlayerCombat : NetworkBehaviour
{
    [SerializeField] GameObject bulletPrefab;

    private TextMeshProUGUI ammoText;
    private TextMeshProUGUI healthText;

    private float ammo;
    private float health;

    void Start()
    {
        ammoText = GameObject.Find("GameAmmo").GetComponent<TextMeshProUGUI>();
        healthText = GameObject.Find("GameHealth").GetComponent<TextMeshProUGUI>();

        ammo = 5f;
        health = 100f;

        ammoText.text = $"Ammo: {ammo}";
        healthText.text = $"Health: {health}";
    }

    void Update()
    {
        ammoText.color = (ammo <= 1) ? Color.red : Color.white;
        healthText.color = (health <= 20) ? Color.red : Color.white;

        if (IsOwner && Input.GetMouseButtonDown(0) && ammo > 0)
        {
            ammo -= 1;
            ammoText.text = $"Ammo: {ammo}";
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
        rb.linearVelocity = transform.forward * bulletScript.GetSpeed();

        Destroy(bulletGameObject, 2.0f);
    }
}
