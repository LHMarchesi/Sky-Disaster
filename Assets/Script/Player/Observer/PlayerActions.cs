using UnityEngine;
using System;
public class PlayerActions : MonoBehaviour
{
    public static event Action OnWin;
    public static event Action OnLevelCompleted;
    PlayerManagment playerManagment;
    PlayerHealth playerHealth;

    private void Awake()
    {
        playerManagment = gameObject.GetComponent<PlayerManagment>();
        playerHealth = gameObject.GetComponent<PlayerHealth>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Dead") && playerManagment.CanDie)
        {
            playerHealth.GetDamage();
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

    // Implementar Strategy IInteractuable
}
