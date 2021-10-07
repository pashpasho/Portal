using System.Collections;

using System.Collections.Generic;

using UnityEngine;

public class CameraFollow : MonoBehaviour

{

    public Transform target; // child object of your car
    public float distance = 20.0f; // distance of camera from car
    public float rotationTo = -40; // rotation of camera
    public float height = 5.0f; // Camera height
    public float heightDamping = 2.0f; // smoothness
    public float xOffset = 0;
    public float lookAtHeight = 0.0f;
    public Rigidbody parentRigidbody; // Car
    public float rotationSnapTime = 0.3F;
    public float distanceSnapTime;

    public float distanceMultiplier;
    private Vector3 lookAtVector;
    private float usedDistance;
    float wantedRotationAngle;

    float wantedHeight;
    float currentRotationAngle;

    float currentHeight;
    Quaternion currentRotation;

    Vector3 wantedPosition;
    private float yVelocity = 0.0F;

    private float zVelocity = 0.0F;
    void Start()

    {
        lookAtVector = new Vector3(0, lookAtHeight, 0);




    }
    void LateUpdate()

    {
        wantedHeight = target.position.y + height;

        currentHeight = transform.position.y;



        wantedRotationAngle = target.eulerAngles.y + rotationTo;

        currentRotationAngle = transform.eulerAngles.y;
        currentRotationAngle = Mathf.SmoothDampAngle(currentRotationAngle, wantedRotationAngle, ref yVelocity, rotationSnapTime);
        currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);
        wantedPosition = target.position;

        wantedPosition.y = currentHeight;

        wantedPosition.x = target.position.x + xOffset;
        usedDistance = Mathf.SmoothDampAngle(usedDistance, distance + (parentRigidbody.velocity.magnitude * distanceMultiplier), ref zVelocity, distanceSnapTime);
        wantedPosition += Quaternion.Euler(0, currentRotationAngle, 0) * new Vector3(0, 0, -usedDistance);
        transform.position = wantedPosition;
        transform.LookAt(target.position + lookAtVector);
    }

}