using System.Collections;
using System.Collections.Generic;
using TMPro;
using System;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Image ProgessionBar;
    public PlayerManagment playerManagment;
    public  TextMeshProUGUI textCiviles;
    public Image[] hearts;
    public Sprite fulledHeart;
    public Sprite emptyHeart;

    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        
       
    }

    void Update()
    {
        textCiviles.text = playerManagment.AlliesRescues.ToString();

        foreach (Image img in hearts)
        {
            img.sprite = emptyHeart;
        }


        for (int i = 0; i < playerManagment.HP; i++)
        {
            hearts[i].sprite = fulledHeart;
        }
        UpdateProgessionBar();
    }
        void UpdateProgessionBar()
    {
         float progession = gameManager.Timer / gameManager.MaxTime;
         ProgessionBar.fillAmount = progession;

    }

 
}
