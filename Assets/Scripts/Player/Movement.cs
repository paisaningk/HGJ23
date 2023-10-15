using System.Collections;
using System.Collections.Generic;
using Manager;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public bool canMove = true;
    public float moveSpeed = 6;
    public new Rigidbody2D rigidbody2D;

    private void Update()
    {
        if (canMove)
        {
            Move(GetDirection());
        }
        
    }

    private void Move(Vector2 direction)
    {
        rigidbody2D.AddForce(direction.normalized * (moveSpeed * Time.deltaTime));
    }

    private Vector2 GetDirection()
    {
        return new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    public void SetCanMove(bool move)
    {
        canMove = move;
    }

    public void StartMove()
    {
        canMove = true;
        rigidbody2D.simulated = true;
    }

    public void StopMove()
    {
        canMove = false;
        rigidbody2D.velocity = Vector2.zero;
        rigidbody2D.simulated = false;
    }
}