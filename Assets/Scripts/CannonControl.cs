using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonControl : MonoBehaviour
{

    [SerializeField] private float maxSwerveAmount = 0.3f;   // to limit the canon movement speed; 
    [SerializeField] private float limits = 3f; // right and left limits of our platform
    [SerializeField] private float swerveSpeed = 0.3f; // speed of cannon in X axis
    private float lastFrameFingerPosition;
    private float deltaMovement;  // movement amount in X axis
    private bool onClick=false;  // control screen touch


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
            deltaMovement = lastFrameFingerPosition- Input.mousePosition.x;
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

}
