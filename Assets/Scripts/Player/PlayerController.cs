using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Bullet BulletPrefab;
    private float _fireRate = 5f;
    private float _lastFireTime;


    void Move()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePosition.x, mousePosition.y, 0f);
    }
    private void Fire()
    {
        var offset = new Vector3(0f, 0.5f, 0f);
        Instantiate(BulletPrefab, transform.position + offset, transform.rotation);
    }
    void Update()
    {
        //Fire
        if(Time.time > _lastFireTime + _fireRate)
        {
            Fire();
            _lastFireTime = Time.time;

        }
        Move();

        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(BulletPrefab, transform.position, transform.rotation);
        }
    }
}