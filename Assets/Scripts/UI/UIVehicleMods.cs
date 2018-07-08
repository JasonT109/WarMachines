using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Rewired;

namespace WarMachines
{
    public class UIVehicleMods : MonoBehaviour
    {
        //we need to know which player is using this UI
        public int playerId = 0;
        //UI elements
        public Text CategoryText;
        public Text PartText;
        public Text DescriptionText;

        private Player player;
        private int NumCategories = 8;
        private int CurrentCategory = 1;
        private string[] Categories = { "None", "Chassis", "Battery", "Front Motor", "Rear Motor", "Front Wheels", "Rear Wheels", "Armor", "Front Weapon" };
        private List<PartsDictionary.PartInfo> ChassisParts;
        private int ChassisCurrentPart = 1;
        private List<PartsDictionary.PartInfo> BatteryParts;
        private int BatteryCurrentPart = 1;
        private List<PartsDictionary.PartInfo> FrontMotorParts;
        private int FrontMotorCurrentPart = 1;
        private List<PartsDictionary.PartInfo> RearMotorParts;
        private int RearMotorCurrentPart = 1;
        private List<PartsDictionary.PartInfo> FrontWheelParts;
        private int FrontWheelCurrentPart = 1;
        private List<PartsDictionary.PartInfo> RearWheelParts;
        private int RearWheelCurrentPart = 1;
        private List<PartsDictionary.PartInfo> ArmorParts;
        private int ArmorCurrentPart = 1;
        private List<PartsDictionary.PartInfo> FrontWeaponParts;
        private int FrontWeaponCurrentPart = 1;
        private PlayerVehicleData PVData;

        public void Awake()
        {
            player = ReInput.players.GetPlayer(playerId);
        }

        /// <summary>
        /// Switches which category is active in UI. Direction should be -1||1
        /// </summary>
        /// <param name="Direction"></param>
        public void SwitchModule(int Direction)
        {
            CurrentCategory += Direction;
            if (CurrentCategory < 1)
                CurrentCategory = NumCategories;
            if (CurrentCategory > NumCategories)
                CurrentCategory = 1;

            UpdateUI();
        }

        /// <summary>
        /// Switches which part is active in UI. Direction should be -1||1
        /// </summary>
        /// <param name="Direction"></param>
        public void SwitchPart(int Direction)
        {
            switch (CurrentCategory)
            {
                case 1:
                    ChassisCurrentPart += Direction;
                    if (ChassisCurrentPart < 1)
                        ChassisCurrentPart = ChassisParts.Count;
                    if (ChassisCurrentPart > ChassisParts.Count)
                        ChassisCurrentPart = 1;
                    break;
                case 2:
                    BatteryCurrentPart += Direction;
                    if (BatteryCurrentPart < 1)
                        BatteryCurrentPart = BatteryParts.Count;
                    if (BatteryCurrentPart > BatteryParts.Count)
                        BatteryCurrentPart = 1;
                    break;
                case 3:
                    FrontMotorCurrentPart += Direction;
                    if (FrontMotorCurrentPart < 1)
                        FrontMotorCurrentPart = FrontMotorParts.Count;
                    if (FrontMotorCurrentPart > FrontMotorParts.Count)
                        FrontMotorCurrentPart = 1;
                    break;
                case 4:
                    RearMotorCurrentPart += Direction;
                    if (RearMotorCurrentPart < 1)
                        RearMotorCurrentPart = RearMotorParts.Count;
                    if (RearMotorCurrentPart > RearMotorParts.Count)
                        RearMotorCurrentPart = 1;
                    break;
                case 5:
                    FrontWheelCurrentPart += Direction;
                    if (FrontWheelCurrentPart < 1)
                        FrontWheelCurrentPart = FrontWheelParts.Count;
                    if (FrontWheelCurrentPart > FrontWheelParts.Count)
                        FrontWheelCurrentPart = 1;
                    break;
                case 6:
                    RearWheelCurrentPart += Direction;
                    if (RearWheelCurrentPart < 1)
                        RearWheelCurrentPart = RearWheelParts.Count;
                    if (RearWheelCurrentPart > RearWheelParts.Count)
                        RearWheelCurrentPart = 1;
                    break;
                case 7:
                    ArmorCurrentPart += Direction;
                    if (ArmorCurrentPart < 1)
                        ArmorCurrentPart = ArmorParts.Count;
                    if (ArmorCurrentPart > ArmorParts.Count)
                        ArmorCurrentPart = 1;
                    break;
                case 8:
                    FrontWeaponCurrentPart += Direction;
                    if (FrontWeaponCurrentPart < 1)
                        FrontWeaponCurrentPart = FrontWeaponParts.Count;
                    if (FrontWeaponCurrentPart > FrontWeaponParts.Count)
                        FrontWeaponCurrentPart = 1;
                    break;
            }
            UpdateUI();
        }

