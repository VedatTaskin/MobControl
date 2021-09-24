using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StickmanControl : MonoBehaviour
{
    [SerializeField] public float launchAmount = 1f;

    // Start is called before the first frame update
    void Start()
    {
        transform.DOMoveZ(transform.forward.z*launchAmount, 1f);
    }


}
