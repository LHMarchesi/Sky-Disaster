using UnityEngine;
public class RescueWithBonus : IRescueStrategy
{
    public void Rescue(PlayerManagment playerManagment, Allie allie)
    {
        playerManagment.AllieSaved();
        Debug.Log("Ally rescued with bonus!");
    }
}

