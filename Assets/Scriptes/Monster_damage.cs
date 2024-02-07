using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Damage_tortur : MonoBehaviour
{
    public int damage;
    public Health health;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            health.TakeDamage(damage);
        }
    }
}