using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDoDamageOnPlayer : MonoBehaviour
{
    public int damage;
    public Health health;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            health.TakeDamage(damage);
            //collision.gameObject.GetComponent<Health>().TakeDamage(damage);
        }
    }
    private void Start()
    {
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
    }
}
