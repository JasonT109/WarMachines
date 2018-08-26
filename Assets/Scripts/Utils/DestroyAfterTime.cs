using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    public float DestroyTime = 1;
    private float Age = 0;

	void Update ()
    {
        Age += Time.deltaTime;
        if (Age >= DestroyTime)
            Destroy(gameObject);
	}
}
