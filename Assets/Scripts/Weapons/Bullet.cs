using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Collider2D collider2D;
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

        rb.velocity = transform.right * moveSpeed;

        // Ignore collisions with friendly layers
        collider2D.excludeLayers = friendlyLayer;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        pool.ReturnBullet(this);
    }
}
