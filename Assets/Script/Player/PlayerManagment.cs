using System.Collections;
using UnityEngine;

public class PlayerManagment : MonoBehaviour
{
    public int AlliesRescues { get => alliesRescues; set => alliesRescues = value; }
    public bool CanDie { get => canDie; set => canDie = value; }

    [SerializeField] private GameObject spawnPoint;
    [SerializeField] private int alliesRescues;

    private int levelcompleted = 0;
    private float currentPosition;
    private bool canDie;
    private bool isDead;
    private Animator animator;
    private PlayerActions playerActions;
    private PlayerHealth playerHealth;

    private void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
        playerActions = gameObject.GetComponent<PlayerActions>();
        playerHealth = gameObject.GetComponent<PlayerHealth>();
    }
    void Start()
    {
        alliesRescues = 0;
        CanDie = true;
        isDead = false;
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
    public void RespawnTime()
    {
        StartCoroutine(WaitForPlayerRespawn());
    }

    private IEnumerator WaitForPlayerRespawn()
    {
        CanDie = false;
        animator.SetBool("Dead", true);

        yield return new WaitForSeconds(2);

        CanDie = true;
        isDead = false;
        animator.SetBool("Dead", false);
    }
}
