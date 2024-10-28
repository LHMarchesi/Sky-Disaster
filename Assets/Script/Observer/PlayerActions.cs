using UnityEngine;
using System;
public class PlayerActions : MonoBehaviour
{
    public static event Action OnDead;
    public static event Action OnWin;
    PlayerManagment playerManagment;

    private void Awake()
    {
        playerManagment = gameObject.GetComponent<PlayerManagment>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Dead") && playerManagment.CanDie)
        {
            playerManagment.GetDamage();
            
            if (playerManagment.Health <= 0)
            {
                OnDead?.Invoke();
            }
        }

        if (collision.CompareTag("Allie"))
        {
            playerManagment.AllieSaved();
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("Win"))
        {
            OnWin?.Invoke();
            playerManagment.LevelCompleted();
        }
    }
}
