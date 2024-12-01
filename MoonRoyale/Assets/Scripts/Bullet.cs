using System;
using Unity.Netcode;
using UnityEngine;

public class Bullet : NetworkBehaviour
{
    private float lifetime;

    private ulong attacker;
    private ulong target;

    private void Awake()
    {
        this.lifetime = 2f;
    }

    private void Start()
    {
        Destroy(gameObject, lifetime); // destroy the bullet after lifetime seconds
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

    private void Update()
    {
        if (IsServer)
        {
            transform.Translate(transform.position.x, 1.25f, transform.position.z);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // handle damage etc
        // destroy bullet
        Destroy(gameObject);
    }
}