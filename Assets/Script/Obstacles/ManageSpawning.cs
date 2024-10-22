using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class ManageSpawning : MonoBehaviour
{
    [SerializeField] AsteroidPool asteroidPool;

    [SerializeField] ObstacleFactory tsunamiFactory;
    [SerializeField] ObstacleFactory brokenBuildingFactory;
    [SerializeField] ObstacleFactory allieFactory;
    [SerializeField] ObstacleFactory finisherFactory;

    public bool CanSpawn { get; private set; }

    private void Start()
    {
        StartCoroutine(HandleSpawning());
    }

    private IEnumerator HandleSpawning()
    {
        yield return new WaitForSeconds(3f);
        yield return new WaitUntil(() => CanSpawn);

        StartCoroutine(AsteroidSpawn());
        StartCoroutine(AlliesSpawn());

        yield return new WaitForSeconds(30f); 
        StartCoroutine(BrokenBuildingSpawn());

        yield return new WaitForSeconds(10f); 
        StartCoroutine(TsunamiSpawn());
        yield return new WaitUntil(() => GameManager.instance.Timer >= GameManager.instance.MaxTime);
        finisherFactory.CreateObstacle();

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
        float asteroidRespawnTime = Random.Range(1, 3);
        WaitForSeconds wait = new WaitForSeconds(asteroidRespawnTime);
        while (true)
        {
            Vector2 asteroidRndPos = new Vector2(Random.Range(-2, 14), Random.Range(5, 10));
            asteroidPool.GetFromPool(asteroidRndPos, new Vector2(-200, -150));
            yield return wait;
        }
    }

    private IEnumerator BrokenBuildingSpawn()
    {
        float brokenBuildingRespawnTime = Random.Range(12, 15);
        WaitForSeconds wait = new WaitForSeconds(brokenBuildingRespawnTime);
        while (true)
        {
            brokenBuildingFactory.CreateObstacle();
            yield return wait;
        }
    }

    private IEnumerator AlliesSpawn()
    {
        float alliesRespawnTime = Random.Range(5, 10);
        WaitForSeconds wait = new WaitForSeconds(alliesRespawnTime);
        while (true)
        {
            allieFactory.CreateObstacle();
            yield return wait;
        }
    }

    private IEnumerator TsunamiSpawn()
    {
        float tsunamiRespawnTime = Random.Range(10, 20);
        WaitForSeconds wait = new WaitForSeconds(tsunamiRespawnTime);
        while (true)
        {
            tsunamiFactory.CreateObstacle();
            yield return wait;
        }
    }
}
