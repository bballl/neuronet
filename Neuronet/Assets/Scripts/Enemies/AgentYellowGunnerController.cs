using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentYellowGunnerController : AgentGunner
{
    [SerializeField] private Transform bulletStartPosition;

    private void Start()
    {
        Speed = Data.AgentYellowGunnerSpeed;
        Defense = Data.AgentYellowGunnerDefense;

        BasisInit();
        GetAllWayPoints();
        ChangeState();
    }

    private void FixedUpdate()
    {
        if (CurrentState == AgentGunnerState.Move)
            MoveToWayPoint();
    }

    /// <summary>
    /// Выстрел.
    /// </summary>
    private void Shot()
    {
        GameObject.Instantiate(Resources.Load<GameObject>("AgentBullet"), bulletStartPosition.position, bulletStartPosition.rotation);
    }

    /// <summary>
    /// Изменение состояния. Состояния описаны в enum AgentGunnerState.
    /// </summary>
    private void ChangeState()
    {
        CurrentState++;
        if (CurrentState > AgentGunnerState.Shooting)
        {
            CurrentState = 0;
        }

        switch (CurrentState)
        {
            case AgentGunnerState.None:
                WaitTime = 1f;
                StartCoroutine(Delay());
                break;

            case AgentGunnerState.Move:
                GetNewDirection();
                WaitTime = 5f;
                StartCoroutine(Delay());
                break;

            case AgentGunnerState.GunGuidance:
                transform.LookAt(PlayerTransform);
                WaitTime = 0.35f;
                StartCoroutine(Delay());
                break;

            case AgentGunnerState.Shooting:
                Shot();
                WaitTime = 1f;
                StartCoroutine(Delay());
                break;
        }
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(WaitTime);
        ChangeState();
    }
    
    //private void OnDestroy()
    //{
    //    StopAllCoroutines();
    //}
}
