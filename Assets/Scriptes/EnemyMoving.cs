
using UnityEngine;
using UnityEngine.AI;

public class EnemyMoving : MonoBehaviour
{
    private Vector3 target;
    NavMeshAgent Player;
    NavMeshAgent Enemy;
    public Transform targetposition;

    private void Awake()
    {
        Player = GetComponent<NavMeshAgent>();
        Player.updateRotation = false;
        Player.updateUpAxis = false;

        Enemy = GetComponent<NavMeshAgent>();
        Enemy.updateRotation = false;
        Enemy.updateUpAxis = false;



        
    }

    private void Update()
    {
     
        targetposition.position = GameObject.FindGameObjectWithTag("Player").transform.position;
        SetTargetPosition();
        Player.SetDestination(targetposition.position);
        Player.destination = targetposition.position;
        //SetAgentPosition();
    }

    void SetTargetPosition()
    {
        

    }

    void SetAgentPosition()
    {
        Player.SetDestination(new Vector3(target.x, target.y, transform.position.z));
    }

}


