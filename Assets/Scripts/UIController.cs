using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    private static UIController instance;
    public static UIController Instance { get => instance; set => instance = value; }

    private int score = 0;

    [Header("GamePlay")]
    [SerializeField] GameObject gamePlayMenu;
    [SerializeField] Slider slider;
    [SerializeField] Image fill;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI enemyHouseHealthText;

    [Header("WinMenu")]
    [SerializeField] GameObject winMenu;

    [Header("LoseMenu")]
    [SerializeField] GameObject loseMenu;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }


    public void SetScore()
    {
        score++;
        scoreText.text = score.ToString();        
    }


    public void SetEnemyHouseHealth(int enemyHouseHealth)
    {
        enemyHouseHealthText.text = enemyHouseHealth.ToString();
    }


    public void SetCannonSlider(float value)
    {
        slider.value = value;

        if (value == 1)
        {
            fill.color = Color.yellow;
        }
        else 
        {
            fill.color = Color.blue;
        }
    }

    public void WinMenu()
    {
        gamePlayMenu.SetActive(false);
        winMenu.SetActive(true);
    }

    public void LoseMenu()
    {
        gamePlayMenu.SetActive(false);
        loseMenu.SetActive(true);
    }

    public void ShowReleaseText()
    {

    }
}
