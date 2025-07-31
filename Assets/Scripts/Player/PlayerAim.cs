using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

public class PlayerAim : MonoBehaviour
{
    [Inject] private PlayerMovement playerMovement;
    [SerializeField] private Camera playerCamera;
    public void HandleAim()
    {
        Vector3 mouseWorldPos = playerCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0f;

        Vector3 direction = mouseWorldPos - transform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        playerMovement.RotatePlayer(angle);
    }
}
