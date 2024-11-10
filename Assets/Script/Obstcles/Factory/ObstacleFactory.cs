using UnityEngine;

public class ObstacleFactory : AbstractFactory
{
    [SerializeField] Obstacle _obstacle;

    public override Obstacle obstacle { get => _obstacle; set => _obstacle = value; }

    public override Obstacle CreateObstacle()
    {
        Obstacle newObstacle = Instantiate(_obstacle, Vector2.zero, Quaternion.identity);
        newObstacle.Initialize();
        newObstacle.transform.position = newObstacle.SpawnPosition;

        return newObstacle;
    }
}
