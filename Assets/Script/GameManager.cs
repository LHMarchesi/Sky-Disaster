using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject winScreen;
    public GameObject loseScreen;
    public GameObject pauseScreen;
    
    
    public float Timer;
    public float MaxTime = 120;
    public int totalPoints;
    [SerializeField] private TMP_Text totalPointsText;
    [SerializeField] private TMP_Text totalSavedText;
    [SerializeField] private PlayerManagment playerManagment;
    

    public bool isPaused;



    void Start()
    {
        
        winScreen.SetActive(false);
        loseScreen.SetActive(false);
        pauseScreen.SetActive(false);
        Time.timeScale = 1.0f;
        Timer = 0;
        totalPoints = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused) {
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
        winScreen.SetActive(true);
        Time.timeScale = 0;
        totalPoints = playerManagment.HP * playerManagment.AlliesRescues * 10;
        totalPointsText.text = totalPoints.ToString();
        totalSavedText.text = playerManagment.AlliesRescues.ToString();
       
    }

    public void Lose()
    {
        loseScreen.SetActive(true);
        Time.timeScale = 0;
        totalPoints = playerManagment.HP * playerManagment.AlliesRescues * 10;
        totalPointsText.text = totalPoints.ToString();
        totalSavedText.text = playerManagment.AlliesRescues.ToString();
        
    }

    public void Pause()
    {
        pauseScreen.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
    }

    public void Resume()
    {
        pauseScreen.SetActive(false);
        Time.timeScale = 1.0f;
        isPaused = false;
    }

    public void GoFinish()
    {
        Timer = MaxTime;
    }


}
