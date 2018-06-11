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
        private int NumCategories = 5;
        private int CurrentCategory = 1;
        private string[] Categories = { "None", "Chassis", "Battery", "Motor", "Wheels", "Armor"};
        private List<PartsDictionary.PartInfo> ChassisParts;
        private int ChassisCurrentPart = 1;
        private List<PartsDictionary.PartInfo> BatteryParts;
        private int BatteryCurrentPart = 1;
        private List<PartsDictionary.PartInfo> MotorParts;
        private int MotorCurrentPart = 1;
        private List<PartsDictionary.PartInfo> WheelParts;
        private int WheelCurrentPart = 1;
        private List<PartsDictionary.PartInfo> ArmorParts;
        private int ArmorCurrentPart = 1;

        public void Awake()
        {
            player = ReInput.players.GetPlayer(playerId);
        }

        public void SwitchModule(int Direction)
        {
            CurrentCategory += Direction;
            if (CurrentCategory < 1)
                CurrentCategory = NumCategories;
            if (CurrentCategory > NumCategories)
                CurrentCategory = 1;

            UpdateUI();
        }

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
                    MotorCurrentPart += Direction;
                    if (MotorCurrentPart < 1)
                        MotorCurrentPart = MotorParts.Count;
                    if (MotorCurrentPart > MotorParts.Count)
                        MotorCurrentPart = 1;
                    break;
                case 4:
                    WheelCurrentPart += Direction;
                    if (WheelCurrentPart < 1)
                        WheelCurrentPart = WheelParts.Count;
                    if (WheelCurrentPart > WheelParts.Count)
                        WheelCurrentPart = 1;
                    break;
                case 5:
                    ArmorCurrentPart += Direction;
                    if (ArmorCurrentPart < 1)
                        ArmorCurrentPart = ArmorParts.Count;
                    if (ArmorCurrentPart > ArmorParts.Count)
                        ArmorCurrentPart = 1;
                    break;
            }
            UpdateUI();
        }

        private void UpdateUI()
        {
            CategoryText.text = Categories[CurrentCategory];
            switch (CurrentCategory)
            {
                case 1:
                    PartText.text = ChassisParts[ChassisCurrentPart - 1].partName;
                    DescriptionText.text = ChassisParts[ChassisCurrentPart - 1].description;
                    break;
                case 2:
                    PartText.text = BatteryParts[BatteryCurrentPart - 1].partName;
                    DescriptionText.text = BatteryParts[BatteryCurrentPart - 1].description;
                    break;
                case 3:
                    PartText.text = MotorParts[MotorCurrentPart - 1].partName;
                    DescriptionText.text = MotorParts[MotorCurrentPart - 1].description;
                    break;
                case 4:
                    PartText.text = WheelParts[WheelCurrentPart - 1].partName;
                    DescriptionText.text = WheelParts[WheelCurrentPart - 1].description;
                    break;
                case 5:
                    PartText.text = ArmorParts[ArmorCurrentPart - 1].partName;
                    DescriptionText.text = ArmorParts[ArmorCurrentPart - 1].description;
                    break;
            }
        }

        // Use this for initialization
        void Start()
        {
            ChassisParts = PartsDictionary.GetMyPartsOfType(PartsDictionary.PartType.Chassis, playerId);
            BatteryParts = PartsDictionary.GetMyPartsOfType(PartsDictionary.PartType.Battery, playerId);
            MotorParts = PartsDictionary.GetMyPartsOfType(PartsDictionary.PartType.Motor, playerId);
            WheelParts = PartsDictionary.GetMyPartsOfType(PartsDictionary.PartType.Wheel, playerId);
            ArmorParts = PartsDictionary.GetMyPartsOfType(PartsDictionary.PartType.Armor, playerId);
            UpdateUI();
        }

        // Update is called once per frame
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

