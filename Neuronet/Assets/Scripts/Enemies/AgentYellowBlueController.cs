using UnityEngine;

public class AgentYellowBlueController : ContactAttackEnemy
{
    private void Start()
    {
        Speed = Data.AgentYellowBlueSpeed;
        Defense = Data.AgentYellowBlueDefense;

        var rb = GetComponent<Rigidbody>();
        EnemyMovement = new EnemyMovement(rb, transform, Speed);
    }
}