using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float maxSpeed;
    [SerializeField] private float decelerationSpeed;
    [SerializeField] private Rigidbody rb;

    public void HandleMovement()
    {
        Vector3 moveAxis = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        if (moveAxis == Vector3.zero)
        {
            rb.velocity = Vector3.MoveTowards(rb.velocity, Vector2.zero, decelerationSpeed * Time.fixedDeltaTime);
        }
        else
        {
            rb.AddForce(moveAxis.normalized * maxSpeed, ForceMode.Force);

            if (rb.velocity.magnitude > maxSpeed)
            {
                rb.velocity = rb.velocity.normalized * maxSpeed;
            }
        }
    }
    public void RotatePlayer(float angle)
    {
        rb.MoveRotation(Quaternion.Euler(0, angle, 0));
    }
}
