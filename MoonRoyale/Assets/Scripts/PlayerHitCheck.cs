using System;
using Unity.Netcode;
using UnityEngine;

public class PlayerHitCheck : NetworkBehaviour
{
    void OnTriggerEnter(Collider collision)
    {
        if (OwnerClientId == collision.gameObject.GetComponentInParent<NetworkObject>().OwnerClientId) return; // ignore collisions with yourself

        try
        {
            // BULLET HIT PLAYER
            ulong attacker = OwnerClientId;
            ulong victim = collision.gameObject.GetComponentInParent<NetworkObject>().OwnerClientId;
            Debug.Log(attacker + " shot a bullet that hit " + victim);
        }
        catch (Exception) { /* bullet did not hit a player / raised an unexpected exception */ }
    }
}