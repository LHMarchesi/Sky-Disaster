using UnityEngine;
public class RescueSimple : IRescueStrategy
{
    public void Rescue(PlayerManagment playerManagment, Allie allie)
    {
        playerManagment.AllieSaved();
        Debug.Log("Ally rescued!");
    }
}

