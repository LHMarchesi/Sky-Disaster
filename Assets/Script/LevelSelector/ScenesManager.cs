using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    private int nextSceneLoad;
    private void Start()
    {
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }

    public void levelSelectorMenu()
    {
        SceneManager.LoadScene(1);
        if (nextSceneLoad > PlayerPrefs.GetInt("levelAt"))
        {
            PlayerPrefs.SetInt("levelAt", nextSceneLoad);
        }
    }

    public void Golevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
        Time.timeScale = 1f;
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(nextSceneLoad);

        if (nextSceneLoad > PlayerPrefs.GetInt("levelAt"))
        {
            PlayerPrefs.SetInt("levelAt", nextSceneLoad);
        }
    }

    public void QuitGame()
    {
        PlayerPrefs.DeleteAll();
        Application.Quit();
    }

    public void RestartGame()
    {
        GameManager.instance.Restart();
        int actualScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(actualScene);
    }

    public void NextScene()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        currentIndex++;

        if (currentIndex > 3)
        {
            currentIndex = 0;
            SceneManager.LoadScene(currentIndex);
        }
        else
            SceneManager.LoadScene(currentIndex);
    }

    public void GoMenu()
    {
        SceneManager.LoadScene(0);
    }
}
