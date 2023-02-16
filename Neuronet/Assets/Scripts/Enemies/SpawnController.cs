using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField] private List<Transform> spawnPoints; // изменить
    private Coroutine coroutine;
    private float spawnWaitTime = Data.SpawnWaitTime;
    
    private void Start()
    {
        GetAllSpawnPoints();
        coroutine = StartCoroutine(SpawnStart());
    }

    /// <summary>
    /// Стартует процесс появления нового агента.
    /// </summary>
    private IEnumerator SpawnStart()
    {
        Spawn();
        yield return new WaitForSeconds(spawnWaitTime);
        if (spawnWaitTime > Data.SpawnMinTime)
            spawnWaitTime -= Data.SpawnTimeReduction;

        coroutine = null; // перестраховываемся, чтобы не плодить короутины
        coroutine = StartCoroutine(SpawnStart());

        //Debug.Log($"spawnWaitTime: {spawnWaitTime}");
    }

    /// <summary>
    /// Появление нового агента в одной из SpawnPoint.
    /// </summary>
    private void Spawn()
    {
        var index = Random.Range(0, spawnPoints.Count);
        var spawnPoint = spawnPoints[index];

        var name = GetNextAgentName();
        if (name == null)
        {
            Debug.Log("Ошибка при выполнении Spawn");
            return;
        }

        GameObject.Instantiate(Resources.Load<GameObject>(name), spawnPoint.position, spawnPoint.rotation);
    }

    /// <summary>
    /// Получает все SpawnPoints и сохраняет их в List.
    /// </summary>
    private void GetAllSpawnPoints()
    {
        var spawnPointsGameObjects = GameObject.FindGameObjectsWithTag("SpawnPoint");
        spawnPoints = new List<Transform>();

        foreach (var e in spawnPointsGameObjects)
        {
            spawnPoints.Add(e.transform);
        }
    }

    /// <summary>
    /// Получить противника случайного типа для спавна.
    /// </summary>
    /// <returns>Название противника.</returns>
    private string GetNextAgentName()
    {
        var maxIndex = (int)EnemyType.None;
        var index = Random.Range(0, maxIndex);

        string name = null;
        switch (index)
        {
            case (int)EnemyType.AgentBlueRose:
                return name = "AgentBlueRose";

            case (int)EnemyType.AgentLilac:
                return name = "AgentLilac";

            case (int)EnemyType.AgentYellowBlue:
                return name = "AgentYellowBlue";

            case (int)EnemyType.AgentYellowGunner:
                return name = "AgentYellowGunner";

            case (int)EnemyType.AgentOrangeGunner:
                return name = "AgentOrangeGunner";

            default: return name;
        }
    }

    
}
