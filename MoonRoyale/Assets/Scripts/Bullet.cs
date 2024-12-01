using Unity.Netcode;
using UnityEngine;

public class Bullet : NetworkBehaviour
{
    private ulong attacker;
    private ulong target;

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

    private void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        target = collision.gameObject.GetComponentInParent<NetworkObject>().OwnerClientId;

        // handle damage etc
        if (attacker == target)
        {
            Debug.Log($"{attacker} shot");
        } 
        else
        {
            Debug.Log($"{attacker} hit {target}");
        }
    }
}