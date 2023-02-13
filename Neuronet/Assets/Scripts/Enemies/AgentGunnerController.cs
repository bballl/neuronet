using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentGunnerController : Enemy
{
    [SerializeField] private List<Transform> WayPoints; // ��������
    [SerializeField] private Transform towerTransform;
    [SerializeField] private Transform bulletStartPosition;

    private Vector3 currrentWayPoint;
    private AgentState currentState;
    private float waitTime;

    private enum AgentState
    {
        None,
        Move,
        GunGuidance,
        Shooting
    }
    private void Start()
    {
        Speed = Data.AgentGunnerSpeed;
        Defense = Data.AgentGunnerDefense;

        BasisInit();
        GetAllWayPoints();
        ChangeState();

        

        
        
    }

    private void FixedUpdate()
    {
        //transform.LookAt(PlayerTransform);

        if (currentState == AgentState.Move)
            MoveToWayPoint();

    }

    /// <summary>
    /// �������� ������� �����.
    /// </summary>
    private void GetAllWayPoints()
    {
        var wayPointsGameObjects = GameObject.FindGameObjectsWithTag("WayPoint");
        WayPoints = new List<Transform>();
        
        foreach (var e in wayPointsGameObjects)
        {
            WayPoints.Add(e.transform);
        }
    }

    /// <summary>
    /// ��������� ����������� � ����� ������� ����� � ������� � ���.
    /// </summary>
    private void GetNewDirection()
    {
        var index = Random.Range(0, WayPoints.Count);
        currrentWayPoint = WayPoints[index].position;
        transform.LookAt(currrentWayPoint);
    }

    /// <summary>
    /// �������� � ������� �����.
    /// </summary>
    private void MoveToWayPoint()
    {
        Rb.AddForce(transform.forward * Time.deltaTime * Speed, ForceMode.Impulse);
    }

    private void Shooting()
    {
        
        Object.Instantiate(Resources.Load<GameObject>("AgentBullet"), bulletStartPosition.position, bulletStartPosition.rotation);
    }

    /// <summary>
    /// ��������� ���������. ��������� ������� � enum AgentState.
    /// </summary>
    private void ChangeState()
    {
        currentState++;
        if (currentState > AgentState.Shooting)
        {
            currentState = 0;
        }

        switch (currentState)
        {
            case AgentState.None:
                Debug.Log("None");
                waitTime = 1f;
                StartCoroutine(Delay());
                break;
            
            case AgentState.Move:
                Debug.Log("Move");
                GetNewDirection();
                waitTime = 5f;
                StartCoroutine(Delay());
                break;

            case AgentState.GunGuidance:
                Debug.Log("GunGuidance");
                transform.LookAt(PlayerTransform);
                waitTime = 0.35f;
                StartCoroutine(Delay());
                break;

            case AgentState.Shooting:
                Debug.Log("Shooting");
                Shooting();
                waitTime = 1f;
                StartCoroutine(Delay());
                break;
        }
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(waitTime);
        ChangeState();
    }
    
    //private void OnDestroy()
    //{
    //    StopAllCoroutines();
    //}




}
