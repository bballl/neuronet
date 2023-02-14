using System.Collections;
using UnityEngine;

public class AgentOrangeGunnerController : AgentGunner
{
    [SerializeField] private Transform bulletStartPositionLeft;
    [SerializeField] private Transform bulletStartPositionRight;

    private void Start()
    {
        Speed = Data.AgentYellowGunnerSpeed;
        Defense = Data.AgentYellowGunnerDefense;
        ContactDamage = Data.AgentOrangewGunnerContactDamage;
        Experience = Data.AgentOrangewGunnerExperience;

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
    /// �������.
    /// </summary>
    private void Shot()
    {
        GameObject.Instantiate(Resources.Load<GameObject>("AgentBullet"), bulletStartPositionLeft.position, bulletStartPositionLeft.rotation);
        GameObject.Instantiate(Resources.Load<GameObject>("AgentBullet"), bulletStartPositionRight.position, bulletStartPositionRight.rotation);
    }

    /// <summary>
    /// ��������� ���������. ��������� ������� � enum AgentGunnerState.
    /// </summary>
    private void ChangeState()
    {
        CurrentState++;
        if (CurrentState > AgentGunnerState.Shooting)
            CurrentState = 0;

        switch (CurrentState)
        {
            case AgentGunnerState.None:
                WaitTime = 1f;
                StartCoroutine(Delay());
                break;

            case AgentGunnerState.Move:
                GetNewDirection();
                WaitTime = 6f;
                StartCoroutine(Delay());
                break;

            case AgentGunnerState.GunGuidance:
                transform.LookAt(PlayerTransform);
                WaitTime = 0.7f;
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
