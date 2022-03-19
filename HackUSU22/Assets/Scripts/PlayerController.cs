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
        moveSpeedForwards = 10;
        moveSpeedBackwards = 5;
        jumpForce = 20;
        health = 100;
    }

    private Vector2 GetDescision() {
        var dirX = Input.GetAxisRaw("Horizontal");
        float dirY;
        if (Input.GetButtonDown("Jump")) {
            dirY = 1f;
        } else {
            dirY = 0f;
        }
        return new Vector2(dirX, dirY);
    }

    public static float getDirection()
    {
        return dirX * moveSpeed;
    }
}