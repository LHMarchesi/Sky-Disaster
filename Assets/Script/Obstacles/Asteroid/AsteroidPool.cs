using UnityEngine;
using UnityEngine.Pool;

public class AsteroidPool : MonoBehaviour
{
    ObjectPool<Asteroid> projectilePool;
    [SerializeField]private Asteroid projectilePrefab;

    private void Awake()
    {
        projectilePool = new ObjectPool<Asteroid>(CreatePoolItem, OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject, false, 10, 100);
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

    private Asteroid CreatePoolItem()
    {
        Asteroid asteroid = Instantiate(projectilePrefab);
        asteroid.gameObject.SetActive(false);
        asteroid.pool = projectilePool;
        return asteroid;
    }

    public void GetFromPool(Vector2 pos, Vector2 force)
    {
        Asteroid projectileInstance = projectilePool.Get();

        projectileInstance.transform.SetPositionAndRotation(pos, Quaternion.identity);

        projectileInstance.GetComponent<Rigidbody2D>().AddForce(force, ForceMode2D.Force);
    }
}
