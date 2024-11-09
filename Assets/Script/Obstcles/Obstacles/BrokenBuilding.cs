using UnityEngine;

public class BrokenBuilding : Obstacle
{
    [SerializeField] private int _speed;
    [SerializeField] private Vector2 _spawnPosition;
    private float timeoutDelay = 10f;

    public override int speed { get => _speed; set => _speed = value; }
    public override Vector2 SpawnPosition { get => _spawnPosition; set => _spawnPosition = value; }

    public override void Initialize()
    {
        Invoke("Deactivate", timeoutDelay);
    }

    private void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    private void Deactivate()
    {
        Destroy(gameObject);
    }
}
