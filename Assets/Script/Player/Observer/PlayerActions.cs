using UnityEngine;
using System;

public class PlayerActions : MonoBehaviour
{
    public static event Action OnWin;

    PlayerManagment playerManagment;
    PlayerHealth playerHealth;

    private void Awake()
    {
        playerManagment = gameObject.GetComponent<PlayerManagment>();
        playerHealth = gameObject.GetComponent<PlayerHealth>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IInteractuable interactuable = collision.GetComponent<IInteractuable>();

        if (interactuable != null)
        {
            interactuable.Interact();
        }

        if (collision.CompareTag("Dead") && playerManagment.CanDie)
        {
            playerHealth.GetDamage();
        }

        if (collision.CompareTag("Win"))
        {
            OnWin?.Invoke();
            playerManagment.LevelCompleted();
        }
    }
}


