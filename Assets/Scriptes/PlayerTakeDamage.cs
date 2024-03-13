using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;


public class PlayerTakeDamage : MonoBehaviour
{

    public int health = 100;
    public int maxHealth = 100;
    [HideInInspector] public bool isDead = false;
    public GameObject deathEffect;
    public AudioClip hurtSound;
    public AudioClip deathSound;
    public UnityEvent onTakeDamage;
    public UnityEvent onDeath;
    private AudioSource audioSource;


    void Awake()
    {
        // Get component references
        audioSource = GetComponent<AudioSource>();

        if (onTakeDamage == null)
            onTakeDamage = new UnityEvent();
        if (onDeath == null)
            onDeath = new UnityEvent();
    }


    void Update()
    {
        if (health <= 0)
        {
            isDead = true;

            if (deathEffect != null)
                Instantiate(deathEffect, transform.position, transform.rotation);

            if (deathSound != null)
                audioSource.PlayOneShot(deathSound);

            onDeath.Invoke();
        }

    }
    public void TakeDamage(int amount)
    {
        if (isDead)
            return;

        health -= amount;

        if (health <= 0)
        {
            isDead = true;

            if (deathSound != null)
                audioSource.PlayOneShot(deathSound);

            onDeath.Invoke();
        }
        else
        {
            if (hurtSound != null)
                audioSource.PlayOneShot(hurtSound);

            onTakeDamage.Invoke();
        }
    }
    public void DestroyObject()
    {
        Destroy(gameObject);
    }
}
