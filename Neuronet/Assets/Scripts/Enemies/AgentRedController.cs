using UnityEngine;

public class AgentRedController : ContactAttackEnemy
{
    private void Start()
    {
        Speed = Data.AgentRedSpeed;
        Defense = Data.AgentRedDefense;
        
        var rb = GetComponent<Rigidbody>();
        EnemyMovement = new EnemyMovement(rb, transform, Speed);
    }
}