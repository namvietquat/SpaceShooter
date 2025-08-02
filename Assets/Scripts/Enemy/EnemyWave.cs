using UnityEditor;
using UnityEngine;

public class EnemyWave : MonoBehaviour
{
    // Declaration for FlyPath
    

    public FlyPath FlyPathPrefab;
    private FlyPath flyPathInstance;
    private int currentWaypointIndex = 0;
    public float moveSpeed = 2f;
    public float waypointThreshold = 0.1f; // khoảng cách để coi là "đến nơi"

    // Declaration for EnemyController
    public EnemyController EnemyControllerPrefab;
    private EnemyController EnemyControllerInstance;

    // Declaration Enemy name
    public string EnemyName;

    void Start()
    {
        EnemyControllerInstance = Instantiate(EnemyControllerPrefab, transform.position, transform.rotation);
        flyPathInstance = Instantiate(FlyPathPrefab);
        transform.position = flyPathInstance.WayPoints[0].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
      
        FollowSpline();
    
    }
    private void FollowSpline()
    {
        if (flyPathInstance == null || flyPathInstance.WayPoints.Length == 0 || EnemyControllerInstance == null) return;

        Transform target = flyPathInstance.WayPoints[currentWaypointIndex].transform;
        Vector3 direction = (target.position - EnemyControllerInstance.transform.position).normalized;

        EnemyControllerInstance.transform.position += direction * moveSpeed * Time.deltaTime;

        // Kiểm tra nếu đã đến gần waypoint
        if (Vector3.Distance(EnemyControllerInstance.transform.position, target.position) < waypointThreshold)
        {
            currentWaypointIndex++;

            if (currentWaypointIndex >= flyPathInstance.WayPoints.Length)
            {
                currentWaypointIndex = 0; // lặp lại
                // moveSpeed = 0f; // nếu muốn dừng lại
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