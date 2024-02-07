using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{
    public int Enemyhealth = 50;
    public int EnemymaxHealth = 50;
    [HideInInspector] public bool isDead = false;
    public GameObject deathEffect;
    public AudioClip hurtSound;
    public AudioClip deathSound;
    public UnityEvent onTakeDamage;
    public UnityEvent onDeath;
    private AudioSource audioSource;
    private Animator animator;
    private NavMeshAgent nav;


    void Awake()
    {
        // Get component references
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        nav = GetComponentInParent<NavMeshAgent>();

        if (onTakeDamage == null)
            onTakeDamage = new UnityEvent();
        if (onDeath == null)
            onDeath = new UnityEvent();
    }

    public void TakeDamage(int damage)
    {
        // Don't do anything if dead
        if (isDead)
            return;

        // Reduce health by amount of damage
        Enemyhealth -= damage;

        // Is dead?
        if (Enemyhealth <= 0)
        {
            isDead = true;

            // Instatiate death particles
            if (deathEffect != null)
                Instantiate(deathEffect, transform.position, transform.rotation);

            // Play death animation
            if (animator != null)
                animator.SetTrigger("dead");

            // Play death sound
            if (deathSound != null)
                audioSource.PlayOneShot(deathSound);

            // stop updating navmesh for objects with pathfinding
            if (nav != null)
                nav.isStopped = true;

            onDeath.Invoke();
        }
        // Got hit
        else
        {
            // Play hurt sound effect
            if (hurtSound != null)
                audioSource.PlayOneShot(hurtSound);

            // Play hit animation
            if (animator != null)
                animator.SetTrigger("hit");

            onTakeDamage.Invoke();
        }
    }

    // Call this on pick up event
    public void AddHealth(int hp)
    {
        Enemyhealth = (int)Mathf.Clamp(Enemyhealth += hp, 0, EnemymaxHealth);
    }

    // Call this on last frame of death animation
    public void DestroyObject()
    {
        Destroy(gameObject);
    }
}