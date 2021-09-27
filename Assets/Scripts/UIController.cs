using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;

public class UIController : MonoBehaviour
{
    private static UIController instance;
    public static UIController Instance { get => instance; set => instance = value; }

    private int score = 0;

    [Header("GamePlay")]
    [SerializeField] GameObject gamePlayMenu;
    [SerializeField] GameObject touchWarning;
    [SerializeField] GameObject releaseWarning;
    [SerializeField] Slider slider;
    [SerializeField] Image fill;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI enemyHouseHealthText;

    [Header("WinMenu")]
    [SerializeField] GameObject winMenu;

    [Header("LoseMenu")]
    [SerializeField] GameObject loseMenu;


    //first tap of the player observing
    private void OnEnable()
    {
        CannonControl.onFirstTouch += GameStarted;
    }
    private void OnDisable()
    {
        CannonControl.onFirstTouch -= GameStarted;
    }


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
            ShowReleaseText(true);
        }
        else 
        {
            fill.color = Color.blue;
            ShowReleaseText(false);
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

    public void ShowReleaseText(bool release)
    {
        if (release)
        {
            releaseWarning.SetActive(true);
            releaseWarning.transform.DOScale(Vector3.one * 1.2f, 1);
        }
        if (!release)
        {
            releaseWarning.SetActive(false);
            releaseWarning.transform.DOScale(Vector3.one * 0.2f, 0.1f);
        }
    }

    void GameStarted(bool isGameStarted)
    {
        touchWarning.gameObject.SetActive(false);
    }
}
