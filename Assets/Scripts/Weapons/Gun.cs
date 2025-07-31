using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gun : Weapon
{
    [SerializeField] protected Transform shotPoint;
    protected BulletPool bulletPool;
    public event Action OnReload;
    [Header("Gun stats")]
    public int magazineCapacity;
    public float reloadTime;
    public float shotSpeed;
    [HideInInspector] public bool isReloading;
    [HideInInspector] public int magazineBullets;
    protected override void OnStart()
    {
        bulletPool = BulletPool.Instance;
    }
    protected void CallOnReload()
    {
        OnReload?.Invoke();
    }
}
