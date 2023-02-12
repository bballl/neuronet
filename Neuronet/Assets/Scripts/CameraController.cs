using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    /// <summary>
    /// Трансформ игрока.
    /// </summary>
    [SerializeField] Transform playerTransform;
    [SerializeField] private Vector3 offset;

    private void Awake()
    {
        //Observer.ObstracleContact += Stop;
        //Observer.FinishTriggerContact += Stop;
    }

    /// <summary>
    /// Следование за игроком.
    /// </summary>
    private void Update()
    {
        transform.position = playerTransform.position + offset;
    }

    /// <summary>
    /// Прекращения следования за игроком.
    /// </summary>
    private void Stop()
    {
        playerTransform = transform;
        offset = Vector3.zero;
    }

    private void OnDestroy()
    {
        //Observer.ObstracleContact -= Stop;
        //Observer.FinishTriggerContact -= Stop;
    }
}
