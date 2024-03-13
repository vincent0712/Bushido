using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]

public class Health : MonoBehaviour
{
    public int health = 100;
    public int maxHealth = 100;
    [HideInInspector] public bool isDead = false;
    public GameObject deathEffect;
    public AudioClip hurtSound;
    public AudioClip deathSound;
    public UnityEvent onTakeDamage;
    public UnityEvent onDeath;


    void Awake()
    {
        // Get component references
   

        if (onTakeDamage == null)
            onTakeDamage = new UnityEvent();
        if (onDeath == null)
            onDeath = new UnityEvent();
    }

    public void TakeDamage(int damage)
    {

        if (isDead)
            return;
        health -= damage;
        if (health <= 0)
        {
            isDead = true;

            if (deathEffect != null)
                Instantiate(deathEffect, transform.position, transform.rotation);

            onDeath.Invoke();
        }

        else
        {
            onTakeDamage.Invoke();
        }
    }


    public void AddHealth(int hp)
    {
        health = (int)Mathf.Clamp(health += hp, 0, maxHealth);
    }


    public void DestroyObject()
    {
        Destroy(gameObject);
    }
}