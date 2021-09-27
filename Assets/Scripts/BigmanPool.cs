using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigmanPool : MonoBehaviour
{
    [SerializeField] private int countOfBigman = 100;

    void Awake()
    {
        for (int i = 0; i < countOfBigman; i++)
        {
            GameObject instance = Instantiate(Resources.Load("Bigman", typeof(GameObject)), transform) as GameObject;
            instance.SetActive(false);
        }
    }
}
