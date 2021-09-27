using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickmanHealthControl : MonoBehaviour
{
    public int health;// enemy has 1, stickman has 2 health,  bigman has 10 health 
    public ParticleSystem splashEffect;
    public ParticleSystem redSplashEffect;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //enemy will destroy
            UIController.Instance.SetLevelScore();
            collision.gameObject.SetActive(false);
            Destroy(Instantiate(redSplashEffect, collision.gameObject.transform.position, Quaternion.identity), 1);

            //one health decrease
            health--; 

            //checking our health
            if (health <= 0)
            {
                Destroy(Instantiate(splashEffect, transform.position, Quaternion.identity), 1);
                transform.gameObject.SetActive(false);
            }
        }
    }

}
