using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public float MaxTime { get => maxTime; set => maxTime = value; }
    public float Timer { get => timer; set => timer = value; }

    [SerializeField] private ManageSpawning manageSpawning;
    [SerializeField] private float maxTime;
    private PlayerManagment playerManagment;

    private float timer;
    private bool isPaused;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        playerManagment = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManagment>();
    }

    private void OnEnable()
    {
        manageSpawning.SetSpawning(true);
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Win()
    {
        manageSpawning.SetSpawning(false);

        UIManager.instance.winScreen.gameObject.SetActive(true);
        int totalPoints = playerManagment.Health * playerManagment.AlliesRescues * 10;
        UIManager.instance.winScreen.UpdateScreen(totalPoints, playerManagment.AlliesRescues);
    }

    public void Lose()
    {
        manageSpawning.SetSpawning(false);

        UIManager.instance.loseScreen.gameObject.SetActive(true);
        int totalPoints = playerManagment.Health * playerManagment.AlliesRescues * 10;
        UIManager.instance.loseScreen.UpdateScreen(totalPoints, playerManagment.AlliesRescues);
    }

    public void Pause()
    {
        Time.timeScale = 0;
        isPaused = true;
        UIManager.instance.pauseScreen.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1.0f;
        isPaused = false;
        UIManager.instance.pauseScreen.SetActive(false);
    }

    public void Restart()
    {
        timer = 0;
        UIManager.instance.winScreen.gameObject.SetActive(false);
        UIManager.instance.loseScreen.gameObject.SetActive(false);
        UIManager.instance.pauseScreen.SetActive(false);
    }
}
