using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WarMachines
{
    public class CameraLookAt : MonoBehaviour
    {
        private List<GameObject> Players = new List<GameObject>();
        private float Distance = 0;
        private Camera ThisCamera;
        public Transform CameraTarget;
        public Transform CameraRig;
        public Transform CameraDolly;
        public Vector2 FOVLimits = new Vector2(45, 60);
        public Vector2 FOVDistances = new Vector2(0, 30);
        public Vector2 DollyInOut = new Vector2(0, 10);

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
            ThisCamera.fieldOfView = Math.remapValue(Distance, FOVDistances.x, FOVDistances.y, FOVLimits.y, FOVLimits.x);
            CameraDolly.transform.localPosition = new Vector3(0, 0, Math.remapValue(Distance, FOVDistances.x, FOVDistances.y, DollyInOut.x, DollyInOut.y));

            if (Players.Count == 0)
                return;

            //get position of each player
            Vector3 AveragePosition = new Vector3();

            //get average position
            foreach (GameObject P in Players)
                AveragePosition += P.transform.position;

            AveragePosition = AveragePosition / Players.Count;

            CameraTarget.position = AveragePosition;

            //calculate distance from camera to average point
            Distance = Mathf.Abs(Vector3.Distance(AveragePosition, CameraRig.position));
        }
    }
}


