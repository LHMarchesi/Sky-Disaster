using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerMemento : MonoBehaviour
{
    private PlayerMemento savedMemento;
    private PlayerManagment player;

    private void Start()
    {
        player = FindObjectOfType<PlayerManagment>();
    }

    public void SavePlayerPosition()
    {
     //   savedMemento = player.SavePosition();
    }

    public void RestorePlayerPosition()
    {
        if (savedMemento != null)
        {
       //     player.RestorePosition(savedMemento);
        }
    }

    public void PlayerDied()
    {
        RestorePlayerPosition();
    }
}
