using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Transform attackPoint;
    public LayerMask enemyLayers;
    public float attackRange = 0.3f;
    public int attackDamage = 25;
    public float attackRate = 0.3f;
    public Animator animator;
    public PlayerController playerController;

    private float nextAttackTime = 0f;
    private bool chargingAttack = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        { 
            Debug.Log("Fire1");
            // if this attack is newly called
            if (!chargingAttack) {
                AttackPrepare();
                nextAttackTime = Time.time + attackRate;
            }

            chargingAttack = true;
        }
        else if (Input.GetButtonUp("Fire1")) {
            // If released after attack rate
            if(Time.time > nextAttackTime)
            {
                AttackRelease();
                nextAttackTime = Time.time + 1f / attackRate;
            }
            // Released before attack rate over
            else {
                Invoke("AttackRelease", Time.time - nextAttackTime);
            }
        }
    }

    private void AttackPrepare()
    {
        // TODO: Play attack anim
        animator.SetTrigger("Attack Prepare");
    }

    private void AttackRelease()
    {
        chargingAttack = false;
        Debug.Log("Attack Release");
        animator.SetTrigger("Attack Release");
    }

    public void AttackSwing() {
        Debug.Log("Attack Swing()");
        chargingAttack = false;
        // Detect in range
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        // Apply damage
        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }

    // Debug method to visualize the range of the attack
    private void OnDrawGizmos()
    {
        if (attackPoint == null) return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
