﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEditor;

namespace WarMachines
{
    [System.Serializable]
    public class PartMeshes : System.Object
    {
        [SerializeField]
        public string PartName;
        [SerializeField]
        public GameObject PartMesh;
    }

    public class PartsDictionary : MonoBehaviour
    {
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
            public string id;
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

        [SerializeField]
        public List<PartMeshes> PartMeshes = new List<PartMeshes>();

        public GameObject GetMeshFromID(string ID)
        {
            foreach (PartMeshes P in PartMeshes)
            {
                if (P.PartName == ID)
                {
                    return P.PartMesh;
                }
            }
            return null;
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
            "weaponbullmk1",
            "weaponscorpionmk1"
        };

        /** Details of each vehicle part. */
        private static readonly Dictionary<string, PartInfo> PartData = new Dictionary<string, PartInfo>
        {
            {"chassismk1", new PartInfo {id = "chassismk1", type = PartType.Chassis, slot = Slot.ChassisSlot, partName = "Rebo Machines Chassis Mk1", description = "A simple yet robust entry level platform.", weight = 60} },
            {"chassismk2", new PartInfo {id = "chassismk2", type = PartType.Chassis, slot = Slot.ChassisSlot, partName = "Rebo Machines Chassis Mk2", description = "Low ride clearance for stability, protection and style.", weight = 60} },
            {"batterymk1", new PartInfo {id = "batterymk1", type = PartType.Battery, slot = Slot.BatterySlot, partName = "Inerton 4000a", description = "Enough juice to get you going.", weight = 15} },
            {"motormk1", new PartInfo {id = "motormk1", type = PartType.Motor, slot = Slot.MotorSlot, partName = "Reko P1X", description = "Now we're torquing!", weight = 8, torque = 15, wheelIndependant = false} },
            {"wheelmk1", new PartInfo {id = "wheelmk1", type = PartType.Wheel, slot = Slot.WheelSlot, partName = "RipperTech Screecha", description = "Squeely good wheels.", weight = 5} },
            {"armormk1", new PartInfo {id = "armormk1", type = PartType.Armor, slot = Slot.ArmorSlot, partName = "Powershell BetaBox", description = "Baby, don't hurt me! (no more)", weight = 5, strength = 5} },
            {"armormk2", new PartInfo {id = "armormk2", type = PartType.Armor, slot = Slot.ArmorSlot, partName = "Powershell HalfShell", description = "Hit me one more time!", weight = 5, strength = 5} },
            {"armormk3", new PartInfo {id = "armormk3", type = PartType.Armor, slot = Slot.ArmorSlot, partName = "Rebo Machines PlateMatix Mk3", description = "More boink for your buck!", weight = 5, strength = 5} },
            {"armormk4", new PartInfo {id = "armormk4", type = PartType.Armor, slot = Slot.ArmorSlot, partName = "Rebo Machines PlateMatix Mk4", description = "Thicker, slicker and sicker!", weight = 5, strength = 5} },
            {"armormk5", new PartInfo {id = "armormk5", type = PartType.Armor, slot = Slot.ArmorSlot, partName = "Carbyde Chrysallis 5",description = "Impenetrable. Possibly.", weight = 5, strength = 5} },
            {"weaponbullmk1", new PartInfo {id = "weaponbullmk1", type = PartType.Weapon, slot = Slot.WeaponFrontSlot, partName = "JBS Bulldozer",description = "Outta the way!", weight = 5, strength = 5} },
            {"weaponscorpionmk1", new PartInfo {id = "weaponscorpionmk1", type = PartType.Weapon, slot = Slot.WeaponFrontSlot, partName = "Scorpion",description = "Careful, I sting!", weight = 5, strength = 5} },
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

