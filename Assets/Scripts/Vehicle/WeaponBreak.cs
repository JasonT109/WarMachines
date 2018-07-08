using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBreak : MonoBehaviour
{
    void OnJointBreak(float breakForce)
    {
        Debug.Log("A joint has just been broken!, force: " + breakForce);

        transform.parent = null;
    }
}
