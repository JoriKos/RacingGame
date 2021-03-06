using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private PlayerControls controls;
    [SerializeField] private int rotationSpeed;
    [SerializeField] private float maxMoveSpeed, maxReverseSpeed, speedBoostModifier;
    private float moveSpeed, boostedSpeed, timer;
    private bool isMovingForward, isMovingBackwards, isDrifting, isTurningLeft, isTurningRight, startTimer;

    private void Awake()
    {
        cam = FindObjectOfType<Camera>();
        startTimer = false;
        timer = 0;
        boostedSpeed = 0;
        //The following is (the name of a Dying Light DLC, but also) controls related stuff. controls.ActionMapName.Actions
        //Gives a bool to determine whether or not the action has been performed or has stopped performing. The "Hold" interaction doesn't really work for this kind of input for some reason.
        controls = new PlayerControls();
        controls.Gameplay.Forward.started += ctx => Forward(true);
        controls.Gameplay.Forward.canceled += ctx => Forward(false);
        controls.Gameplay.Backward.started += ctx => Backward(true);
        controls.Gameplay.Backward.canceled += ctx => Backward(false);
        
        controls.Gameplay.TurnRight.started += ctx => TurnRight(true);
        controls.Gameplay.TurnRight.canceled += ctx => TurnRight(false);
        controls.Gameplay.TurnLeft.started += ctx => TurnLeft(true);
        controls.Gameplay.TurnLeft.canceled += ctx => TurnLeft(false);

        controls.Gameplay.Drift.started += ctx => Drift(true);
        controls.Gameplay.Drift.canceled += ctx => Drift(false);
    }

    private void Update()
    {
        if (startTimer)
        {
            timer += Time.deltaTime;
        }

        if (timer > 1.5f) //If timer reaches time, remove speedboost modifiers
        {
            boostedSpeed -= speedBoostModifier;
            maxMoveSpeed -= speedBoostModifier;
            startTimer = false;
            cam.fieldOfView -= 15;
            timer = 0;
        }

        if (isMovingForward && !isMovingBackwards) //If holding forwards button, but not backwards button
        {
            moveSpeed += Time.deltaTime;

            if (moveSpeed > maxMoveSpeed)
            {
                moveSpeed = maxMoveSpeed;
            }
        }

        if (isMovingBackwards && !isMovingForward) //If holding backwards button, but not forwards button. Add speed + speed limiter.
        {
            moveSpeed -= Time.deltaTime;

            if (moveSpeed < maxReverseSpeed)
            {
                moveSpeed = maxReverseSpeed;
            }
        }

        if (moveSpeed > 0 && !isMovingForward && !isMovingBackwards) //When going forward, but neither button is pressed, remove speed over time.
        {
            moveSpeed -= Time.deltaTime;
        }

        if (moveSpeed < 0 && !isMovingForward && !isMovingBackwards) //When going backwards, but neither button is pressed, remove speed over time.
        {
            moveSpeed += Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.forward * (moveSpeed + boostedSpeed), Space.Self); //Constantly adds forward moment, values are added once buttons are pressed.

        //Turning left/right
        if (isTurningRight)
        {
            transform.Rotate(new Vector3(0, 1, 0) * rotationSpeed * Time.deltaTime, Space.World);
        }

        if (isTurningLeft)
        {
            transform.Rotate(new Vector3(0, -1, 0) * rotationSpeed * Time.deltaTime, Space.World);
        }
    }

    //Control bindings
    private void Forward(bool isActivated)
    {
        if (isActivated)
        {
            isMovingForward = true;
        }
        
        if (!isActivated)
        {
            isMovingForward = false;
        }
    }
    
    private void Backward(bool isActivated)
    {
        if (isActivated)
        {
            isMovingBackwards = true;
        }
        
        if (!isActivated)
        {
            isMovingBackwards = false;
        }
    }

    private void TurnRight(bool isActivated)
    {
        if (isActivated)
        {
            isTurningRight = true;
        }
        
        if (!isActivated)
        {
            isTurningRight = false;
        }
    }
    
    private void TurnLeft(bool isActivated)
    {
        if (isActivated)
        {
            isTurningLeft = true;
        }

        if (!isActivated)
        {
            isTurningLeft = false;
        }
    }
    

    private void Drift(bool isActivated)
    {
        if (isActivated)
        {
            isDrifting = true;
        }

        if (!isActivated)
        {
            isDrifting = false;
        }
    }

    //Function is called when object is enabled/disabled. Enables/disabled controls.
    private void OnEnable()
    {
        controls.Gameplay.Enable();
    }
    private void OnDisable()
    {
        controls.Gameplay.Disable();
    }

    //If speedboost is hit
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Speedboost")
        {
            boostedSpeed += speedBoostModifier;
            maxMoveSpeed += speedBoostModifier;
            startTimer = true;
            cam.fieldOfView += 15;
        }
    }
    public float GetVelocity()
    {
        return moveSpeed;
    }
}
