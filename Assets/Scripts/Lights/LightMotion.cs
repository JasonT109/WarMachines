using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightMotion : MonoBehaviour
{
    public float rxOffset = 90f;
    public float timeOffsetY = 0.5f;
    public float timeOffsetX = 0.5f;
    public float amount = 30f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        float rx = rxOffset + Mathf.Sin(Time.time * timeOffsetX) * amount;
        float ry = Mathf.Sin(Time.time * timeOffsetY) * amount;

        Quaternion q = Quaternion.Euler(new Vector3(rx, ry, 0));

        gameObject.transform.rotation = q;
    }
}
