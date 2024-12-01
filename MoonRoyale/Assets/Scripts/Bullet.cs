using Unity.Netcode;
using UnityEngine;

public class Bullet : NetworkBehaviour
{
    private ulong attacker;
    private ulong target;

    private float speed;

    private void Awake()
    {
        speed = 25.0f;
    }

    public void SetAttacker(ulong attacker)
    {
        this.attacker = attacker;
    }

    public void SetTarget(ulong target)
    {
        this.target = target;
    }

    public ulong GetAttacker()
    {
        return attacker;
    }

    public ulong GetTarget()
    {
        return target;
    }

    public float GetSpeed()
    {
        return speed;
    }

    private void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        target = collision.gameObject.GetComponentInParent<NetworkObject>().OwnerClientId;

        if (attacker != target)
        {
            // handle shot here
            Debug.Log($"{attacker} hit {target}");
        }
    }
}