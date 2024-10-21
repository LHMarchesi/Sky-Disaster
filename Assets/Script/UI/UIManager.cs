using System.Collections;
using System.Collections.Generic;
using TMPro;
using System;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class UIManager : MonoBehaviour
{
    private ProgessBar progessBar;
    private PlayerManagment playerManagment;
    public TextMeshProUGUI textCiviles;
    public Image[] hearts;
    public Sprite fulledHeart;
    public Sprite emptyHeart;

    public GameObject winScreen;
    public GameObject loseScreen;
    public GameObject pauseScreen;


    private void Awake()
    {
        progessBar = GetComponentInChildren<ProgessBar>();
        playerManagment = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManagment>();
    }

    private void Start()
    {
        progessBar.ResetValues();
    }

    void Update()
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

        progessBar.UpdateProgess(GameManager.instance.Timer, GameManager.instance.MaxTime);
    }

}
