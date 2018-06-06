using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace WarMachines
{
    public class PartsDictionary : MonoBehaviour
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

        public enum ArmorBottom
        {
            None,
            BottomArmorMk1
        }

        /** Part types. */
        public enum PartType
        {
            Chassis,
            Battery,
            Motor,
            Wheel,
            ArmorFront,
            ArmorBack,
            ArmorSides,
            ArmorTop,
            ArmorBottom,
            Weapon
        }

        /** Slot types. */
        public enum Slot
        {
            ChassisSlot,
            BatterySlot,
            MotorSlot,
            WheelSlot,
            ArmorFrontSlot,
            ArmorBackSlot,
            ArmorSidesSlot,
            ArmorTopSlot,
            ArmorBottomSlot,
            WeaponFrontSlot,
            WeaponBackSlot,
            WeaponTopSlot
        }

        /** Configuration data for a part. */
        public class PartInfo
        {
            public PartType type;
            public Slot slot;
            public float weight;
            public float passivePowerConsumption;
            public float activePowerConsumption;
            public float charge;
            public float damage;
            public float durability = 100;
            public float strength;
            public float forwardGrip;
            public float lateralGrip;
            public float torque;
            public bool wheelIndependant;
            public string partName = "Awesome Part X36a";
            public string description = "Description needed.";

            public PartInfo()
            {
            }

            public PartInfo(PartType type)
            {
                this.type = type;
            }
        }

        /** The set of all vehicle parts. */
        private static HashSet<string> mParts;
        public static HashSet<string> Parts
        { get { return mParts ?? (mParts = new HashSet<string>(PartSet.Select(x => x.ToLower()))); } }

        private static readonly HashSet<string> PartSet = new HashSet<string>
        {
            "chassismk1",
            "chassismk2",
            "batterymk1",
            "motormk1",
            "wheelmk1",
            "frontarmormk1",
            "backarmormk1",
            "sidearmormk1",
            "toparmormk1",
            "bottomarmormk1",
        };

        /** Details of each vehicle part. */
        private static readonly Dictionary<string, PartInfo> PartData = new Dictionary<string, PartInfo>
        {
            {"chassismk1", new PartInfo {type = PartType.Chassis, slot = Slot.ChassisSlot, description = "A simple yet robust entry level platform.", weight = 60} },
            {"chassismk2", new PartInfo {type = PartType.Chassis, slot = Slot.ChassisSlot, description = "Low ride clearance for stability, protection and style.", weight = 60} },
            {"batterymk1", new PartInfo {type = PartType.Battery, slot = Slot.BatterySlot, description = "Enough juice to get you going.", weight = 15} },
            {"motormk1", new PartInfo {type = PartType.Motor, slot = Slot.MotorSlot, description = "Now we're torquing!", weight = 8, torque = 15, wheelIndependant = false} },
            {"wheelmk1", new PartInfo {type = PartType.Wheel, slot = Slot.WheelSlot, description = "Squeely good wheels.", weight = 5} },
            {"frontarmormk1", new PartInfo {type = PartType.ArmorFront, slot = Slot.ArmorFrontSlot, description = "Don't hurt me!", weight = 5, strength = 5} },
            {"backarmormk1", new PartInfo {type = PartType.ArmorBack, slot = Slot.ArmorBackSlot, description = "Don't hurt me!", weight = 5, strength = 5} },
            {"sidearmormk1", new PartInfo {type = PartType.ArmorSides, slot = Slot.ArmorSidesSlot, description = "Don't hurt me!", weight = 5, strength = 5} },
            {"toparmormk1", new PartInfo {type = PartType.ArmorTop, slot = Slot.ArmorTopSlot, description = "Don't hurt me!", weight = 5, strength = 5} },
            {"bottomarmormk1", new PartInfo {type = PartType.ArmorBottom, slot = Slot.ArmorBottomSlot, description = "Don't hurt me!", weight = 5, strength = 5} },
        };
    }
}

