using UnityEngine;

public class ObstacleFactory : MonoBehaviour
{
    [SerializeField] Obstacle _obstacle;

    public Obstacle obstacle { get => _obstacle; set => _obstacle = value; }

    public Obstacle CreateObstacle()
    {
        return Instantiate(_obstacle, _obstacle.SpawnPosition, Quaternion.identity);
    }
}
