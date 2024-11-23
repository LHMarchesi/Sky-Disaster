using UnityEngine;

public class LevelSelector : MonoBehaviour
{
    public GameObject[] LevelButtons;
    public GameObject[] winIcon;

    int levelunlocked;

    private void Start()
    {
        Time.timeScale = 1.0f;

        int levelAt = PlayerPrefs.GetInt("levelAt", 0);
        levelunlocked = PlayerPrefs.GetInt("levelunlocked", 1);

        for (int i = 0; i < LevelButtons.Length; i++)
        {
            LevelButtons[i].SetActive(false);
        }

        for (int i = 0; i < winIcon.Length; i++)
        {
            winIcon[i].SetActive(false);
        }

        for (int i = 0; i < levelAt; i++)
        {
            winIcon[i].SetActive(true);
        }

        for (int i = 0; i < levelunlocked; i++)
        {
            LevelButtons[i].SetActive(true);
        }
    }
}
