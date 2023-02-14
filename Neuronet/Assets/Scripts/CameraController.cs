using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    /// <summary>
    /// ��������� ������.
    /// </summary>
    [SerializeField] Transform characterTransform;
    [SerializeField] private Vector3 offset;

    private void Awake()
    {
        //Observer.ObstracleContact += Stop;
        //Observer.FinishTriggerContact += Stop;
    }

    /// <summary>
    /// ���������� �� �������.
    /// </summary>
    private void Update()
    {
        transform.position = characterTransform.position + offset;
    }

    /// <summary>
    /// ����������� ���������� �� �������.
    /// </summary>
    private void Stop()
    {
        characterTransform = transform;
        offset = Vector3.zero;
    }



    private void OnDestroy()
    {
        //Observer.ObstracleContact -= Stop;
        //Observer.FinishTriggerContact -= Stop;
    }
}
