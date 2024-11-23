using UnityEngine;

public class Finisher : Obstacle, IWinInteractable
{
    [SerializeField] private int _speed;
    [SerializeField] private Vector2 _spawnPosition;
    [SerializeField] public Vector2 endPosition;
    public override int speed { get => _speed; set => _speed = value; }
    public override Vector2 SpawnPosition { get => _spawnPosition; set => _spawnPosition = value; }

    public override void Initialize()
    {

    }

    void Update()
    {
        if (transform.position.x <= endPosition.x)
        {
           transform.position = endPosition;
        }
        else
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }
    public void Interact()
    {
    }
}
