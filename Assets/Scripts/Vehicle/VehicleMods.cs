using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WarMachines
{
    [System.Serializable]
    public class VMods
    {
        public enum Chassis
        {
            ChassisMk1,
            ChassisMk2
        }

        public enum Battery
        {
            None,
            BatteryMk1
        }

        public enum Motor
        {
            None,
            MotorMk1
        }

        public enum Wheel
        {
            WheelMk1
        }

        public enum ArmorFront
        {
            None,
            FrontArmorMk1
        }

        public enum ArmorBack
        {
            None,
            BackArmorMk1
        }

        public enum ArmorSide
        {
            None,
            SideArmorMk1
        }

        public enum ArmorTop
        {
            None,
            TopArmorMk1
        }
    }

    public class VehicleMods : MonoBehaviour
    {
        public VMods.Chassis Chassis = new VMods.Chassis();
        public VMods.Battery Battery = new VMods.Battery();
        public VMods.Motor FrontMotor = new VMods.Motor();
        public VMods.Motor BackMotor = new VMods.Motor();
        public VMods.Wheel FrontWheels = new VMods.Wheel();
        public VMods.Wheel BackWheels = new VMods.Wheel();
        public VMods.ArmorFront ArmorFront = new VMods.ArmorFront();
        public VMods.ArmorBack ArmorBack = new VMods.ArmorBack();
        public VMods.ArmorSide ArmorSide = new VMods.ArmorSide();
        public VMods.ArmorTop ArmorTop = new VMods.ArmorTop();

        // Use this for initialization
        void Start () {
		
	    }
	
	    // Update is called once per frame
	    void Update () {
		
	    }
    }
}


