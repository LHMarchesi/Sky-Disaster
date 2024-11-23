using UnityEngine;

public class ImmunityPowerUp : MonoBehaviour, IPowerUp
{
    public void Activate()
    {
        PlayerHealth playerHealth = FindObjectOfType<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.ActivateImmunity(5f);
            Debug.Log("Inmmunity activated.");
        }
    }
}