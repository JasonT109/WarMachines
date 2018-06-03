using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookAt : MonoBehaviour
{
    private List<GameObject> Players = new List<GameObject>();
    public Transform CameraTarget;

	// Use this for initialization
	void Start()
    {
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

        if (Players.Count == 0)
            return;

        //get position of each player
        Vector3 AveragePosition = new Vector3();

        //get average position
        foreach (GameObject P in Players)
            AveragePosition += P.transform.position;

        AveragePosition = AveragePosition / Players.Count;

        CameraTarget.position = AveragePosition;
	}
}
