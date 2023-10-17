using System.Collections;
using System.Collections.Generic;
using Manager;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public bool canMove = true;
    public float moveSpeed = 6;
    public new Rigidbody2D rigidbody2D;
    public Animator animator;
    public SpriteRenderer sprite;

    private void Update()
    {
        var direction = GetDirection();
        animator.Play(GetDirection() == Vector2.zero ? "PlayerIdle" : "Player_Walk");

        rigidbody2D.gravityScale = direction.y > 0 ? 0.1f : 2f;

        sprite.flipX = direction.x switch
        {
            < 0 => true,
            > 0 => false,
            _ => sprite.flipX
        };

        if (canMove)
        {
            Move(direction);
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