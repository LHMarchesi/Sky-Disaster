using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static event Action OnDead;
    public static event Action OnGetDamage;
    [SerializeField] private int health;
    PlayerManagment playerManagment;
   
    public int Health { get => health; private set => health = value; }
    private void Awake()
    {
        playerManagment = GetComponent<PlayerManagment>();
    }

    public void GetDamage()
    {
        if (playerManagment.CanDie)
        {
            OnGetDamage?.Invoke();
            health -= 1;
        }
    }

    private void Update()
    {
        if (health <= 0)
        {
            OnDead?.Invoke();
        }
    }
}
