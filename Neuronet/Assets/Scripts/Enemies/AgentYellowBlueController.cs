using UnityEngine;

public class AgentYellowBlueController : Enemy
{
    private void Start()
    {
        Rb = GetComponent<Rigidbody>();
        PlayerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        Speed = Data.AgentYellowBlueSpeed;
        Defense = Data.AgentYellowBlueDefense;

        
        //EnemyMovement = new EnemyMovement(rb, transform, Speed);
    }

    private void FixedUpdate()
    {
        MoveToPlayer();
    }
}