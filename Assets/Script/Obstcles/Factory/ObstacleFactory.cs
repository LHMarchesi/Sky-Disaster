using UnityEngine;

public class ObstacleFactory : MonoBehaviour
{
    [SerializeField] Obstacle _obstacle;

    public Obstacle obstacle { get => _obstacle; set => _obstacle = value; }

    public Obstacle CreateObstacle()
    {
        Obstacle newObstacle = Instantiate(_obstacle, Vector2.zero, Quaternion.identity);
        newObstacle.Initialize();
        newObstacle.transform.position = newObstacle.SpawnPosition;

        return newObstacle;
    }
}
