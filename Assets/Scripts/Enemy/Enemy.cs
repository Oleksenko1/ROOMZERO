using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D collision)
    {
        Bullet bullet = collision.gameObject.GetComponent<Bullet>();
        if (bullet != null)
        {
            int enemyLayerBit = 1 << gameObject.layer;

            if ((bullet.TargetLayer.value & enemyLayerBit) != 0)
            {
                Debug.Log("Enemy damaged");
            }
        }
    }
}
