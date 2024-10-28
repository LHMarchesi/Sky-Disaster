using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewAsteroidData", menuName = "Flyweight/AsteroidData", order = 1)]
public class AsteroidsScriptable : ScriptableObject
{
    [SerializeField] public Sprite sprite;
    [SerializeField] public AnimationClip Asteroid;
    [SerializeField] public AudioClip blowingWindstorm;
    [SerializeField] public float speedX;
    [SerializeField] public float speedY;
}
