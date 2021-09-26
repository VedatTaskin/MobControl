﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickmanHealthControl : MonoBehaviour
{
    [SerializeField] private int health = 2; // one enemy has 1, one stickman has 2 health.

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            UIController.Instance.SetScore();
            collision.gameObject.SetActive(false);
            health--;

            if (health <= 0)
            {
                transform.gameObject.SetActive(false);
            }
        }
    }

}