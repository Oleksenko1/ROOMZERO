using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float maxSpeed;
    [SerializeField] private float decelerationSpeed;
    [SerializeField] private Rigidbody2D rb;

    public void HandleMovement()
    {
        Vector2 moveAxis = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (moveAxis == Vector2.zero)
        {
            rb.velocity = Vector3.MoveTowards(rb.velocity, Vector2.zero, decelerationSpeed * Time.fixedDeltaTime);
        }
        else
        {
            rb.AddForce(moveAxis.normalized * maxSpeed, ForceMode2D.Force);

            if (rb.velocity.magnitude > maxSpeed)
            {
                rb.velocity = rb.velocity.normalized * maxSpeed;
            }
        }
    }
}
