using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 6;
    public Rigidbody2D rigidbody2D;

    private void Update()
    {
        Move(GetDirection());
    }

    private void Move(Vector2 direction)
    {
        rigidbody2D.AddForce(direction.normalized * (moveSpeed * Time.deltaTime));
    }

    private Vector2 GetDirection()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        return new Vector2(horizontal, vertical);
    }
}