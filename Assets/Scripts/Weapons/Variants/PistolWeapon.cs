using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using System;

public class PistolWeapon : Gun
{
    public override void InitializeWeapon()
    {
        magazineBullets = magazineCapacity;
        lastShotTime = 0;
    }
    public override void Fire()
    {
        if (!CanShoot()) return;

        Vector3 rotation = shotPoint.eulerAngles;
        Bullet bullet = bulletPool.GetBullet(shotPoint.position, shotPoint.rotation);
        bullet.Shoot(friendlyLayer, targetLayer, shotSpeed);
        magazineBullets--;

        lastShotTime = Time.time;
    }
    public override void Reload()
    {
        if (!isReloading && magazineBullets != magazineCapacity)
        {
            isReloading = true;
            DOVirtual.DelayedCall(2f, () =>
            {
                isReloading = false;
                magazineBullets = magazineCapacity;
                CallOnReload();
            });
        }
    }
    public override bool CanShoot()
    {
        return !isReloading &&
                magazineBullets > 0 &&
                (Time.time - lastShotTime) >= atackDelay;
    }
}
