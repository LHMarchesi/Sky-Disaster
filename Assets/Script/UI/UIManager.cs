using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    private ProgessBar progessBar;
    private PlayerManagment playerManagment;
    public TextMeshProUGUI textCiviles;
    public Image[] hearts;
    public Sprite fulledHeart;
    public Sprite emptyHeart;

    public UiScreen winScreen;
    public UiScreen loseScreen;
    public GameObject pauseScreen;

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
        progessBar = GetComponentInChildren<ProgessBar>();
        playerManagment = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManagment>();
    }

    private void Start()
    {
        progessBar.ResetValues();
    }

    void Update()
    {
        ManageHealUI();

        progessBar.UpdateProgess(GameManager.instance.Timer, GameManager.instance.MaxTime);
    }

    private void ManageHealUI()
    {
        textCiviles.text = playerManagment.AlliesRescues.ToString();

        foreach (Image img in hearts)
        {
            img.sprite = emptyHeart;
        }

        for (int i = 0; i < playerManagment.Health; i++)
        {
            hearts[i].sprite = fulledHeart;
        }
    }

    public void ShowLoseScreen(int points, int saved)
    {
        loseScreen.gameObject.SetActive(true);
        loseScreen.UpdateScreen(points, saved);
    }

    public void ShowWinScreen(int points, int saved)
    {
        winScreen.gameObject.SetActive(true);
        winScreen.UpdateScreen(points, saved);
    }

    public void Reset()
    {
        UIManager.instance.winScreen.gameObject.SetActive(false);
        UIManager.instance.loseScreen.gameObject.SetActive(false);
        UIManager.instance.pauseScreen.SetActive(false);
    }
}
