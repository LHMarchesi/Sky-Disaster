using TMPro;
using UnityEngine;

public class UiScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI totalPointsText;
    [SerializeField] private TextMeshProUGUI totalSavedText;

    public void UpdateScreen(int totalPoints, int totalSaved)
    {
        totalPointsText.text = totalPoints.ToString();
        totalSavedText.text = totalSaved.ToString();
    }
}
