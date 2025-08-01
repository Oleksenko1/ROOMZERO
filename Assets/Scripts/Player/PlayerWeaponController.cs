using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour
{
    [SerializeField] private Gun weapon;
    void Awake()
    {
        weapon.InitializeWeapon();
    }
    public void HandleWeaponControl()
    {
        if (Input.GetMouseButtonDown(0))
        {
            weapon.Fire();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            weapon.Reload();
        }
    }
    public Gun GetWeapon() => weapon;
}
