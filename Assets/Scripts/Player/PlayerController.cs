using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

public class PlayerController : MonoBehaviour, IKillable
{
    [Inject] private PlayerMovement _movement;
    [Inject] private PlayerAim _aim;
    [Inject] private PlayerWeaponController _weapon;
    private bool isAlive = true;
    void Update()
    {
        if (!isAlive) return;

        _weapon.HandleWeaponControl();
    }
    void FixedUpdate()
    {
        if (!isAlive) return;

        _movement.HandleMovement();
        _aim.HandleAim();
    }

    public void Kill()
    {
        isAlive = false;
    }
}
