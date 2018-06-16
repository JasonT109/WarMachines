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

        private string myChassis = "chassismk1";
        private string myFrontMotor = "motormk1";
        private string myRearMotor = "motormk1";
        private string myBattery = "batterymk1";
        private string myFrontWheels = "wheelmk1";
        private string myRearWheels = "wheelmk1";
        private string myArmor = "armormk1";
        private string myFrontWeapon = "";
        private string myRearWeapon = "";
        private string myTopWeapon = "";
        private PartsDictionary PM;

        public string MyChassis
        {
            get
            {
                return myChassis;
            }

            set
            {
                myChassis = value;
                SetMesh(ChassisSlot, value, PM.GetMeshFromID(myChassis));
            }
        }

        public string MyFrontMotor
        {
            get
            {
                return myFrontMotor;
            }

            set
            {
                myFrontMotor = value;
                SetMesh(FrontMotorSlot, value, PM.GetMeshFromID(value));
            }
        }

        public string MyRearMotor
        {
            get
            {
                return myRearMotor;
            }

            set
            {
                myRearMotor = value;
                SetMesh(RearMotorSlot, value, PM.GetMeshFromID(value));
            }
        }

        public string MyBattery
        {
            get
            {
                return myBattery;
            }

            set
            {
                myBattery = value;
                SetMesh(BatterySlot, value, PM.GetMeshFromID(value));
            }
        }

        public string MyFrontWheels
        {
            get
            {
                return myFrontWheels;
            }

            set
            {
                myFrontWheels = value;
                SetMesh(FLWheelSlot, value, PM.GetMeshFromID(value));
                SetMesh(FRWheelSlot, value, PM.GetMeshFromID(value));
            }
        }

        public string MyRearWheels
        {
            get
            {
                return myRearWheels;
            }

            set
            {
                myRearWheels = value;
                SetMesh(BLWheelSlot, value, PM.GetMeshFromID(value));
                SetMesh(BRWheelSlot, value, PM.GetMeshFromID(value));
            }
        }

        public string MyArmor
        {
            get
            {
                return myArmor;
            }

            set
            {
                myArmor = value;
                SetMesh(ArmorSlot, value, PM.GetMeshFromID(value));
            }
        }

        public string MyFrontWeapon
        {
            get
            {
                return myFrontWeapon;
            }

            set
            {
                myFrontWeapon = value;
                SetMesh(FrontWeaponSlot, value, PM.GetMeshFromID(value));
            }
        }

        public string MyRearWeapon
        {
            get
            {
                return myRearWeapon;
            }

            set
            {
                myRearWeapon = value;
                SetMesh(RearWeaponSlot, value, PM.GetMeshFromID(value));
            }
        }

        public string MyTopWeapon
        {
            get
            {
                return myTopWeapon;
            }

            set
            {
                myTopWeapon = value;
                SetMesh(TopWeaponSlot, value, PM.GetMeshFromID(value));
            }
        }

        /// <summary>
        /// Instantiates the mesh (PartMesh) with the ID (PartID) under the transform (Slot).
        /// </summary>
        /// <param name="Slot"></param>
        /// <param name="PartID"></param>
        /// <param name="PartMesh"></param>
        public void SetMesh(Transform Slot, string PartID, GameObject PartMesh)
        {
            string CurrentPartID = GetMesh(Slot);

            //if that parts is not already in that slot
            if (CurrentPartID != PartID)
            {
                //if we have an old part in this slot, remove it
                if(Slot.childCount > 0)
                    Destroy(Slot.GetChild(0).gameObject);

                GameObject NewPart = Instantiate(PartMesh, Slot);
            }
        }

        /// <summary>
        /// Gets the ID of the currently parented part
        /// </summary>
        /// <param name="ModSlot"></param>
        /// <returns></returns>
        public string GetMesh(Transform ModSlot)
        {
            string ChildPartID = "none";
            
            if (ModSlot.childCount > 0)
            {
                //get the first child transform
                Transform Child = ModSlot.GetChild(0);
                //get the part ID
                ChildPartID = Child.GetComponent<PartID>().ID;
            }
            return ChildPartID;
        }

        void Awake ()
        {
            PM = GameObject.FindGameObjectWithTag("PartsLibrary").GetComponent<PartsDictionary>();
	    }
    }
}