        /// <summary>
        /// Updates Part text and description in UI. Tells Player vehicle data to update visual mesh in scene.
        /// </summary>
        private void UpdateUI()
        {
            CategoryText.text = Categories[CurrentCategory];
            switch (CurrentCategory)
            {
                case 1:
                    PartText.text = ChassisParts[ChassisCurrentPart - 1].partName;
                    DescriptionText.text = ChassisParts[ChassisCurrentPart - 1].description;
                    PVData.SetVehicleData(playerId, VehicleMods.VehicleSlots.ChassisSlot, ChassisParts[ChassisCurrentPart - 1].id);
                    break;
                case 2:
                    PartText.text = BatteryParts[BatteryCurrentPart - 1].partName;
                    DescriptionText.text = BatteryParts[BatteryCurrentPart - 1].description;
                    PVData.SetVehicleData(playerId, VehicleMods.VehicleSlots.BatterySlot, BatteryParts[BatteryCurrentPart - 1].id);
                    break;
                case 3:
                    PartText.text = FrontMotorParts[FrontMotorCurrentPart - 1].partName;
                    DescriptionText.text = FrontMotorParts[FrontMotorCurrentPart - 1].description;
                    PVData.SetVehicleData(playerId, VehicleMods.VehicleSlots.FrontMotorSlot, FrontMotorParts[FrontMotorCurrentPart - 1].id);
                    break;
                case 4:
                    PartText.text = RearMotorParts[RearMotorCurrentPart - 1].partName;
                    DescriptionText.text = RearMotorParts[RearMotorCurrentPart - 1].description;
                    PVData.SetVehicleData(playerId, VehicleMods.VehicleSlots.RearMotorSlot, RearMotorParts[RearMotorCurrentPart - 1].id);
                    break;
                case 5:
                    PartText.text = FrontWheelParts[FrontWheelCurrentPart - 1].partName;
                    DescriptionText.text = FrontWheelParts[FrontWheelCurrentPart - 1].description;
                    PVData.SetVehicleData(playerId, VehicleMods.VehicleSlots.FrontWheelsSlot, FrontWheelParts[FrontWheelCurrentPart - 1].id);
                    break;
                case 6:
                    PartText.text = RearWheelParts[RearWheelCurrentPart - 1].partName;
                    DescriptionText.text = RearWheelParts[RearWheelCurrentPart - 1].description;
                    PVData.SetVehicleData(playerId, VehicleMods.VehicleSlots.RearWheelsSlot, RearWheelParts[RearWheelCurrentPart - 1].id);
                    break;
                case 7:
                    PartText.text = ArmorParts[ArmorCurrentPart - 1].partName;
                    DescriptionText.text = ArmorParts[ArmorCurrentPart - 1].description;
                    PVData.SetVehicleData(playerId, VehicleMods.VehicleSlots.ArmorSlot, ArmorParts[ArmorCurrentPart - 1].id);
                    break;
                case 8:
                    PartText.text = FrontWeaponParts[FrontWeaponCurrentPart - 1].partName;
                    DescriptionText.text = FrontWeaponParts[FrontWeaponCurrentPart - 1].description;
                    PVData.SetVehicleData(playerId, VehicleMods.VehicleSlots.FrontWeaponSlot, FrontWeaponParts[FrontWeaponCurrentPart - 1].id);
                    break;
            }
        }

        void Start()
        {
            PVData = GameObject.FindGameObjectWithTag("PlayerData").GetComponent<PlayerVehicleData>();
            ChassisParts = PartsDictionary.GetMyPartsOfType(PartsDictionary.PartType.Chassis, playerId);
            BatteryParts = PartsDictionary.GetMyPartsOfType(PartsDictionary.PartType.Battery, playerId);
            FrontMotorParts = PartsDictionary.GetMyPartsOfType(PartsDictionary.PartType.Motor, playerId);
            RearMotorParts = PartsDictionary.GetMyPartsOfType(PartsDictionary.PartType.Motor, playerId);
            FrontWheelParts = PartsDictionary.GetMyPartsOfType(PartsDictionary.PartType.Wheel, playerId);
            RearWheelParts = PartsDictionary.GetMyPartsOfType(PartsDictionary.PartType.Wheel, playerId);
            ArmorParts = PartsDictionary.GetMyPartsOfType(PartsDictionary.PartType.Armor, playerId);
            FrontWeaponParts = PartsDictionary.GetMyPartsOfType(PartsDictionary.PartType.Weapon, playerId);
            UpdateUI();
        }

        void Update()
        {
            //TODO only update UI belonging to this player

            if (player.GetButtonDown("LeftTrigger"))
            {
                //move to previous category
                SwitchModule(-1);
            }
            if (player.GetButtonDown("RightTrigger"))
            {
                //move to next category
                SwitchModule(1);
            }
            if (player.GetButtonDown("LeftButton"))
            {
                //move to previous part
                SwitchPart(-1);
            }
            if (player.GetButtonDown("RightButton"))
            {
                //move to next part
                SwitchPart(1);
            }
        }
    }
}

