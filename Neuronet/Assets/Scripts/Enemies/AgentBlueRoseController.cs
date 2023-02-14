using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentBlueRoseController : Enemy
{
    private void Start()
    {
        BasisInit();

        Speed = Data.AgentBlueRoseSpeed;
        Defense = Data.AgentBlueRoseDefense;


        //EnemyMovement = new EnemyMovement(rb, transform, Speed);
    }

    private void FixedUpdate()
    {
        MoveToPlayer();
    }
}
