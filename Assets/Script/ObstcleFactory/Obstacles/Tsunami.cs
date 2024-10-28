using UnityEngine;

public class Tsunami : Obstacle
{
    [SerializeField] private int _speed;
    [SerializeField] private Vector2 _spawnPosition;
    public override int speed { get => _speed; set => _speed = value; }
    public override Vector2 SpawnPosition { get => _spawnPosition; set => _spawnPosition = value; }

    public override void Initialize()
    {
    }
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}
