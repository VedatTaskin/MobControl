using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CannonControl : MonoBehaviour
{
    
    //To control the first touch of player
    public static event Action<bool> onFirstTouch;

    //Variables
    private float lastFrameFingerPosition;
    private float deltaMovement;  // movement amount in X axis
    private bool onClick = false;  // control screen touch
    private bool waitForReleaseBigMan = false;
    [HideInInspector] public bool firstTouch = false;

    [Header("Swerve Features")]
    [SerializeField] private float maxSwerveAmount = 0.3f;   // to limit the canon movement speed; 
    [SerializeField] private float limits = 3f; // right and left limits of our platform
    [SerializeField] private float swerveSpeed = 0.3f; // speed of cannon in X axis
        
    [Header("Stickman Features")]
    public GameObject stickmanPool; // object pool
    [SerializeField] private float stickmanLaunchInterval = 0.5f;
    private GameObject stickman;    
    int indexOfStickman = 0;  // index of stickman in the pool
    int amountOfStickman = 0; // number of stick man int the pool
    int stickmanCounterForBigMan = 0; // stickman counter for the big man

    [Header("Bigman Features")]
    public GameObject bigmanPool; // object pool
    [SerializeField] int bigManComingAmount = 10;   //  how many stickmans to throw and the big man will come out
    private GameObject bigman;
    int indexOfBigman = 0; // index of bigman in the pool
    int amountOfBigman = 0; // amount of bigman int the pool

    private void Start()
    {
        amountOfStickman = stickmanPool.transform.childCount;
        InvokeRepeating("LaunchStickman", 0.5f, stickmanLaunchInterval);
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
            stickman = stickmanPool.transform.GetChild(indexOfStickman).gameObject;
            stickman.transform.position = new Vector3(transform.position.x, 0.6f , transform.position.z +0.5f);
            stickman.SetActive(true);
            indexOfStickman++;
            if (indexOfStickman > amountOfStickman)
            {
                indexOfStickman = 0;
            }

            if (!firstTouch)
            {
                firstTouch = true;
                onFirstTouch?.Invoke(firstTouch);
            }

            SliderControl();
        }        
    }

    
    // Cannon slider control part. To launch Big Man some control ise doing here
    void SliderControl()
    {
        stickmanCounterForBigMan++;

        int value = stickmanCounterForBigMan % bigManComingAmount;


        if (value == 0)
        {
            waitForReleaseBigMan = true;
            StartCoroutine("LaunchBigMan");
            UIController.Instance.SetCannonSlider(1);            
        }

        if (!waitForReleaseBigMan)
        {
            float sliderValue = (float) value / bigManComingAmount;
            UIController.Instance.SetCannonSlider(sliderValue);
            //print(sliderValue);
        }

    }


    //To launch a big man, waiting until player releases finger
    IEnumerator LaunchBigMan()
    {
        yield return new WaitUntil(() => onClick == false);

        bigman = bigmanPool.transform.GetChild(indexOfBigman).gameObject;
        bigman.transform.position = new Vector3(transform.position.x, 0.6f, transform.position.z + 0.5f);
        bigman.SetActive(true);
        indexOfBigman++;
        if (indexOfBigman > amountOfBigman)
        {
            indexOfBigman = 0;
        }

        waitForReleaseBigMan = false;
        stickmanCounterForBigMan = 0;
        UIController.Instance.SetCannonSlider(0);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            UIController.Instance.LoseMenu();
        }
    }

}
