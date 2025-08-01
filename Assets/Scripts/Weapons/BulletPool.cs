using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public static BulletPool Instance;
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private int initialPoolSize = 10;

    private Queue<Bullet> bulletPool = new Queue<Bullet>();

    private void Awake()
    {
        Instance = this;
        for (int i = 0; i < initialPoolSize; i++)
        {
            CreateBullet();
        }
    }

    private Bullet CreateBullet()
    {
        Bullet bullet = Instantiate(bulletPrefab, transform);
        bullet.gameObject.SetActive(false);
        bullet.SetPool(this);
        bulletPool.Enqueue(bullet);
        return bullet;
    }

    public Bullet GetBullet(Vector3 position, Quaternion rotation)
    {
        Bullet bullet = bulletPool.Count > 0 ? bulletPool.Dequeue() : CreateBullet();
        bullet.transform.SetPositionAndRotation(position, rotation);
        bullet.gameObject.SetActive(true);
        return bullet;
    }

    public void ReturnBullet(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
        bulletPool.Enqueue(bullet);
    }
}
