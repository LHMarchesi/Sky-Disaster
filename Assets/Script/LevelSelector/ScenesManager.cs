using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public int nextSceneLoad;
    private void Start()
    {
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void levelSelectorMenu()
    {
        SceneManager.LoadScene(1);
        if (nextSceneLoad > PlayerPrefs.GetInt("levelAt"))
        {
            PlayerPrefs.SetInt("levelAt", nextSceneLoad);
        }
    }

    public void nextLevel()
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

    public void GoMenu()
    {
        SceneManager.LoadScene(0);
    }
}
