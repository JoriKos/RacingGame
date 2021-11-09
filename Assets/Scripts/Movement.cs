using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private PlayerControls controls;
    [SerializeField] private int rotationSpeed;
    [SerializeField] private int moveSpeed;
    private bool isMovingForward, isMovingBackwards, isDrifting, isTurningLeft, isTurningRight;

    private void Awake()
    {
        controls = new PlayerControls();
        controls.Gameplay.Forward.started += ctx => Forward(true);
        controls.Gameplay.Forward.canceled += ctx => Forward(false);
        controls.Gameplay.Backward.started += ctx => Backward(true);
        controls.Gameplay.Backward.canceled += ctx => Backward(false);
        
        controls.Gameplay.TurnRight.started += ctx => TurnRight(true);
        controls.Gameplay.TurnRight.canceled += ctx => TurnRight(false);
        controls.Gameplay.TurnLeft.started += ctx => TurnLeft(true);
        controls.Gameplay.TurnLeft.canceled += ctx => TurnLeft(false);

        controls.Gameplay.Drift.performed += ctx => Drift();
    }

    private void FixedUpdate()
    {
        if (isMovingForward)
        {
            transform.Translate(new Vector3(0, 0, 1) * moveSpeed * Time.deltaTime, Space.Self);
        }
        
        if (isMovingBackwards)
        {
            transform.Translate(new Vector3(0, 0, -1) * moveSpeed * Time.deltaTime, Space.Self);
        }

        if (isTurningRight)
        {
            transform.Rotate(new Vector3(0, 1, 0) * rotationSpeed * Time.deltaTime, Space.World);
        }

        if (isTurningLeft)
        {
            transform.Rotate(new Vector3(0, -1, 0) * rotationSpeed * Time.deltaTime, Space.World);
        }
    }

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
    

    private void Drift()
    {

    }

    private void OnEnable()
    {
        controls.Gameplay.Enable();
    }
    private void OnDisable()
    {
        controls.Gameplay.Disable();
    }
}
