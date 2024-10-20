using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManagment : MonoBehaviour
{
    [SerializeField] private GameObject spawnPoint;
    [SerializeField] public int HP;
    [SerializeField] public int levelcompleted = 0;
    [SerializeField] public int nivel = 0;
    [SerializeField] public int AlliesRescues;
    [SerializeField] private float currentPosition;
    [SerializeField] private bool canDie;
    [SerializeField] private bool isDead;
    public UIManager uIManager;


    public GameManager gameManager;
    public LevelSelector levelselector;

    private Animator animator;
    void Start()
    {
        uIManager = gameObject.GetComponent<UIManager>();
        // Busca el componente Animator
        animator = gameObject.GetComponent<Animator>();
        // Se inicializan las variables 

        HP = 3;
        nivel = 0;
        AlliesRescues = 0;
        canDie = true;
        isDead = false;
        
    }

    // Update is called once per frame
    void Update()
    {
       

        // Se da la informacion de la posicion del jugador
        currentPosition = transform.position.x;

        // si Vida llega a cero se destruye el jugador
        if (HP < 0)
        {
            Destroy(gameObject);
        }
        // Si esta muerto, no puede morir y inicia la corrutina RespawnTime
        if (isDead)
        {
            canDie = false;
            animator.SetBool("Dead", true);
            StartCoroutine(RespawnTime());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Si collisionamos con un objeto con el Tag "Dead" y Pueda morir se nos resta una vida y nos spawnea en la posicion de spawnPoint
        if (collision.CompareTag("Dead") && canDie == true)
        {
            
            isDead = true;
            HP--;
            transform.position = spawnPoint.transform.position;
            if (HP <= 0)
            {
                gameManager.Lose();
            }
        }


        // Si colisionamos con un objeto con el Tag "Allie" Se nos suma un punto a la variable y ese objeto se destruye 
        if (collision.CompareTag("Allie"))
        {
            AlliesRescues++;
            Destroy(collision.gameObject);

        }

        if (collision.CompareTag("Win"))
        {
            Time.timeScale = 0;            
            gameManager.Win();
            levelcompleted++;

        }

    

    }
   


    // Espera 2 segundos luego puede morir y ya no estara muerto(Tiempo de Respawn)
    private IEnumerator RespawnTime()
    {
        yield return new WaitForSeconds(2);

        canDie = true;
        isDead = false;
        animator.SetBool("Dead", false);

    }

   
}
