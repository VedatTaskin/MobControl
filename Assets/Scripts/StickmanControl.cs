using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


[RequireComponent(typeof(Rigidbody))]
public class StickmanControl : MonoBehaviour
{

    [SerializeField] private float launchAmount;
    [SerializeField] private float speed;
    Rigidbody rb;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        transform.DOMoveZ(transform.forward.z * launchAmount, 1f).OnComplete(AddVelocity);        
    }

    void AddVelocity()
    {
        rb.velocity = new Vector3(0, 0, speed);
    }


}
