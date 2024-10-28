using System.Collections;
using UnityEngine;

public class PlayerManagment : MonoBehaviour
{
    public int Health { get => health; set => health = value; }
    public int AlliesRescues { get => alliesRescues; set => alliesRescues = value; }
    public bool CanDie { get => canDie; set => canDie = value; }

    [SerializeField] private GameObject spawnPoint;
    [SerializeField] private int health;
    [SerializeField] private int alliesRescues;

    private int levelcompleted = 0;
    private float currentPosition;
    private bool canDie;
    private bool isDead;
    private Animator animator;

    private PlayerActions playerActions;

    private void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
        playerActions = gameObject.GetComponent<PlayerActions>();
    }
    void Start()
    {
        health = 3;
        alliesRescues = 0;
        CanDie = true;
        isDead = false;
    }

    void Update()
    {
        // Si esta muerto, no puede morir y inicia la corrutina RespawnTime
        if (isDead)
        {
            CanDie = false;
            animator.SetBool("Dead", true);
            StartCoroutine(RespawnTime());
        }
    }

    public void GetDamage()
    {
        isDead = true;
        Health--;
        transform.position = spawnPoint.transform.position;
    }

    public void AllieSaved()
    {
        alliesRescues++;
    }

    public void LevelCompleted()
    {
        levelcompleted++;
    }


    // Espera 2 segundos luego puede morir y ya no estara muerto(Tiempo de Respawn)
    private IEnumerator RespawnTime()
    {
        yield return new WaitForSeconds(2);

        CanDie = true;
        isDead = false;
        animator.SetBool("Dead", false);
    }
}
