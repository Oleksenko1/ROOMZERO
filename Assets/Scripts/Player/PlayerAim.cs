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
        Vector3 mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = playerCamera.transform.position.y - transform.position.y;

        Vector3 mouseWorldPos = playerCamera.ScreenToWorldPoint(mouseScreenPos);
        mouseWorldPos.y = transform.position.y;

        Vector3 direction = mouseWorldPos - transform.position;
        float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;

        playerMovement.RotatePlayer(angle);
    }
}
