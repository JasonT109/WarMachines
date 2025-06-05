using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropFlipper : MonoBehaviour {

    public Animator FlipperAnimator;

    void ToggleFlipper()
    {
        FlipperAnimator.SetTrigger("start");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
            ToggleFlipper();
    }
}
