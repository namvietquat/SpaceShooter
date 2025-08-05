using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyWave : MonoBehaviour
{
    public FlyPath FlyPathPrefab;
    private FlyPath _flyPathInstance;

    public float FlySpeed = 2f;
    public float waypointThreshold = 0.1f;
    public float SpawnInterval = 3f;
    public Vector3 SpawnPosition;
    public int MaxEnemyCount = 10;

    public EnemyController EnemyControllerPrefab;
    public string EnemyName;

    private float spawnTimer;
    private List<EnemyMovementState> _enemyStates = new List<EnemyMovementState>();

    private class EnemyMovementState
    {
        public EnemyController Enemy;
        public int WaypointIndex;
    }

    void Start()
    {
        _flyPathInstance = Instantiate(FlyPathPrefab);
        spawnTimer = SpawnInterval;
    }

    void Update()
    {
        SpawnWaveTimer();
        MoveAllEnemiesAlongPath();

        if (_enemyStates.Count == 0)
        {
            // Danh sách đã trống
        }
    }

    private void SpawnWaveTimer()
    {
        spawnTimer -= Time.deltaTime;

        if (spawnTimer <= 0f && _enemyStates.Count < MaxEnemyCount)
        {
            SpawnEnemyInWave();
            spawnTimer = SpawnInterval;
        }
    }

    private void SpawnEnemyInWave()
    {
        Vector3 spawnPosition = transform.position; // Dùng vị trí của chính EnemyWave trong scene
        EnemyController newEnemy = Instantiate(EnemyControllerPrefab, spawnPosition, transform.rotation);
        var state = new EnemyMovementState
        {
            Enemy = newEnemy,
            WaypointIndex = 0
        };
        _enemyStates.Add(state);
    }

    private void MoveAllEnemiesAlongPath()
    {
        if (_flyPathInstance == null || _flyPathInstance.WayPoints.Length == 0 || _enemyStates.Count == 0) return;

        foreach (var state in _enemyStates)
        {
            if (state.Enemy == null) continue;

            Transform target = _flyPathInstance.WayPoints[state.WaypointIndex].transform;
            Vector3 direction = (target.position - state.Enemy.transform.position).normalized;

            state.Enemy.transform.position += direction * FlySpeed * Time.deltaTime;

            if (Vector3.Distance(state.Enemy.transform.position, target.position) < waypointThreshold)
            {
                state.WaypointIndex++;
                if (state.WaypointIndex >= _flyPathInstance.WayPoints.Length)
                    state.WaypointIndex = 0; // Hoặc Destroy(state.Enemy) nếu muốn enemy biến mất
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, 0.1f);
        Handles.Label(transform.position, EnemyName);
    }
}
