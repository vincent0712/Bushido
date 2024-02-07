using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ai_Moving : MonoBehaviour
{
    public GameObject player;
    public float Enemyspeed = 0f;
    public Transform targetObject;
    public float distance;
    void Start()
    {
        
    }

    
    void Update()
    {
        float distanceToTarget = Vector2.Distance(transform.position, targetObject.position);
        if (distanceToTarget > 0.2f)
        {
            Enemyspeed = 2f;

            distance = Vector2.Distance(transform.position, player.transform.position);
            Vector2 direction = player.transform.position - transform.position;

            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, Enemyspeed * Time.deltaTime);
        }
        else
        {
            Enemyspeed = 0f;
            distance = Vector2.Distance(transform.position, player.transform.position);
            Vector2 direction = player.transform.position - transform.position;

            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, Enemyspeed * Time.deltaTime);
        }
    }
}


