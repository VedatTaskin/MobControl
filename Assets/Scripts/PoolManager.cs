using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    [SerializeField] private int count = 10;
    [SerializeField] private string name = "x";
    void Awake()
    {
        for (int i = 0; i < count; i++)
        {
            GameObject instance = Instantiate(Resources.Load(name, typeof(GameObject)), transform) as GameObject;
            instance.SetActive(false);
        }
    }
}
