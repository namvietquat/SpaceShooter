using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public EnemyBullet EnemyBulletPrefab;
    public float timeShot = 1.0f;
    private float timer = 0f;

  

    void Start()
    {
        
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timeShot)
        {
            Instantiate(EnemyBulletPrefab, transform.position, transform.rotation);
            timer = 0f;
        }
    }

   
    void OnTriggerEnter2D(Collider2D collision)
    {
        Die();
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
