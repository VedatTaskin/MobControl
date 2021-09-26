using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    [SerializeField] private int countOfEnemy = 10;
    void Awake()
    {
        for (int i = 0; i < countOfEnemy; i++)
        {
            GameObject instance = Instantiate(Resources.Load("EnemyStickman", typeof(GameObject)), transform) as GameObject;
            instance.SetActive(false);
        }
    }
}
