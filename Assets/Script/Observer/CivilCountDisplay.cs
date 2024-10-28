using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CivilCountDisplay : MonoBehaviour, IObserver
{
    [SerializeField] private TextMeshProUGUI civilCountText;
    private CivilRescueManager rescueManager;

    private void Start()
    {
        rescueManager = FindObjectOfType<CivilRescueManager>();
        if (rescueManager != null)
        {
            rescueManager.RegisterObserver(this);
            UpdateRescueCount(rescueManager.GetRescuedCivilians());
        }
    }

    public void UpdateRescueCount(int count)
    {
        civilCountText.text = "Civiles Rescatados: " + count;
    }

    private void OnDestroy()
    {
        if (rescueManager != null)
        {
            rescueManager.UnregisterObserver(this);
        }
    }
}
