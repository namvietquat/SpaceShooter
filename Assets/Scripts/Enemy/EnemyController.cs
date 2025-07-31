using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public EnemyBullet EnemyBulletPrefab;
    public float timeShot = 1.0f; // thời gian giữa các lần bắn (tính bằng giây)
    private float timer = 0f;
    void OnTriggerEnter2D(Collider2D collision)
    {
        Die();
    }

    private void Die()
    {
        Destroy(gameObject);
    }
    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeShot)
        {
            Instantiate(EnemyBulletPrefab, transform.position, transform.rotation);
            timer = 0f; // reset bộ đếm
        }
    }
}