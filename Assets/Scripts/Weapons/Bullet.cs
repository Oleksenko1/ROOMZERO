using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Collider collider;
    private BulletPool pool;
    private LayerMask targetLayer;
    public LayerMask TargetLayer => targetLayer;
    public void SetPool(BulletPool pool)
    {
        this.pool = pool;
    }
    public void Shoot(LayerMask friendlyLayer, LayerMask targetLayer, float moveSpeed)
    {
        this.targetLayer = targetLayer;

        rb.velocity = transform.forward * moveSpeed;

        collider.excludeLayers = friendlyLayer;
    }
    void OnTriggerEnter(Collider collision)
    {
        pool.ReturnBullet(this);
    }
}
