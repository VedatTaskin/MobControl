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


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.CompareTag("Stickman"))
        {
            shake = false;
            StartCoroutine("Shake");
            other.gameObject.SetActive(false);
        }
    }

    IEnumerator Shake()
    {
        yield return new WaitForSeconds(0.2f);
        if (!shake)
        {
            transform.DOShakeScale(effectDuration, Vector3.one * shakeStrength, shakeVibrato, shakeRandomness);
            shake = true;
        }      
    }


}


