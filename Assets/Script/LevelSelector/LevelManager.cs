using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public TextMeshProUGUI levelText;
    [SerializeField] private int level;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            levelText.text = "PRESS SPACE TO PLAY";
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(level);
            }
        }
    }

    public void onLevelCompleted()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        if (currentLevel >= 3)
        {
            PlayerPrefs.SetInt("levelAt", currentLevel);
            Debug.Log("YOU WIN");
            SceneManager.LoadScene("LevelSelector");
        }

        else if (currentLevel >= PlayerPrefs.GetInt("levelunlocked"))
        {
            PlayerPrefs.SetInt("levelunlocked", currentLevel + 1);
            PlayerPrefs.SetInt("levelAt", currentLevel);
            SceneManager.LoadScene("LevelSelector");
        }
    }
}
