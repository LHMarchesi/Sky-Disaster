using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public float MaxTime { get => maxTime; set => maxTime = value; }
    public float Timer { get => timer; set => timer = value; }

    [SerializeField] private TMP_Text totalPointsText;
    [SerializeField] private ManageSpawning manageSpawning;
    [SerializeField] private TMP_Text totalSavedText;

    private float maxTime;
    private PlayerManagment playerManagment;
    private float timer;
    private int totalPoints;
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
        UIManager.instance.winScreen.SetActive(true);
        manageSpawning.SetSpawning(false);
        totalPoints = playerManagment.Health * playerManagment.AlliesRescues * 10;
        totalPointsText.text = totalPoints.ToString();
        totalSavedText.text = playerManagment.AlliesRescues.ToString();
    }

    public void Lose()
    {
        UIManager.instance.loseScreen.SetActive(true);
        manageSpawning.SetSpawning(false);
        totalPoints = playerManagment.Health * playerManagment.AlliesRescues * 10;
        totalPointsText.text = totalPoints.ToString();
        totalSavedText.text = playerManagment.AlliesRescues.ToString();
    }

    public void Pause()
    {
        UIManager.instance.pauseScreen.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
    }

    public void Resume()
    {
        UIManager.instance.pauseScreen.SetActive(false);
        Time.timeScale = 1.0f;
        isPaused = false;
    }

    public void Restart()
    {
        timer = 0;
        UIManager.instance.winScreen.SetActive(false);
        UIManager.instance.loseScreen.SetActive(false);
        UIManager.instance.pauseScreen.SetActive(false);
    }
}
