using System;
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
    
    void OnTriggerEnter(Collider collision)
    {
        if (attacker == collision.gameObject.GetComponentInParent<NetworkObject>().OwnerClientId) return; // ignore collisions with yourself

        try
        {
            // BULLET HIT PLAYER
            target = collision.gameObject.GetComponentInParent<NetworkObject>().OwnerClientId;
            Debug.Log(attacker + " hit " + target);
        }
        catch (Exception) { /* bullet did not hit a player / raised an unexpected exception */ }
    }
}