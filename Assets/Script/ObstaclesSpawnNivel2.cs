using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class ObstaclesSpawnNivel2 : MonoBehaviour
{
    [SerializeField] private GameObject AlliesPrefab;
    [SerializeField] private GameObject RayoPrefab;
    [SerializeField] private GameObject TornadoPrefab;
    [SerializeField] private GameObject RescatePrefab;
    [SerializeField] private Transform spawner;
    private float respawnTimeAllies;
    private float respawnTimeRayo;
    private float respawnTimeTornado;
    private float respawnTimeRescate;
    private bool canSpawnAllies;
    private bool canSpawnRayo;
    private bool canSpawnTornado;
    private bool canSpawnRescate;
    private int minRespawnTime = 5;
    private int maxRespawnTime = 15;
    private int randomY;
    private int randomX;
    private float timer;
    public GameManager gameManager;
    private Vector2 spawnAlliePosition;
    private Vector2 spawnRayoPosition;
    private Vector2 spawnTornadoPosition;
    private Vector2 spawnRescatePosition;



    void Start()
    {
        // Timepo de spawneo de enemigos

        respawnTimeRayo = 3f;

        respawnTimeTornado = Random.Range(10, 20);

        respawnTimeRescate = 50f;

        // Timepo de spawneo de aliados con un numero entre 10 y 20s
        respawnTimeAllies = Random.Range(minRespawnTime,maxRespawnTime);


        // Permite saber si se pueden spawnear
        canSpawnAllies = true;
        canSpawnRayo = true;
        canSpawnTornado = true;
        canSpawnRescate = true;

        // Inicia las corrutinas que los spawnean

        StartCoroutine(Tiempoinicial());
    }


    IEnumerator Spawntornado()
    {
        WaitForSeconds wait = new WaitForSeconds(respawnTimeTornado);

        // Inicializa el AsteroidPrefab en la posision que se le da, y con una rotacion por defecto
        while (canSpawnTornado)
        {

            Instantiate(TornadoPrefab, spawnTornadoPosition, Quaternion.identity);

            yield return wait;
        }
    }

    IEnumerator SpawnerRayo()
    {
        WaitForSeconds wait = new WaitForSeconds(respawnTimeRayo);

        // Inicializa el RayoPrefab en la posision que se le da, y con una rotacion por defecto
        while (canSpawnRayo)
        {

            Instantiate(RayoPrefab, spawnRayoPosition, Quaternion.identity);

            yield return wait;
        }
    }

    IEnumerator SpawnerAllies()
    {
        WaitForSeconds wait = new WaitForSeconds(respawnTimeAllies);

        // Inicializa el AlliesPrefab en la posision que se le da, y con una rotacion por defecto
        while (canSpawnAllies)
        {

            Instantiate(AlliesPrefab, spawnAlliePosition, Quaternion.identity);

            yield return wait;
        }
    }


    IEnumerator Tiempoinicial()
    {
        yield return new WaitForSeconds(3);
        StartCoroutine(SpawnerAllies());
        yield return new WaitForSeconds(10);
        StartCoroutine(SpawnerRayo());
        yield return new WaitForSeconds(20);
        StartCoroutine(Spawntornado());
    }

    void Update()
    {
        
        // Da un numero random entre 0 y 15
        randomY = Random.Range(0, 15);
        randomX = Random.Range(-10, 10);
        // Posiocion de el spawn de los enemigos y los aliados
        spawnAlliePosition = new Vector2(spawner.position.x , -2.5f);
        spawnRayoPosition = new Vector2(randomX, 4);
        spawnTornadoPosition = new Vector2(spawner.position.x, 0);
        spawnRescatePosition = new Vector2(spawner.position.x, -1);

        FinisherGame();


    }

    private void FinisherGame()
    {
        if (gameManager.Timer >= 120 && canSpawnRescate)
        {
            canSpawnAllies = false;
            canSpawnRayo = false;
            canSpawnTornado = false;
            


            Instantiate(RescatePrefab, spawnRescatePosition, Quaternion.identity);
            canSpawnRescate = false;

        }
    }

}
