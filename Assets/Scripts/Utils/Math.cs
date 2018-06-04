using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WarMachines
{
    public class Math : MonoBehaviour
    {

        public static float remapValue(float value, float inMin, float inMax, float outMin, float outMax)
        {
            //= (X-A)/(B-A) * (D-C) + C
            return ((value - inMin) / (inMax - inMin) * (outMax - outMin)) + outMin;
        }

        public static int roundToInterval(float value, int interval)
        { return Mathf.RoundToInt(value / interval) * interval; }
    }
}

