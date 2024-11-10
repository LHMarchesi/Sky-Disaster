using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObstacleSpawner
{
    public ObstacleFactory factory;
    public float spawnInterval = 1f; // Ajustar intervalo bajo para que aparezcan más seguido
    public float startDelay;         // Tiempo de espera antes de empezar a spawnear
    public bool isEnabled = true;
<<<<<<< Updated upstream
    public bool shouldStopSpawning;  // Booleano para detener el spawn en tiempo de ejecución
=======
    public bool shouldStopSpawning;
>>>>>>> Stashed changes
}

public class ManageSpawning : MonoBehaviour
{
    [SerializeField] AsteroidPool asteroidPool;
    [SerializeField] AsteroidsScriptable asteroidData;
    [SerializeField] float timeBetweenAsteroids;

    [SerializeField] List<ObstacleSpawner> obstacleSpawners;
    [SerializeField] ObstacleSpawner finisherSpawner;

    public bool CanSpawn { get; private set; }

    private void Start()
    {
        StartCoroutine(HandleSpawning());
    }

    private IEnumerator HandleSpawning()
    {
        yield return new WaitForSeconds(3f);
        yield return new WaitUntil(() => CanSpawn);

        // Inicia el spawn de asteroides
        StartCoroutine(AsteroidSpawn());

        // Inicia el spawn de cada obstáculo activo en la lista
        foreach (var spawner in obstacleSpawners)
        {
            if (spawner.isEnabled)
                StartCoroutine(SpawnObstacle(spawner));
        }

        // Espera hasta que el tiempo máximo se alcance
        yield return new WaitUntil(() => GameManager.instance.Timer >= GameManager.instance.MaxTime);

        // Crea el obstáculo final
        if (finisherSpawner != null && finisherSpawner.factory != null)
        {
            finisherSpawner.factory.CreateObstacle();
        }

        StopAllSpawning();
    }

    public void SetSpawning(bool value)
    {
        CanSpawn = value;
    }

    private void StopAllSpawning()
    {
        StopAllCoroutines();
    }

    private IEnumerator AsteroidSpawn()
    {
        WaitForSeconds wait = new WaitForSeconds(timeBetweenAsteroids);
        while (true)
        {
            Vector2 asteroidRndPos = new Vector2(Random.Range(-2, 14), Random.Range(5, 10));
            asteroidPool.GetFromPool(asteroidRndPos, new Vector2(asteroidData.speedX, asteroidData.speedY));
            yield return wait;
        }
    }

    private IEnumerator SpawnObstacle(ObstacleSpawner spawner)
    {
        yield return new WaitForSeconds(spawner.startDelay);

        WaitForSeconds wait = new WaitForSeconds(spawner.spawnInterval);

        while (!spawner.shouldStopSpawning)
        {
            spawner.factory.CreateObstacle();

            yield return wait;
        }
    }



    public void StopSpawningObstacle(ObstacleFactory factory)
    {
        // Busca el spawner correspondiente y establece `shouldStopSpawning` en true
        ObstacleSpawner spawner = obstacleSpawners.Find(s => s.factory == factory);
        if (spawner != null)
        {
            spawner.shouldStopSpawning = true;
        }
    }
}
