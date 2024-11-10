using UnityEngine;

public abstract class AbstractFactory : MonoBehaviour
{
    public abstract Obstacle obstacle { get; set; }

    public abstract Obstacle CreateObstacle();
}
