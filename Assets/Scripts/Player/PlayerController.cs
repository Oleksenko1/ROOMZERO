using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

public class PlayerController : MonoBehaviour
{
    [Inject] private PlayerMovement _movement;
    [Inject] private PlayerAim _aim;
    void Update()
    {

    }
    void FixedUpdate()
    {
        _movement.HandleMovement();
        _aim.HandleAim();
    }
}
