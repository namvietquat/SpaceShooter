using UnityEngine;

public class EngineBlink : MonoBehaviour
{
    private SpriteRenderer _sprite;
    public float blinkInterval = 0.5f;
    private float _timer = 0f;

    void Start()
    {
        _sprite = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= blinkInterval)
        {
            _sprite.enabled = !_sprite.enabled;
            _timer = 0f;
        }

    }
}