using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class ObstaclesSpawnNivel1 : MonoBehaviour
{
    [SerializeField] private GameObject AsteroidPrefab;
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
    private Vector2 spawnEnemyPosition;
    private Vector2 spawnAlliePosition;
    private Vector2 spawnEdificioPosition;
    private Vector2 spawnTsunamiPosition;
    private Vector2 spawnFinisherPosition;
    private Vector2 FinisherPosition;
    public GameManager gameManager;
    public bool finisherIsSpawn = false;


    private void Start()
    {
        // Timepo de spawneo de enemigos
        respawnTimeEnemys = 1f;

        // Timepo de spawneo de aliados con un numero entre 10 y 20s
        respawnTimeAllies = Random.Range(minRespawnTime, maxRespawnTime);

        // Timepo de spawneo de Tsunami con un numero entre 20 y 30s
        respawnTimeTsunami = Random.Range(minTsunamiRespawnTime, maxTsunamiRespawnTime);

        respawnTimeEdificio = Random.Range(minEdificioRespawnTime, maxEdificioRespawnTime);

        // Permite saber si se pueden spawnear
        canSpawnEnemys = true;
        canSpawnEdificio = true;
        canSpawnAllies = true;
        canSpawnTsunami = true;

        // Inicia las corrutinas que los spawnean

        StartCoroutine(InitialTime());
    }

    private IEnumerator SpawnerEnemys()
    {
        WaitForSeconds wait = new WaitForSeconds(respawnTimeEnemys);

        // Inicializa el AsteroidPrefab en la posision que se le da, y con una rotacion por defecto
        while (canSpawnEnemys)
        {
           
            Instantiate(AsteroidPrefab, spawnEnemyPosition, Quaternion.identity);

            yield return wait;
        }
    }
    private IEnumerator SpawnerEdificio()
    {
        WaitForSeconds wait = new WaitForSeconds(respawnTimeEdificio);

        // Inicializa el EdificioRoto en la posision que se le da, y con una rotacion por defecto
        while (canSpawnEdificio)
        {

            Instantiate(EdificioRoto, spawnEdificioPosition, Quaternion.identity);

            yield return wait;
        }
    }
    private IEnumerator SpawnerAllies()
    {
        WaitForSeconds wait = new WaitForSeconds(respawnTimeAllies);

        // Inicializa el AlliesPrefab en la posision que se le da, y con una rotacion por defecto
        while (canSpawnAllies)
        {

            Instantiate(AlliesPrefab, spawnAlliePosition, Quaternion.identity);

            yield return wait;
        }
    }

    private IEnumerator SpawnerTsunami()
    {
        WaitForSeconds wait = new WaitForSeconds(respawnTimeTsunami);

        // Inicializa el AsteroidPrefab en la posision que se le da, y con una rotacion por defecto
        while (canSpawnTsunami)
        {

            Instantiate(TsunamiPrefab, spawnTsunamiPosition, Quaternion.identity);

            yield return wait;
        }
    }

    private IEnumerator InitialTime()
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
        spawnEnemyPosition = new Vector2(spawner.position.x, randomY);
        spawnEdificioPosition = new Vector2(spawner.position.x + 5, 0.14f);
        spawnAlliePosition = new Vector3(spawner.position.x - 3, -4.1f, 9);
        spawnTsunamiPosition = new Vector2(spawner.position.x + 10, 0);
        spawnFinisherPosition = new Vector2(spawner.position.x, -1);

        FinishGame();

        

    }


    private void FinishGame()
    {
        if (gameManager.Timer >= 120 && canSpawnFinisher)
        {
            canSpawnEnemys = false;
            canSpawnEdificio = false;
            canSpawnAllies = false;
            canSpawnTsunami = false;

            
            Instantiate(Finisher, spawnFinisherPosition, Quaternion.identity);
            
            canSpawnFinisher = false;

            
        }
    }

}
