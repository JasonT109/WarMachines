using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace WarMachines
{
    public class PlayerVehicleData : MonoBehaviour
    {
        [System.Serializable]
        public class PlayerData : System.Object
        {
            public int playerID = 0;
            public string myChassis = "chassismk1";
            public string myFrontMotor = "motormk1";
            public string myRearMotor = "motormk1";
            public string myBattery = "batterymk1";
            public string myFrontWheels = "wheelmk1";
            public string myRearWheels = "wheelmk1";
            public string myArmor = "armormk1";
            public string myFrontWeapon = "";
            public string myRearWeapon = "";
            public string myTopWeapon = "";
        }

        [Tooltip("This list must be in order of player ID")]
        public PlayerData[] PlayersData;
        public List<GameObject> Players;

        /// <summary>
        /// Sets the vehicles parts as stored in the PlayersData array
        /// </summary>
        private void SetVehicleParts()
        {
            //Debug.Log("Setting vehicle parts");
            foreach (GameObject P in Players)
            {
                SimpleCarController S = P.GetComponent<SimpleCarController>();
                VehicleMods V = P.GetComponent<VehicleMods>();

                for (int i = 0; i < PlayersData.Length; i++)
                {
                    if (S.playerId == PlayersData[i].playerID)
                    {
                        V.MyChassis = PlayersData[i].myChassis;
                        V.MyFrontMotor = PlayersData[i].myFrontMotor;
                        V.MyRearMotor = PlayersData[i].myRearMotor;
                        V.MyBattery = PlayersData[i].myBattery;
                        V.MyFrontWheels = PlayersData[i].myFrontWheels;
                        V.MyRearWheels = PlayersData[i].myRearWheels;
                        V.MyArmor = PlayersData[i].myArmor;
                        V.MyFrontWeapon = PlayersData[i].myFrontWeapon;
                    }
                }
            }
        }

        /// <summary>
        /// Sets vehicle data that is stored persistently in the scene.
        /// </summary>
        /// <param name="PlayerID"></param>
        /// <param name="Slot"></param>
        /// <param name="Value"></param>
        public void SetVehicleData(int PlayerID, VehicleMods.VehicleSlots Slot, string Value)
        {
            foreach (GameObject P in Players)
            {
                SimpleCarController S = P.GetComponent<SimpleCarController>();
                VehicleMods V = P.GetComponent<VehicleMods>();

                if (S.playerId == PlayerID)
                {
                    switch (Slot)
                    {
                        case VehicleMods.VehicleSlots.ChassisSlot:
                            PlayersData[PlayerID].myChassis = Value;
                            V.MyChassis = Value;
                            break;
                        case VehicleMods.VehicleSlots.FrontMotorSlot:
                            PlayersData[PlayerID].myFrontMotor = Value;
                            V.MyFrontMotor = Value;
                            break;
                        case VehicleMods.VehicleSlots.RearMotorSlot:
                            PlayersData[PlayerID].myRearMotor = Value;
                            V.MyRearMotor = Value;
                            break;
                        case VehicleMods.VehicleSlots.FrontWheelsSlot:
                            PlayersData[PlayerID].myFrontWheels = Value;
                            V.MyFrontWheels = Value;
                            break;
                        case VehicleMods.VehicleSlots.RearWheelsSlot:
                            PlayersData[PlayerID].myRearWheels = Value;
                            V.MyRearWheels = Value;
                            break;
                        case VehicleMods.VehicleSlots.BatterySlot:
                            PlayersData[PlayerID].myBattery = Value;
                            V.MyBattery = Value;
                            break;
                        case VehicleMods.VehicleSlots.ArmorSlot:
                            PlayersData[PlayerID].myArmor = Value;
                            V.MyArmor = Value;
                            break;
                        case VehicleMods.VehicleSlots.FrontWeaponSlot:
                            PlayersData[PlayerID].myFrontWeapon = Value;
                            V.MyFrontWeapon = Value;
                            break;
                        case VehicleMods.VehicleSlots.RearWeaponSlot:
                            PlayersData[PlayerID].myRearWeapon = Value;
                            V.MyRearWeapon = Value;
                            break;
                        case VehicleMods.VehicleSlots.TopWeaponSlot:
                            PlayersData[PlayerID].myTopWeapon = Value;
                            V.MyTopWeapon = Value;
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Gets a list of players in the scene and stores them to a GameObject list.
        /// </summary>
        private void GetPlayers()
        {
            Players = new List<GameObject>(GameObject.FindGameObjectsWithTag("Player"));
        }

        void Start()
        {
            GetPlayers();
            StartCoroutine(Wait());
        }

        // called first
        void OnEnable()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            GetPlayers();
            StartCoroutine(Wait());
        }

        void OnDisable()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }

        IEnumerator Wait()
        {
            yield return new WaitForSeconds(0.1f);
            SetVehicleParts();
        }
    }
}
