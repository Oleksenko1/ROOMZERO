using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public event Action OnFire;
    public string weaponName;
    public float atackDelay;
    protected float lastShotTime = 0;
    [Space(10)]
    public LayerMask friendlyLayer;
    public LayerMask enemyLayer;
    public abstract void InitializeWeapon();
    public abstract void Fire();
    public abstract void Reload();
    void Start()
    {
        OnStart();
    }
    protected virtual void OnStart() { }
    protected void CallOnFire()
    {
        OnFire?.Invoke();
    }
    public virtual bool CanShoot() => true;
}
