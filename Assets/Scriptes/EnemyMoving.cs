
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class EnemyMoving : MonoBehaviour
{
    private Vector3 target;
    NavMeshAgent Player;
    NavMeshAgent Enemy;
    public UnityEngine.Transform targetposition;

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

        if (Player != null)
        {
            SetTargetPosition();
        }
 
       
       
    }

    void SetTargetPosition()
    {

        //targetposition.position = GameObject.FindGameObjectWithTag("Player").transform.position;
        Player.SetDestination(targetposition.position);
        Player.destination = targetposition.position;
        //SetAgentPosition




    }

    void SetAgentPosition()
    {
        if(Player != null)
        {
            Player.SetDestination(new Vector3(target.x, target.y, transform.position.z));
        }
    }
    

}


