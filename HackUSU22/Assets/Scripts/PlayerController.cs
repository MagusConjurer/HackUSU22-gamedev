using System;
using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : BaseEntity
{
    protected override void OnStart() {

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
}