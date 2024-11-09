using UnityEngine;

public class PlayerObserver : MonoBehaviour
{
    PlayerManagment playerManagment;
    private void Awake()
    {
        playerManagment = GetComponent<PlayerManagment>();
    }

    void Start()
    {
        PlayerHealth.OnGetDamage += playerManagment.RespawnTime;
        PlayerHealth.OnDead += OnLose;
        PlayerActions.OnWin += OnWin;
    }

    void OnDisable()
    {
        PlayerHealth.OnGetDamage -= playerManagment.RespawnTime;
        PlayerHealth.OnDead -= OnLose;
        PlayerActions.OnWin -= OnWin;
    }

    private void OnLose()
    {
        GameManager.instance.Lose();
        StopAllCoroutines();

        Destroy(gameObject);
    }
    
    private void OnWin()
    {
        GameManager.instance.Win();
        StopAllCoroutines();
    }
}

