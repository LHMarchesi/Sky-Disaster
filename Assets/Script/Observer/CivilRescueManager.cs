using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CivilRescueManager : MonoBehaviour
{
    private int rescuedCivilians;
    private List<IObserver> observers = new List<IObserver>();

    public void AddRescuedCivilian()
    {
        rescuedCivilians++;
        NotifyObservers();
    }

    public int GetRescuedCivilians()
    {
        return rescuedCivilians;
    }

    public void RegisterObserver(IObserver observer)
    {
        observers.Add(observer);
    }

    public void UnregisterObserver(IObserver observer)
    {
        observers.Remove(observer);
    }

    private void NotifyObservers()
    {
        foreach (var observer in observers)
        {
            observer.UpdateRescueCount(rescuedCivilians);
        }
    }
}
