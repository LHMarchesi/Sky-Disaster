using System.Collections;
using UnityEngine;

public class ManageSpawning : MonoBehaviour
{
    [SerializeField] private float asteroidRespawnTime;
    [SerializeField] private float brokenBuildingRespawnTime;
    [SerializeField] private float alliesRespawnTime;
    [SerializeField] private float tsunamiRespawnTime;

    [SerializeField] AsteroidPool asteroidPool;
    [SerializeField] GameObject BrokenBuildingPrefab;
    [SerializeField] GameObject AlliesPrefab;
    [SerializeField] GameObject tsunamiPrefab;

    private Vector2 asteroidRndPos;

    public IEnumerator SetSpawning(bool value)
    {
        while (value)
        {
            //  yield return new WaitForSeconds(5);
            StartCoroutine(AsteroidSpawn());
            StartCoroutine(AlliesSpawn());
            yield return new WaitForSeconds(30);
            StartCoroutine(BrokenBuildingSpawn());
            yield return new WaitForSeconds(10);
            StartCoroutine(TsunamiSpawn());
        }
    }

    private IEnumerator AsteroidSpawn()
    {
        WaitForSeconds wait = new WaitForSeconds(asteroidRespawnTime);
        while (true)
        {
            asteroidRndPos = new Vector2(Random.Range(-2, 10), Random.Range(5, 10));
            asteroidPool.GetFromPool(asteroidRndPos, new Vector2(-200, -150));
            yield return wait;
        }
    }

    private IEnumerator BrokenBuildingSpawn()
    {
        WaitForSeconds wait = new WaitForSeconds(brokenBuildingRespawnTime);
        while (true)
        {
            //Instantiate(BrokenBuildingPrefab, brokenBuildinRndPos, Quaternion.identity);
            yield return wait;
        }
    }

    private IEnumerator AlliesSpawn()
    {
        WaitForSeconds wait = new WaitForSeconds(alliesRespawnTime);
        while (true)
        {
            //  Instantiate(AlliesPrefab, alliesRndPos, Quaternion.identity);
            yield return wait;
        }
    }

    private IEnumerator TsunamiSpawn()
    {
        WaitForSeconds wait = new WaitForSeconds(tsunamiRespawnTime);
        while (true)
        {
            //  Instantiate(tsunamiPrefab, tsunamiRndPos, Quaternion.identity);
            yield return wait;
        }
    }
}
