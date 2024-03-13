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
    public GameObject Enemy;
    public LayerMask obsticleLayersMask;
    public float viewDistance;

    private void Awake()
    {
        
    }
    void Update()
    {
        Vector3 position = Player.transform.position;
        nav.destination = position;
    }
}


