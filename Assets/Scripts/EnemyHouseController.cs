using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyHouseController : MonoBehaviour
{
    
    private float effectDuration = 0.1f;
    private float shakeStrength = 0.5f;
    private int shakeVibrato = 1;
    private float shakeRandomness = 10;
    bool shake = false;

    //we will set number of enemy in every level
    [SerializeField] private int numberOfEnemy=10; // number of enemy in the pool
    
    [SerializeField] private float enemyLaunchStartTime = 1f;
    [SerializeField] private float enemySpawnRepeatRate = 1f;
    [SerializeField] private int enemyHouseHealth = 20;

    int index = 0;  // index of enemy in the pool
    public GameObject enemyPool; // object pool
    private GameObject enemy;


    //first tap of the player observing
    private void OnEnable()
    {
        CannonControl.onFirstTouch += GameStarted;
    }
    private void OnDisable()
    {
        CannonControl.onFirstTouch -= GameStarted;
    }


    private void Start()
    {        
        numberOfEnemy = enemyPool.transform.childCount;
        UIController.Instance.SetEnemyHouseHealth(enemyHouseHealth);
    }

    // checking if a player hits the house
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.CompareTag("Stickman"))
        {
            shake = false;
            StartCoroutine("Shake");
            StickmanCrashed(other.gameObject);
            SetHouseHealth(other.gameObject.GetComponent<StickmanHealthControl>().health);
        }
    }


    // shaking house when a player hits
    IEnumerator Shake()
    {
        yield return new WaitForSeconds(0.2f);
        if (!shake)
        {
            transform.DOShakeScale(effectDuration, Vector3.one * shakeStrength, shakeVibrato, shakeRandomness);
            shake = true;
        }      
    }

    // while player first touches to the screen, enemies began to spawn
    void GameStarted(bool isGameStarted)
    {
        InvokeRepeating("LaunchEnemy", enemyLaunchStartTime, enemySpawnRepeatRate);
    }


    void LaunchEnemy()
    { 

        if (index < numberOfEnemy)
        {
            enemy = enemyPool.transform.GetChild(index).gameObject;
            enemy.transform.position = new Vector3(transform.position.x, 0.6f, transform.position.z - 0.5f);
            enemy.SetActive(true);
            index++;
        }        
    }

    void StickmanCrashed(GameObject other)
    {        
        other.gameObject.SetActive(false);
    }

    void SetHouseHealth(int damage)
    {
        enemyHouseHealth-=damage;
        
        UIController.Instance.SetEnemyHouseHealth(enemyHouseHealth);

        if (enemyHouseHealth <=0)
        {
            YouWon();
        }
    }

    void YouWon()
    {
        UIController.Instance.WinMenu();
        transform.gameObject.SetActive(false);
    }
}


