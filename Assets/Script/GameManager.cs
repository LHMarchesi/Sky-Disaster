using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            playerManagment = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManagment>();
            UIManager = GameObject.FindGameObjectWithTag("UI").GetComponent<UIManager>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public float MaxTime { get => maxTime; set => maxTime = value; }
    public float Timer { get => timer; set => timer = value; }

    [SerializeField] private TMP_Text totalPointsText;
    [SerializeField] private ObstaclesSpawnNivel1 obstaclesSpawn;
    [SerializeField] private TMP_Text totalSavedText;

    private PlayerManagment playerManagment;
    private UIManager UIManager;
    private float timer;
    private float maxTime = 120;
    private int totalPoints;
    private bool isPaused;

    private void Start()
    {
        obstaclesSpawn.SetSpawning(true);
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
        UIManager.winScreen.SetActive(true);
        obstaclesSpawn.SetSpawning(false);
        totalPoints = playerManagment.Health * playerManagment.AlliesRescues * 10;
        totalPointsText.text = totalPoints.ToString();
        totalSavedText.text = playerManagment.AlliesRescues.ToString();
    }

    public void Lose()
    {
        UIManager.loseScreen.SetActive(true);
        obstaclesSpawn.SetSpawning(false);
        totalPoints = playerManagment.Health * playerManagment.AlliesRescues * 10;
        totalPointsText.text = totalPoints.ToString();
        totalSavedText.text = playerManagment.AlliesRescues.ToString();
    }

    public void Pause()
    {
        UIManager.pauseScreen.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
    }

    public void Resume()
    {
        UIManager.pauseScreen.SetActive(false);
        Time.timeScale = 1.0f;
        isPaused = false;
    }

    public void Restart()
    {
        obstaclesSpawn.SetSpawning(true);
        timer = 0;
        UIManager.winScreen.SetActive(false);
        UIManager.loseScreen.SetActive(false);
        UIManager.pauseScreen.SetActive(false);
    }
}
