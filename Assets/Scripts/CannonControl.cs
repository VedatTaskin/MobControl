using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CannonControl : MonoBehaviour
{

    [SerializeField] private float maxSwerveAmount = 0.3f;   // to limit the canon movement speed; 
    [SerializeField] private float limits = 3f; // right and left limits of our platform
    [SerializeField] private float swerveSpeed = 0.3f; // speed of cannon in X axis    
    private float lastFrameFingerPosition;
    private float deltaMovement;  // movement amount in X axis
    private bool onClick=false;  // control screen touch
    [HideInInspector] public bool firstTouch = false;

    //To control the first touch of player
    public static event Action<bool> onFirstTouch;
    
    public GameObject stickmanPool; // object pool
    private GameObject stickman;
    
    int index = 0;  // index of stickman in the pool
    int numberOfStickman = 0; // number of stick man int the pool

    private void Start()
    {
        numberOfStickman = stickmanPool.transform.childCount;
        InvokeRepeating("LaunchStickman", 0.5f, 0.5f);
    }

    private void Update()
    {
        CalculateSwerveAmount();

        if (onClick)
        {
            MoveCannon();            
        }
    }


    // Checking if the player touchs the screen & calculate swerve amount
    void CalculateSwerveAmount()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastFrameFingerPosition = Input.mousePosition.x;
            onClick = true;
        }

        else if (Input.GetMouseButton(0))
        {
            deltaMovement = Input.mousePosition.x - lastFrameFingerPosition;
            lastFrameFingerPosition = Input.mousePosition.x;
        }

        else if (Input.GetMouseButtonUp(0))
        {
            deltaMovement = 0;
            onClick = false;
        }

    }


    // Moving the cannon according the input
    void MoveCannon()
    {
        float swerveAmount = deltaMovement * Time.deltaTime * swerveSpeed;
        swerveAmount = Mathf.Clamp(swerveAmount, -maxSwerveAmount, maxSwerveAmount);

        Vector3 deltaPos = new Vector3(swerveAmount, 0, 0);  // change amount 
        Vector3 newPos = transform.position + deltaPos;     // new position of cannon

        if (newPos.x < -limits)
        {
            transform.position = new Vector3(-limits, transform.position.y, transform.position.z);
        }
        else if (newPos.x >limits)
        {
            transform.position = new Vector3(limits, transform.position.y, transform.position.z);
        }
        else
        {
            transform.Translate(deltaPos);
        }  

    }

    
    // IMPORTANT: number of Stickman in the pool is constant, not dynamic. We can't exceed it for now. We can fix it later. 
    void LaunchStickman()   
    {
        // creating stickman in front of the cannon , onclick condition for controling touches.
        if (onClick)
        {
            stickman = stickmanPool.transform.GetChild(index).gameObject;
            stickman.transform.position = new Vector3(transform.position.x, 0.6f , transform.position.z +0.5f);
            stickman.SetActive(true);
            index++;
            if (index > numberOfStickman)
            {
                index = 0;
            }

            if (!firstTouch)
            {
                firstTouch = true;
                onFirstTouch?.Invoke(firstTouch);
            }
        }    
    }
}
