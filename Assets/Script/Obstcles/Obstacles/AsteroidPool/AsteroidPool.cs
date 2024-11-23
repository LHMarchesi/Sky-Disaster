using UnityEngine;
using UnityEngine.Pool;

public class AsteroidPool : MonoBehaviour
{
    ObjectPool<Asteroid> asteroidoPool;

    [SerializeField]private Asteroid asteroid;

    private void Awake()
    {
        asteroidoPool = new ObjectPool<Asteroid>(CreatePoolItem, OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject, false, 10, 100);
    }

    public void GetFromPool(Vector2 pos, Vector2 force)
    {
        Asteroid projectileInstance = asteroidoPool.Get();
        projectileInstance.transform.SetPositionAndRotation(pos, Quaternion.identity);
        projectileInstance.GetComponent<Rigidbody2D>().AddForce(force, ForceMode2D.Force);
    }

    private Asteroid CreatePoolItem()
    {
        Asteroid asteroid = Instantiate(this.asteroid);
        asteroid.gameObject.SetActive(false);
        asteroid.pool = asteroidoPool;
        return asteroid;
    }

    private void OnDestroyPoolObject(Asteroid asteroid)
    {
        Destroy(asteroid.gameObject);
    }

    private void OnReturnedToPool(Asteroid asteroid)
    {
        asteroid.gameObject.SetActive(false);
    }

    private void OnTakeFromPool(Asteroid asteroid)
    {
        asteroid.gameObject.SetActive(true);
    }
}
