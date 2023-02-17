using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.InputSystem;
using System.Runtime.CompilerServices;
using System.Linq;

public class CarController : MonoBehaviour
{
    private CarControls carControls;
    private Vector2 moveDirection;
    [SerializeField] private float maxSteerAngle;
    private float turnSpeed = 4f;


    [SerializeField] private float motorForce;
    [SerializeField] private float breakForce;

    [SerializeField] private WheelCollider frontLeftCollider;
    [SerializeField] private WheelCollider backLeftCollider;
    [SerializeField] private WheelCollider frontRightCollider;
    [SerializeField] private WheelCollider backRightCollider;

    [SerializeField] private Transform frontLeftTransform;
    [SerializeField] private Transform backLeftTransform;
    [SerializeField] private Transform frontRightTransform;
    [SerializeField] private Transform backRightTransform;


    private List<WheelCollider> wheelColliders;
    private List<Transform> wheelTransforms;



    private void FixedUpdate()
    {
        GetInput();
        MoveCar(moveDirection);
        HandleSteering();
        WheelVisualUpdate();
    }
    private void Start()
    {

    }

    private void Update()
    {

    }

    private void Awake()
    {
        carControls = new CarControls();
        wheelColliders = new List<WheelCollider>() { frontLeftCollider, frontRightCollider, backLeftCollider, backRightCollider };
        wheelTransforms = new List<Transform>() { frontLeftTransform, frontRightTransform, backLeftTransform, backRightTransform };
    }

    private void GetInput()
    {
        carControls.Car.Drive.performed += ctx =>
        {
            moveDirection = ctx.ReadValue<Vector2>();
        };

        carControls.Car.Drive.canceled += ctx =>
        {
            moveDirection = ctx.ReadValue<Vector2>();
        };

        carControls.Car.Brake.started += ctx =>
        {
            ApplyBraking();
        };

        carControls.Car.Brake.canceled += ctx =>
        {
            StopBraking();
        };
    }
    private void MoveCar(Vector2 moveDirection)
    {
        backLeftCollider.motorTorque = moveDirection.y * motorForce;
        backRightCollider.motorTorque = moveDirection.y * motorForce;
    }

    private void ApplyBraking()
    {
        foreach (WheelCollider collider in wheelColliders)
        {
            collider.brakeTorque = breakForce;
        }
    }

    private void StopBraking()
    {
        foreach (WheelCollider collider in wheelColliders)
        {
            collider.brakeTorque = 0f;
        }
    }

    private void HandleSteering()
    {
        frontLeftCollider.steerAngle = Mathf.Lerp(frontLeftCollider.steerAngle, moveDirection.x * maxSteerAngle, Time.deltaTime * turnSpeed);
        frontRightCollider.steerAngle = Mathf.Lerp(frontRightCollider.steerAngle, moveDirection.x * maxSteerAngle, Time.deltaTime * turnSpeed);
    }

    private void WheelVisualUpdate()
    {
        Vector3 pos;
        Quaternion rot;
        int i = 0;

        foreach(WheelCollider collider in wheelColliders)
        {
            collider.GetWorldPose(out pos, out rot);
            wheelTransforms.ElementAt(i).position = pos;
            wheelTransforms.ElementAt(i).rotation = rot;
            i++;
        }
    }

    private void OnEnable()
    {
        carControls.Enable();
    }

    private void OnDisable()
    {
        carControls.Disable();
    }
}

