using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private PlayerControls controls;
    [SerializeField] private int rotationSpeed;
    [SerializeField] private float maxMoveSpeed, maxReverseSpeed, moveSpeed;
    private bool isMovingForward, isMovingBackwards, isDrifting, isTurningLeft, isTurningRight;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
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
        if (rb.velocity.x > maxMoveSpeed && isMovingForward)
        {
            rb.velocity = new Vector3(maxMoveSpeed, rb.velocity.y, rb.velocity.z);
        }

        if (rb.velocity.x < maxReverseSpeed && isMovingForward)
        {
            rb.velocity = new Vector3(-maxMoveSpeed, rb.velocity.y, rb.velocity.z);
        }

        if (rb.velocity.x < maxReverseSpeed && isMovingBackwards)
        {
            rb.velocity = new Vector3(maxReverseSpeed, rb.velocity.y, rb.velocity.z);
        }

        if (!isMovingForward)
        {
            rb.velocity -= new Vector3(15f, rb.velocity.y, 15f) * Time.deltaTime;

            if (rb.velocity.x < 0 && !isMovingBackwards)
            {
                rb.velocity = new Vector3(0, rb.velocity.y, rb.velocity.z);
            }

            if (rb.velocity.z < 0)
            {
                rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, 0);
            }
        }

        if (moveSpeed > maxMoveSpeed)
        {
            moveSpeed = maxMoveSpeed;
        }
        
        if (moveSpeed < maxReverseSpeed)
        {
            moveSpeed = maxReverseSpeed;
        }
    }

    private void FixedUpdate()
    {
        if (isMovingForward)
        {
            //transform.Translate(new Vector3(0, 0, 1) * moveSpeed * Time.deltaTime, Space.Self);
            
            if (isTurningRight)
            {
                rb.AddForce(this.transform.right * moveSpeed * Time.deltaTime);
            }
            
            if (isTurningLeft)
            {
                rb.AddForce(-this.transform.right * moveSpeed * Time.deltaTime);
            }
        }
        
        if (isMovingBackwards)
        {
            rb.AddForce(new Vector3(0, 0, -1) * moveSpeed * Time.deltaTime);
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

    private void OnEnable()
    {
        controls.Gameplay.Enable();
    }
    private void OnDisable()
    {
        controls.Gameplay.Disable();
    }

    public float GetVelocity()
    {
        return rb.velocity.x;
    }
}
