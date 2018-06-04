using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WarMachines
{
    public class CameraLookAt : MonoBehaviour
    {
        public Transform CameraTarget;
        public Transform CameraRig;
        public Transform CameraDolly;
        public float BaseFOV = 60;
        public float ArenaDiameter = 12;
        public Vector2 ZoomDistances = new Vector2(0, 20);
        public Vector2 ZoomAmounts = new Vector2(15, 30);
        public Vector2 FOVLimits = new Vector2(45, 60);
        public Vector2 FOVDistances = new Vector2(0, 30);
        public float DollyInOut = 3;
        public float ZOffset = 1;

        private List<GameObject> Players = new List<GameObject>();
        public float Distance = 0;
        public float PlayerSpreadDistance;
        private Camera ThisCamera;
        public Vector3 MaxPosition = new Vector3(-100, 0, -100);
        public Vector3 MinPosition = new Vector3(100, 0, 100);

        // Use this for initialization
        void Start()
        {
            ThisCamera = GetComponent<Camera>();
            GameObject[] AllPlayers = GameObject.FindGameObjectsWithTag("Player");
            foreach (GameObject G in AllPlayers)
            {
                Players.Add(G);
            }
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if (CameraTarget == null)
                return;

            transform.LookAt(CameraTarget);

            //calculate FOV based on distance between players and camera rig
            ThisCamera.fieldOfView = Mathf.Clamp(BaseFOV + (ZoomAmounts.x * PlayerSpreadDistance) - (ZoomAmounts.y * Distance), FOVLimits.x, FOVLimits.y);

            //calculate dolly based on max distance between players
            CameraDolly.transform.localPosition = new Vector3(0, 0, 0 - (DollyInOut * PlayerSpreadDistance) + (DollyInOut * Distance));

            if (Players.Count == 0)
                return;

            //get position of each player
            Vector3 AveragePosition = new Vector3();

            MaxPosition = new Vector3(-100, 0, -100);
            MinPosition = new Vector3(100, 0, 100);

            //get average position
            foreach (GameObject P in Players)
            {
                AveragePosition += P.transform.position;
                if (P.transform.position.x > MaxPosition.x)
                    MaxPosition = new Vector3(P.transform.position.x, 0, MaxPosition.z);
                if (P.transform.position.z > MaxPosition.z)
                    MaxPosition = new Vector3(MaxPosition.x, 0, P.transform.position.z);

                if (P.transform.position.x < MinPosition.x)
                    MinPosition = new Vector3(P.transform.position.x, 0, MinPosition.z);
                if (P.transform.position.z < MinPosition.z)
                    MinPosition = new Vector3(MinPosition.x, 0, P.transform.position.z);
            }

            PlayerSpreadDistance = Math.remapValue(Mathf.Abs(Vector3.Distance(MinPosition, MaxPosition)), 1, ArenaDiameter, 0, 1);

            AveragePosition = AveragePosition / Players.Count;

            CameraTarget.position = new Vector3(AveragePosition.x, AveragePosition.y, AveragePosition.z - (ZOffset * PlayerSpreadDistance));

            //calculate distance from camera to average point
            Distance = Math.remapValue(Vector3.Distance(AveragePosition, CameraRig.position), ZoomDistances.x, ZoomDistances.y, 0, 1); ;
        }
    }
}


