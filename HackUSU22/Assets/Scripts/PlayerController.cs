using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public float moveSpeedForwards = 10;
    public float moveSpeedBackwards = 5;
    public float jumpForce;
    public LayerMask ground;
    public Animator animator;

    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;

    private float health = 100;

    private float dirX;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");

        if (dirX > 0) {
            rb.velocity = new Vector2 (dirX * moveSpeedForwards, rb.velocity.y);
        } else {
            rb.velocity = new Vector2 (dirX * moveSpeedBackwards, rb.velocity.y);
        }

        if(Input.GetButtonDown("Jump") && IsGrounded())
        {
            animator.SetTrigger("Jump");
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        UpdateAnimation();
    }

    private void TakeDamage(float damage) {
        animator.SetTrigger("Take Damage");
        health -= damage;

        if (health < 0) {
            OnDeath();
        }
    }

    private void OnDeath() {
    }

    private void UpdateAnimation()
    {
        if (dirX > 0f)
        {
            // Set anim state for walk animation
            //sprite.flipX = false;
            animator.SetTrigger("Forwards");
        }
        else if (dirX < 0f)
        {
            // Slower back step?
            animator.SetTrigger("Backwards");
        }
        else
        {
            // Set anim idle
        }

        if (IsFalling())
        {
            animator.SetTrigger("Falling");
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 0.1f, ground);
    }

    private bool IsFalling()
    {
        return rb.velocity.y < 0;
    }
}
