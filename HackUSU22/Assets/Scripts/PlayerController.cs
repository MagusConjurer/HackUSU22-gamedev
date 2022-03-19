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
    public GameObject deathScreen;

    protected override void OnStart() {
        jumpForce = 10;
        maxHealth = 100;
        deathScreen.SetActive(false);
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
        base.OnUpdate();
        OffTheMap();
        if (transform.position.x > 250)
        {
            rb.gravityScale = 0.8f;
            jumpForce = 20;
        }
        else
        {
            rb.gravityScale = 1f;
            jumpForce = 10;
        }

    }

    protected override void OnDeath() 
    {
        base.OnDeath();
        Debug.Log("Died");
        sndSource.PlayOneShot(scream);
    }

    private void OffTheMap()
    {
        if (transform.position.y < -20f)
        {
            deathScreen.SetActive(true);
            rb.gravityScale = 0;
            for(int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
}