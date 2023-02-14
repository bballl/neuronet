using UnityEngine;

public class AgentRedController : Enemy
{
    private void Start()
    {
        BasisInit();

        Speed = Data.AgentRedSpeed;
        Defense = Data.AgentRedDefense;
        ContactDamage= Data.AgentRedContactDamage;
        Experience= Data.AgentRedExperience;
        
        //EnemyMovement = new EnemyMovement(rb, transform, Speed);
    }

    private void FixedUpdate()
    {
        MoveToPlayer();
    }
}