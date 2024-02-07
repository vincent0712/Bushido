using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MeleeAttack : MonoBehaviour
{
    public GameObject TriUp;
    public GameObject TriDown;
    public GameObject TriLeft;
    public GameObject TriRight;
    public UnityEvent onTakeDamage;
    private EnemyHealth enemyHealth;
    public int Enemyhealth = 50;
    public bool isDead = false;
    public UnityEvent onDeath;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy" && Input.GetKeyDown(KeyCode.Mouse0))
        {
            Enemyhealth -= 20;
            if(Enemyhealth <= 0)
            {
                isDead = true;
                onDeath.Invoke();
            }
            return;
        }
    }
}
