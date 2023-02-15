using System.Collections.Generic;
using UnityEngine;

public abstract class AgentGunner : Enemy
{
    [SerializeField] protected List<Transform> WayPoints; // изменить
    protected float WaitTime;
    protected Vector3 CurrrentWayPoint;
    protected AgentGunnerState CurrentState;

    //protected void AgentGunnerInit()
    //{
    //    BasisInit();
    //    GetAllWayPoints();
    //    ChangeState();
    //}
    
    /// <summary>
    /// Получить путевые точки.
    /// </summary>
    protected virtual void GetAllWayPoints()
    {
        var wayPointsGameObjects = GameObject.FindGameObjectsWithTag("WayPoint");
        WayPoints = new List<Transform>();

        foreach (var e in wayPointsGameObjects)
        {
            WayPoints.Add(e.transform);
        }
    }

    /// <summary>
    /// Получение направления к новой путевой точке и поворот к ней.
    /// </summary>
    protected virtual void GetNewDirection()
    {
        var index = Random.Range(0, WayPoints.Count);
        CurrrentWayPoint = WayPoints[index].position;
        transform.LookAt(CurrrentWayPoint);
    }

    /// <summary>
    /// Движение к путевой точке.
    /// </summary>
    protected virtual void MoveToWayPoint()
    {
        if (CurrentState == AgentGunnerState.Move)
            Rb.AddForce(transform.forward * Time.deltaTime * Speed, ForceMode.Impulse);
    }




}