using UnityEngine;

public class ExtraLifePowerUp : MonoBehaviour, IPowerUp
{
    public void Activate()
    {
        PlayerHealth playerHealth = FindObjectOfType<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.AddLife();
            Debug.Log("Extra life activated.");
        }
    }
}
