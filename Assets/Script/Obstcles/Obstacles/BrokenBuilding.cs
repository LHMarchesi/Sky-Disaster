using UnityEngine;

public class BrokenBuilding : Obstacle, IDamageInteractable
{
    [SerializeField] private int _speed;

    [SerializeField] private Vector2 _spawnPosition;
<<<<<<< Updated upstream
=======

    private float timeoutDelay = 10f;

    private float randomHeightMin = 1f;
    private float randomHeightMax = 5f;

>>>>>>> Stashed changes
    public override int speed { get => _speed; set => _speed = value; }
    public override Vector2 SpawnPosition { get => _spawnPosition; set => _spawnPosition = value; }

    public override void Initialize()
    {
<<<<<<< Updated upstream
        
    }

    public void Interact()
    {
=======
        _spawnPosition.y = Random.Range(randomHeightMin, randomHeightMax);

        Invoke("Deactivate", timeoutDelay);
>>>>>>> Stashed changes
    }

    private void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}


