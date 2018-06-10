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

        public enum Armor
        {
            None,
            ArmorMk1
        }

        /** Part types. */
        public enum PartType
        {
            Chassis,
            Battery,
            Motor,
            Wheel,
            Armor,
            Weapon
        }

        /** Slot types. */
        public enum Slot
        {
            ChassisSlot,
            BatterySlot,
            MotorSlot,
            WheelSlot,
            ArmorSlot,
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
            "armormk1",
            "armormk2",
            "armormk3",
            "armormk4",
            "armormk5",
        };

        /** Details of each vehicle part. */
        private static readonly Dictionary<string, PartInfo> PartData = new Dictionary<string, PartInfo>
        {
            {"chassismk1", new PartInfo {type = PartType.Chassis, slot = Slot.ChassisSlot, partName = "Rebo Machines Chassis Mk1", description = "A simple yet robust entry level platform.", weight = 60} },
            {"chassismk2", new PartInfo {type = PartType.Chassis, slot = Slot.ChassisSlot, partName = "Rebo Machines Chassis Mk2", description = "Low ride clearance for stability, protection and style.", weight = 60} },
            {"batterymk1", new PartInfo {type = PartType.Battery, slot = Slot.BatterySlot, partName = "Inerton 4000a", description = "Enough juice to get you going.", weight = 15} },
            {"motormk1", new PartInfo {type = PartType.Motor, slot = Slot.MotorSlot, partName = "Reko P1X", description = "Now we're torquing!", weight = 8, torque = 15, wheelIndependant = false} },
            {"wheelmk1", new PartInfo {type = PartType.Wheel, slot = Slot.WheelSlot, partName = "RipperTech Screecha", description = "Squeely good wheels.", weight = 5} },
            {"armormk1", new PartInfo {type = PartType.Armor, slot = Slot.ArmorSlot, partName = "Powershell BetaBox", description = "Baby, don't hurt me! (no more)", weight = 5, strength = 5} },
            {"armormk2", new PartInfo {type = PartType.Armor, slot = Slot.ArmorSlot, partName = "Powershell HalfShell", description = "Hit me one more time!", weight = 5, strength = 5} },
            {"armormk3", new PartInfo {type = PartType.Armor, slot = Slot.ArmorSlot, partName = "Rebo Machines PlateMatix Mk3", description = "More boink for your buck!", weight = 5, strength = 5} },
            {"armormk4", new PartInfo {type = PartType.Armor, slot = Slot.ArmorSlot, partName = "Rebo Machines PlateMatix Mk4", description = "Thicker, slicker and sicker!", weight = 5, strength = 5} },
            {"armormk5", new PartInfo {type = PartType.Armor, slot = Slot.ArmorSlot, partName = "Carbyde Chrysallis 5",description = "Impenetrable. Possibly.", weight = 5, strength = 5} },
        };

        public static List<PartInfo> GetMyPartsOfType(PartType partType, int PlayerID)
        {
            //TODO check PlayerID and only return parts belonging to them
            List<PartInfo> AllMyPartsOfType = new List<PartInfo>();
            foreach (var p in PartData)
            {
                if (p.Value.type == partType)
                    AllMyPartsOfType.Add(p.Value);
            }
            return AllMyPartsOfType;
        }
    }
}

