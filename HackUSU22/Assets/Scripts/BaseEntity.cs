using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(AudioSource))]
public class BaseEntity : MonoBehaviour
{
    public GameObject bloodSprite;
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
    protected AudioSource sndSource;

    private GameObject spawnedBlood;

    // Please override
    public int maxHealth = 100;
    protected int currentHealth;

    protected AudioClip[] clips;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        currentHealth = maxHealth;
        sndSource = GetComponent<AudioSource>();
        OnStart();

        clips = new AudioClip[] {
            Resources.Load<AudioClip>("Audio/victory-is-mine"),
            Resources.Load<AudioClip>("Audio/birds"),
            Resources.Load<AudioClip>("Audio/hyuh"),
            Resources.Load<AudioClip>("Audio/runnin"),
            Resources.Load<AudioClip>("Audio/no-arms"),
            Resources.Load<AudioClip>("Audio/stand-aside"),
        };
    }

    public Vector2 GetVelocity() {
        return rb.velocity;
    }

    /// <summary>
    /// Called on Start()
    /// </summary>
    protected virtual void OnStart() {}

    // Update is called once per frame
    void Update()
    {
        Vector2 decision = GetDecision();

        if (decision.x > 0) {
            rb.velocity = new Vector2 (decision.x * moveSpeedForwards, rb.velocity.y);
        } else {
            rb.velocity = new Vector2 (decision.x * moveSpeedBackwards, rb.velocity.y);
        }

        if(decision.y > 0.1f && IsGrounded())
        {
            Jump();
        }

        UpdateAnimation(rb.velocity);
    }

    protected string GetDamageIndicator() {
        StringBuilder sb = new StringBuilder();
        if (currentHealth >= 0) {
            sb.Append("|");
            for (int i = 0; i < currentHealth / 13; i++ ) {
                sb.Append("\\./");
            }
            sb.Append("|");
            return sb.ToString();
        } else {
            return "<DEAD>";
        }
    }

    protected void Jump() {
            animator.SetTrigger("Jump");
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    protected virtual void OnUpdate() {}

    public void TakeDamage(int damage) {
        animator.SetTrigger("TakeDamage");
        currentHealth -= damage;
        spawnedBlood = Instantiate(bloodSprite, transform);
        spawnedBlood.transform.position = transform.position;

        if (currentHealth < 0) {
            OnDeath();
        }

        Invoke("DestroyBlood", 2f);
        OnTakeDamage();
    }

    protected virtual void OnTakeDamage() {

    }

    protected virtual void OnDeath() {
        coll.enabled = false;
    }

     void DestroyBlood() {
        DestroyImmediate(spawnedBlood, true);
    }

    private void UpdateAnimation(Vector2 velocity)
    {
        animator.SetBool("Forwards", false);
        animator.SetBool("Backwards", false);
        if (velocity.x > 0.2f)
        {
            // Set anim state for walk animation
            animator.SetBool("Forwards", true);
        }
        else if (velocity.x < -0.2f)
        {
            // Slower back step?
            animator.SetBool("Backwards", true);
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
        OnUpdate();
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 0.1f, ground);
    }

    private bool IsFalling()
    {
        return rb.velocity.y < -0.3;
    }

    /// <summary>
    /// Where this entity wants to go
    /// </summary>
    protected virtual Vector2 GetDecision() {
        return new Vector2(0f,0f);
    }

    public void PlayRandomSound() {
        var r = new System.Random();
        //sndSource.PlayOneShot(clips[r.Next(1,clips.Length)]);
    }
}
