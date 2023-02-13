using UnityEngine;

public class AgentRedController : Enemy
{
    private void Start()
    {
        BasisInit();


        Speed = Data.AgentRedSpeed;
        Defense = Data.AgentRedDefense;
        
        
        //EnemyMovement = new EnemyMovement(rb, transform, Speed);
    }

    private void FixedUpdate()
    {
        MoveToPlayer();
    }
}