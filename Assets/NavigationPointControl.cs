using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationPointControl : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.CompareTag("Stickman"))
        {
            other.gameObject.GetComponent<Rigidbody>().velocity=Vector3.zero;
            other.gameObject.GetComponent<StickmanControl>().enabled = false;
            other.gameObject.GetComponent<StickmanNavmeshControl>().enabled = true;
        }        
    }
}
