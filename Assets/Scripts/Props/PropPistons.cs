using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropPistons : MonoBehaviour
{
    public Animator PistonAnimator;

    void TogglePistons()
    {
        PistonAnimator.SetTrigger("start");
    }

	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.P))
            TogglePistons();
	}
}