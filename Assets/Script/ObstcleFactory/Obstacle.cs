using UnityEngine;

public abstract class Obstacle : MonoBehaviour
{
    public abstract int speed { get; set; }
    public abstract Vector2 SpawnPosition { get; set; }

    public abstract void Initialize();
}
