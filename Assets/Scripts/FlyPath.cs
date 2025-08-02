using UnityEngine;

public class FlyPath : MonoBehaviour
{
    public WayPoint[] WayPoints;
    void Start()
    {
        
    }
    private void OnDrawGizmos()
    {
        for (int i = 0; i < WayPoints.Length - 1; i++)
        {
            Gizmos.DrawLine(WayPoints[i].transform.position, WayPoints[i + 1].transform.position);
            Gizmos.color = Color.red;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
