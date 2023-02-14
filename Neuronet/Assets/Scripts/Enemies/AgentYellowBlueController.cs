using UnityEngine;

public class AgentYellowBlueController : Enemy
{
    private void Start()
    {
        BasisInit();

        Speed = Data.AgentYellowBlueSpeed;
        Defense = Data.AgentYellowBlueDefense;
        ContactDamage= Data.AgentYellowBlueContactDamage;
        Experience= Data.AgentYellowBlueExperience;
        
        //EnemyMovement = new EnemyMovement(rb, transform, Speed);
    }

    private void FixedUpdate()
    {
        MoveToPlayer();
    }
}