using System.Collections;
using UnityEngine;

public class PlayerManagment : MonoBehaviour
{
    public int Health { get => health; set => health = value; }
    public int AlliesRescues { get => alliesRescues; set => alliesRescues = value; }

    [SerializeField] private GameObject spawnPoint;
    [SerializeField] private int health;
    [SerializeField] private int alliesRescues;

    private int levelcompleted = 0;
    private int nivel = 0;
    private float currentPosition;
    private bool canDie;
    private bool isDead;
    private Animator animator;

    private void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
    }
    void Start()
    {
        health = 3;
        alliesRescues = 0;
        canDie = true;
        isDead = false;
    }

    void Update()
    {
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
            Health--;
            transform.position = spawnPoint.transform.position;
            if (Health <= 0)
            {
                Destroy(gameObject);
                GameManager.instance.Lose();
                StopAllCoroutines();
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
            levelcompleted++;
            GameManager.instance.Win();
            StopAllCoroutines();
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
