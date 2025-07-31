using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Bullet BulletPrefab;

    void Move()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePosition.x, mousePosition.y, 0f);
    }
    void Update()
    {
        Move();

        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(BulletPrefab, transform.position, transform.rotation);
        }
    }
}