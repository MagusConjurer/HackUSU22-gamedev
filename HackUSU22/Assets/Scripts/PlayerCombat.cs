using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Transform attackPoint;
    public LayerMask enemyLayers;
    public float attackRange = 0.5f;
    public int attackDamage = 25;
    public float attackRate = 0.5f;
    public Animator animator;
    public PlayerController playerController;

    private float nextAttackTime = 0f;
    private bool chargingAttack = false;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        { 
            if (chargingAttack) {
                // Cancels attack
                if (Input.GetButtonDown("Fire2")) {
                    chargingAttack = false;
                }
                return;
            }

            chargingAttack = true;
            AttackPrepare();
            nextAttackTime = Time.time + attackRate;
        }
        else if (Input.GetButtonUp("Fire1")) {
            if(Time.time > nextAttackTime)
            {
                AttackRelease();
                nextAttackTime = Time.time + 1f / attackRate;
            }
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
        Debug.Log("Attack Release");
        chargingAttack = false;
        animator.SetTrigger("Attack Release");
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
