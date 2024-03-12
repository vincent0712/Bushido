using System;
using UnityEngine.AI;
using UnityEngine;

int maxValue;
int[] numbers = new int[] { 1, 5, 3, 7, 5, 6, 7, 8, 9, 1, };
Array.Sort(numbers);
Array.Reverse(numbers);
for (int i = 0; i < numbers.Length - 2; i++)
{
    maxValue = numbers[i] + numbers[i + 1] + numbers[i + 2];

    //Console.WriteLine($"{numbers[i]}, {numbers[i + 1]}, {numbers[i + 2]}");
    Console.ForegroundColor = ConsoleColor.DarkRed;
    maxValue = numbers[i] + numbers[i + 1] + numbers[i + 2];
    Console.WriteLine($"{numbers[i]}, {numbers[i + 1]}, {numbers[i + 2]}");
    Console.WriteLine($"{maxValue}");
    Console.ForegroundColor = ConsoleColor.White;
    foreach (int nr in numbers)
    {
        Console.Write(nr);
    }

    break;
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent nav;
    private Animator animator;
    private GameObject player;
    private bool isAttacking = false;

    public LayerMask obstacleLayerMasks;
    public float viewDistance = 5f;
    public float attackRange = 2f;
    public int damage = 10;


    private void Awake()
    {
        // Get component references
        nav = GetComponentInParent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }


    void Start()
    {
        // Compensate rotation for x: navmesh plane, y: sprite rotation
        //transform.rotation = Quaternion.Euler(-90f, -90f, 0f);

        // Uncomment if you don't need to manualy owerwrite rotation
        nav.updateRotation = false;
        nav.updateUpAxis = false;
        //player = GameObject.Find("Player");
        player = GameManager.instance.player;
    }


    void Update()
    {
        // Send data to Animator
        animator.SetFloat("move", nav.velocity.magnitude);

        // Stop updating if Player is dead
        if (player == null)
            return;

        // Create Linecast between this and target
        RaycastHit2D hit = Physics2D.Linecast(transform.position, player.transform.position, obstacleLayerMasks);

        // Linecast to target was succesful (did not hit anything on obstacleLayerMasks)
        if (!hit)
        {
            // Play Attack animation if within attack range and player is alive
            if (Vector2.Distance(transform.position, player.transform.position) < attackRange
                && !GameManager.instance.player.GetComponent<Health>().isDead)
            {
                // Is not already attacking
                if (!isAttacking)
                {
                    animator.SetTrigger("attack");
                    isAttacking = true;
                }

                Debug.DrawLine(transform.position, player.transform.position, Color.red);
            }
            // Move to target position if within view distance
            else if (Vector2.Distance(transform.position, player.transform.position) < viewDistance)
            {
                nav.destination = player.transform.position;
                Debug.DrawLine(transform.position, player.transform.position);
            }
        }
        // Obstacle in the way
        else
        {
            Debug.DrawLine(transform.position, hit.point);
        }
    }


    // Attack method is called on a suitable animation frame
    public void Attack()
    {
        if (player == null)
            return;

        // Still within attack range and player is alive?
        if (Vector2.Distance(transform.position, player.transform.position) < attackRange
            && !GameManager.instance.player.GetComponent<Health>().isDead)
        {
            // Player takes damage
            player.GetComponent<Health>().TakeDamage(damage);
        }

        // is not longer attacking
        isAttacking = false;
    }
}