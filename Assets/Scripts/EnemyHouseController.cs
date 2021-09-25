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


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.CompareTag("Stickman"))
        {
            transform.DOShakeScale(effectDuration, Vector3.one * shakeStrength, shakeVibrato, shakeRandomness);
            other.gameObject.SetActive(false);
        }
    }
}


