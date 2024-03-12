using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMoving : MonoBehaviour
{
    private NavMeshAgent nav;
    private Animator animator;
    public GameObject Player;
    public LayerMask obsticleLayersMask;
    public float viewDistance;

    private void Awake()
    {
        
    }
    void Update()
    {
        if (Vector2.Distance(transform.position, Player.transform.position) < viewDistance)
        {
            nav.destination = Player.transform.position;
            Debug.DrawLine(transform.position, Player.transform.position);
        }
    }
}


