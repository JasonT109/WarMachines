using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WarMachines
{
    public class VehicleMods : MonoBehaviour
    {
        public Transform ChassisSlot;
        public Transform FrontMotorSlot;
        public Transform RearMotorSlot;
        public Transform FLWheelSlot;
        public Transform FRWheelSlot;
        public Transform BLWheelSlot;
        public Transform BRWheelSlot;
        public Transform BatterySlot;
        public Transform ArmorSlot;
        public Transform FrontWeaponSlot;
        public Transform RearWeaponSlot;
        public Transform TopWeaponSlot;
        //private readonly string path = "Assets/Resources/";

        private PartsDictionary.Chassis mChassis = new PartsDictionary.Chassis();
        public PartsDictionary.Chassis Chassis
        {
            get { return mChassis; }
            set
            {
                mChassis = value;
                ApplyMods(ChassisSlot);
            }
        }
        private PartsDictionary.Battery mBattery = new PartsDictionary.Battery();
        public PartsDictionary.Battery Battery
        {
            get { return mBattery; }
            set
            {
                mBattery = value;
                ApplyMods(BatterySlot);
            }
        }
        private PartsDictionary.Motor mFrontMotor = new PartsDictionary.Motor();
        public PartsDictionary.Motor FrontMotor
        {
            get { return mFrontMotor; }
            set
            {
                mFrontMotor = value;
                ApplyMods(FrontMotorSlot);
            }
        }
        private PartsDictionary.Motor mBackMotor = new PartsDictionary.Motor();
        public PartsDictionary.Motor BackMotor
        {
            get { return mBackMotor; }
            set
            {
                mBackMotor = value;
                ApplyMods(RearMotorSlot);
            }
        }
        private PartsDictionary.Wheel mFrontWheels = new PartsDictionary.Wheel();
        public PartsDictionary.Wheel FrontWheels
        {
            get { return mFrontWheels; }
            set
            {
                mFrontWheels = value;
                ApplyMods(FLWheelSlot);
            }
        }
        private PartsDictionary.Wheel mBackWheels = new PartsDictionary.Wheel();
        public PartsDictionary.Wheel BackWheels
        {
            get { return mBackWheels; }
            set
            {
                mBackWheels = value;
                ApplyMods(BLWheelSlot);
            }
        }
        private PartsDictionary.Armor mArmor = new PartsDictionary.Armor();
        public PartsDictionary.Armor Armor
        {
            get { return mArmor; }
            set
            {
                mArmor = value;
                ApplyMods(ArmorSlot);
            }
        }

        public void ApplyMods(Transform ModSlot)
        {
            //update the visual meshes and stats for this vehicle

            //get the data for this mod
                //visual mesh
                //slot
                //stats
        }

        // Use this for initialization
        void Start ()
        {
		
	    }
	
	    // Update is called once per frame
	    void Update ()
        {
		    
	    }
    }
}


