using System;
using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : BaseEntity
{
    private AudioClip scream = Resources.Load<AudioClip>("Audio/scream");

    protected override void OnStart() {
        jumpForce = 10;
        maxHealth = 100;
    }

    protected override Vector2 GetDecision() {
        var dirX = Input.GetAxisRaw("Horizontal");
        float dirY;
        if (Input.GetButtonDown("Jump")) {
            dirY = 10f;
        } else {
            dirY = 0f;
        }
        return new Vector2(dirX, dirY);
    }

    protected override void OnUpdate()
    {
    }

    protected override void OnDeath()
    {
        Debug.Log("Died");
        sndSource.PlayOneShot(scream);
        base.OnDeath();
    }
}