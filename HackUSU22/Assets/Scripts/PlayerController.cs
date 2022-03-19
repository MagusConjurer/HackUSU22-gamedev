using System;
using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : BaseEntity
{
    private AudioClip scream;
    private AudioClip[] clashes;

    protected override void OnStart() {
        jumpForce = 10;
        maxHealth = 100;
        scream = Resources.Load<AudioClip>("Audio/scream");
        clashes = new AudioClip[] {
         Resources.Load<AudioClip>("Audio/clash1"),
         Resources.Load<AudioClip>("Audio/clash2"),
         Resources.Load<AudioClip>("Audio/clash3"),
         Resources.Load<AudioClip>("Audio/clash4"),
         Resources.Load<AudioClip>("Audio/clash5"),
        };

        sndSource.clip = Resources.Load<AudioClip>("Audio/robin");
        sndSource.loop = true;
        sndSource.Play();
    }

    public void PlayRandomClash() {
        var r = new System.Random();
        AudioClip c = clashes[r.Next(1,5)];
        sndSource.PlayOneShot(c);
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
        base.OnDeath();
        Debug.Log("Died");
        sndSource.PlayOneShot(scream);
    }
}