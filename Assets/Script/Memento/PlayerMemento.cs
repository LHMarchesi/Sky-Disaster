using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMemento
{
    public Vector3 position;
    public int health;

    public PlayerMemento(Vector3 position, int health)
    {
        this.position = position;
        this.health = health;
    }
}
