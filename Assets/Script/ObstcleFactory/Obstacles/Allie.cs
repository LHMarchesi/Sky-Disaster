using UnityEngine;

public class Allie : Obstacle
{
    [SerializeField] private int _speed;
    [SerializeField] private Vector2 _spawnPosition;
    public override int speed { get => _speed; set => _speed = value; }
    public override Vector2 SpawnPosition { get => _spawnPosition; set => _spawnPosition = value; }

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Dead"))
        {
            Destroy(gameObject);
        }
    }

    public override void Initialize()
    {
        //Sfx?
    }
}
