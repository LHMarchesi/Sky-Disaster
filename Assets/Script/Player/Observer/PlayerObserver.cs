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
        PlayerActions.OnRescue += AllieRescue;
    }

    void OnDisable()
    {
        PlayerHealth.OnGetDamage -= playerManagment.RespawnTime;
        PlayerHealth.OnDead -= OnLose;

        PlayerActions.OnWin -= OnWin;
        PlayerActions.OnRescue -= AllieRescue;

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
    
    private void AllieRescue()
    {
        playerManagment.AllieSaved();
    }
}

