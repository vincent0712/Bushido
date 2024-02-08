using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Monster_Damage_tortur : MonoBehaviour
{
    public UnityEvent onTakeDamage;
    public int damage;
    public int health;
    private void OnCollision2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && (Input.GetKeyDown(KeyCode.Mouse0)))
        {
            if ( health <= 0f)
            {
                Destroy(gameObject);
            }
                
            health -= damage;

        }
        
            
}
    }
