using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class ObstaclesSpawnNivel1 : MonoBehaviour
{
    [SerializeField] private GameObject AlliesPrefab;
    [SerializeField] private GameObject TsunamiPrefab;
    [SerializeField] private GameObject EdificioRoto;
    [SerializeField] public GameObject Finisher;
    [SerializeField] private Transform spawner;
    private float respawnTimeEnemys;
    private float respawnTimeEdificio;
    private float respawnTimeAllies;
    private float respawnTimeTsunami;
    private bool canSpawnEnemys;
    private bool canSpawnEdificio;
    private bool canSpawnAllies;
    private bool canSpawnFinisher = true;
    private bool canSpawnTsunami;
    private int minRespawnTime = 5;
    private int maxRespawnTime = 10;
    private int minTsunamiRespawnTime = 10;
    private int maxTsunamiRespawnTime = 15;
    private int minEdificioRespawnTime = 20;
    private int maxEdificioRespawnTime = 30;
    private int randomY;
    private Vector2 asteroidRndPos;
    private Vector2 spawnAlliePosition;
    private Vector2 spawnEdificioPosition;
    private Vector2 spawnTsunamiPosition;
    private Vector2 spawnFinisherPosition;
    private Vector2 FinisherPosition;
    public bool finisherIsSpawn = false;


    [SerializeField] AsteroidPool asteroidPool;

    private void Start()
    {
        // Timepo de spawneo de enemigos
        respawnTimeEnemys = 1f;
        respawnTimeAllies = Random.Range(minRespawnTime, maxRespawnTime);
        respawnTimeTsunami = Random.Range(minTsunamiRespawnTime, maxTsunamiRespawnTime);
        respawnTimeEdificio = Random.Range(minEdificioRespawnTime, maxEdificioRespawnTime);
              
    }

    public void SetSpawning(bool value)
    {
        if (value)
        {
            StartCoroutine(StartSpawning());
            canSpawnEnemys = true;
            canSpawnEdificio = true;
            canSpawnAllies = true;
            canSpawnTsunami = true;
        }
        else
        {
            StopAllCoroutines();
            canSpawnEnemys = false;
            canSpawnEdificio = false;
            canSpawnAllies = false;
            canSpawnTsunami = false;
        }
    }

    private IEnumerator SpawnerEnemys()
    {
        WaitForSeconds wait = new WaitForSeconds(respawnTimeEnemys);

        while (canSpawnEnemys)
        {
            asteroidPool.GetFromPool(asteroidRndPos, new Vector2(-200, -150));
            yield return wait;
        }
    }
    private IEnumerator SpawnerEdificio()
    {
        WaitForSeconds wait = new WaitForSeconds(respawnTimeEdificio);
        while (canSpawnEdificio)
        {
            Instantiate(EdificioRoto, spawnEdificioPosition, Quaternion.identity);
            yield return wait;
        }
    }
    private IEnumerator SpawnerAllies()
    {
        WaitForSeconds wait = new WaitForSeconds(respawnTimeAllies);
        while (canSpawnAllies)
        {
            Instantiate(AlliesPrefab, spawnAlliePosition, Quaternion.identity);
            yield return wait;
        }
    }
    private IEnumerator SpawnerTsunami()
    {
        WaitForSeconds wait = new WaitForSeconds(respawnTimeTsunami);
        while (canSpawnTsunami)
        {
            Instantiate(TsunamiPrefab, spawnTsunamiPosition, Quaternion.identity);
            yield return wait;
        }
    }

    public IEnumerator StartSpawning()
    {
        yield return new WaitForSeconds(5);
        StartCoroutine(SpawnerEnemys());
        StartCoroutine(SpawnerAllies());
        yield return new WaitForSeconds(30);
        StartCoroutine(SpawnerEdificio());
        yield return new WaitForSeconds(10);
        StartCoroutine(SpawnerTsunami());
    }

    private void Update()
    {
        // Da un numero random entre 0 y 15
        randomY = Random.Range(0, 15);
        // Posiocion de el spawn de los enemigos y los aliados
        asteroidRndPos = new Vector2(spawner.position.x, randomY);
        spawnEdificioPosition = new Vector2(spawner.position.x + 5, 0.14f);
        spawnAlliePosition = new Vector3(spawner.position.x - 3, -4.1f, 9);
        spawnTsunamiPosition = new Vector2(spawner.position.x + 10, 0);
        spawnFinisherPosition = new Vector2(spawner.position.x, -1);

        FinishGame();
    }


    private void FinishGame()
    {
        if (GameManager.instance.Timer >= 120 && canSpawnFinisher)
        {
            canSpawnEnemys = false;
            canSpawnEdificio = false;
            canSpawnAllies = false;
            canSpawnTsunami = false;

            Instantiate(Finisher, spawnFinisherPosition, Quaternion.identity);

            StopAllCoroutines();

            canSpawnFinisher = false;
        }
    }
}
