using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    private static UIController instance;
    public static UIController Instance { get => instance; set => instance = value; }

    private int score = 0;

    [Header("GamePlay")]
    [SerializeField] GameObject gamePlayMenu;
    [SerializeField] TextMeshProUGUI scoreText;

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


}
