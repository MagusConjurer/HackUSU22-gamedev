using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class BaseEntity : MonoBehaviour
{
    public float moveSpeedForwards = 10;
    public float moveSpeedBackwards = 5;
    public float jumpForce = 10;
    // please set these
    public LayerMask ground;
    public Animator animator;

    // This entity should have all of these
    protected Rigidbody2D rb;
    protected BoxCollider2D coll;
    protected SpriteRenderer sprite;

    // Please override
    public float health = 100;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        OnStart();
    }

    /// <summary>
    /// Called on Start()
    /// </summary>
    protected virtual void OnStart() {}

    // Update is called once per frame
    void Update()
    {
        Vector2 decsicion = GetDecision();

        if (decsicion.x > 0) {
            rb.velocity = new Vector2 (decsicion.x * moveSpeedForwards, rb.velocity.y);
        } else {
            rb.velocity = new Vector2 (decsicion.x * moveSpeedBackwards, rb.velocity.y);
        }

        if(decsicion.y > 0.1f && IsGrounded())
        {
            animator.SetTrigger("Jump");
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        UpdateAnimation(rb.velocity);
    }

    public void TakeDamage(float damage) {
        animator.SetTrigger("Take Damage");
        health -= damage;

        if (health < 0) {
            OnDeath();
        }
    }

    protected virtual void OnDeath() {
        GetComponent<BoxCollider2D>().enabled = false;
    }

    private void UpdateAnimation(Vector2 velocity)
    {
        if (velocity.x > 0f)
        {
            // Set anim state for walk animation
            animator.SetTrigger("Forwards");
        }
        else if (velocity.x < 0f)
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
            animator.SetBool("Falling", true);
        } else {
            animator.SetBool("Falling", false);
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

    /// <summary>
    /// Where this entity wants to go
    /// </summary>
    protected virtual Vector2 GetDecision() {
        return new Vector2(0f,-1f);
    }
}
