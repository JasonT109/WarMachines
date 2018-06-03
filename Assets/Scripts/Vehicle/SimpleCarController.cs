using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class AxleInfo
{
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public Transform visualWheelLeft;
    public Transform visualWheelRight;
    public bool motor;
    public bool steering;
    public bool steeringInverted;
    public float wheelSize = 1;
}

public class SimpleCarController : MonoBehaviour
{
    public List<AxleInfo> axleInfos;
    public float maxMotorTorque;
    public float maxSteeringAngle;
    public Slider TorqueSlider;

    // finds the corresponding visual wheel
    // correctly applies the transform
    public void ApplyLocalPositionToVisuals(WheelCollider collider, Transform wheelMesh)
    {
        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);

        wheelMesh.position = position;
        wheelMesh.rotation = rotation;
    }

    public void Start()
    {
        foreach (AxleInfo axleInfo in axleInfos)
        {
            //set wheel size
            axleInfo.leftWheel.radius = axleInfo.wheelSize * 0.1f;
            axleInfo.visualWheelLeft.transform.localScale = new Vector3(axleInfo.wheelSize, axleInfo.wheelSize, axleInfo.wheelSize);
            axleInfo.rightWheel.radius = axleInfo.wheelSize * 0.1f;
            axleInfo.visualWheelRight.transform.localScale = new Vector3(axleInfo.wheelSize, axleInfo.wheelSize, axleInfo.wheelSize);
        }

        TorqueSlider.minValue = -maxMotorTorque;
        TorqueSlider.maxValue = maxMotorTorque;
    }

    public void FixedUpdate()
    {
        float motor = maxMotorTorque * Input.GetAxisRaw("Throttle");
        float steering = maxSteeringAngle * Input.GetAxisRaw("Horizontal");

        TorqueSlider.value = motor;

        foreach (AxleInfo axleInfo in axleInfos)
        {
            if (axleInfo.steering)
            {
                float steerValue = steering;
                if (axleInfo.steeringInverted)
                    steerValue = -steering;

                axleInfo.leftWheel.steerAngle = steerValue;
                axleInfo.rightWheel.steerAngle = steerValue;
            }
            if (axleInfo.motor)
            {
                axleInfo.leftWheel.motorTorque = motor;
                axleInfo.rightWheel.motorTorque = motor;
            }
            ApplyLocalPositionToVisuals(axleInfo.leftWheel, axleInfo.visualWheelLeft);
            ApplyLocalPositionToVisuals(axleInfo.rightWheel, axleInfo.visualWheelRight);
        }
    }
}