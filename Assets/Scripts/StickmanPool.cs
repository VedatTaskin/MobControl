using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickmanPool : MonoBehaviour
{
    [SerializeField] private int countOfStickman=100;
    
    void Awake()
    {
        for (int i = 0; i < countOfStickman; i++)
        {
            GameObject instance = Instantiate(Resources.Load("Stickman", typeof(GameObject)), transform) as GameObject;
            instance.SetActive(false);
        }
    }
}
