using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

public class PlayerController : MonoBehaviour
{
    [Inject] private PlayerMovement _movement;
    [Inject] private PlayerAim _aim;
    [Inject] private PlayerWeaponController _weapon;
    void Update()
    {
        _weapon.HandleWeaponControl();
    }
    void FixedUpdate()
    {
        _movement.HandleMovement();
        _aim.HandleAim();
    }
}
