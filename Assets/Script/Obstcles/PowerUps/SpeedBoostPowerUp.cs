using UnityEngine;

public class SpeedBoostPowerUp : MonoBehaviour, IPowerUp
{
    public float speedMultiplier = 2f;
    public float boostDuration = 5f;

    public void Activate()
    {
        Movement movement = FindObjectOfType<Movement>();
        if (movement != null)
        {
            movement.BoostSpeed(speedMultiplier, boostDuration);
            Debug.Log("Speed boost activated.");
        }
    }
}