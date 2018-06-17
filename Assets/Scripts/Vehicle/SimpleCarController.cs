﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Rewired;

namespace WarMachines
{
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
        public int playerId = 0;
        public bool ControlDisabled = false;
        public List<AxleInfo> axleInfos;
        public float maxMotorTorque;
        public float maxSteeringAngle;
        public Vector3 COMOffset = new Vector3(0,-0.05f, 0);

        private Player player;
        private Rigidbody rb;

        /// <summary>
        /// Sets the position and rotation of the visual mesh to match the wheel collider
        /// </summary>
        /// <param name="collider"></param>
        /// <param name="wheelMesh"></param>
        public void ApplyLocalPositionToVisuals(WheelCollider collider, Transform wheelMesh)
        {
            Vector3 position;
            Quaternion rotation;
            collider.GetWorldPose(out position, out rotation);

            wheelMesh.position = position;
            wheelMesh.rotation = rotation;
        }

        public void Awake()
        {
            player = ReInput.players.GetPlayer(playerId);
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
            rb = GetComponent<Rigidbody>();
            rb.centerOfMass = COMOffset;
        }

        public void FixedUpdate()
        {
            if (!ControlDisabled)
            {
                float motor = maxMotorTorque * player.GetAxis("Throttle");
                float steering = maxSteeringAngle * player.GetAxis("Horizontal");

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
    }
}

