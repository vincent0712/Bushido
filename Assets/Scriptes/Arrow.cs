using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Arrow : MonoBehaviour
{
    public float Arrowspeed = 10f;
    public int damage = 10;
    public float lifeTime = 3f;
    public float knockBack = 3f;
    
    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(transform.right * Arrowspeed, ForceMode2D.Impulse);
        Destroy(gameObject,lifeTime);
    }
    // Triggers if one or both colliders is triggers
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            return;
            

        // Try get health from colliding object
        Health health = collision.gameObject.GetComponent<Health>();

        // Object has health
        if (health)
        {
            health.TakeDamage(damage);
        }
        //Object has no health
        else
        {
            // Do something
        }
        Destroy(gameObject);
    }

    // Trigger if none of the colliders are triggers
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
