using UnityEngine;

public class ObstacleFactory : MonoBehaviour
{
    [SerializeField] private Obstacle _obstacle;
    [SerializeField] private IRescueStrategy _rescueStrategy;

    public Obstacle obstacle { get => _obstacle; set => _obstacle = value; }

    public Obstacle CreateObstacle()
    {
<<<<<<< Updated upstream:Assets/Script/Obstacles/ObstcleFactory/ObstacleFactory.cs
        return Instantiate(_obstacle, _obstacle.SpawnPosition, Quaternion.identity);
=======
        Obstacle newObstacle = Instantiate(_obstacle, Vector2.zero, Quaternion.identity);
        newObstacle.Initialize();
        newObstacle.transform.position = newObstacle.SpawnPosition;

        if (newObstacle is Allie allie)
        {
            allie.SetRescueStrategy(_rescueStrategy);
        }

        return newObstacle;
>>>>>>> Stashed changes:Assets/Script/Obstcles/Factory/ObstacleFactory.cs
    }
}


