using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 150;

    private int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        // TODO: Play damage anim

        if (currentHealth <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        // TODO: Play death anim
        // TODO: Disable any enemy logic
        GetComponent<BoxCollider2D>().enabled = false;
    }
}
