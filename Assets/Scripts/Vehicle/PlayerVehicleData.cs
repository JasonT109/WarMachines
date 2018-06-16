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

        public PlayerData[] PlayersData;

        //public PlayerData Player1Data = new PlayerData();
        //public PlayerData Player2Data = new PlayerData();

        /// <summary>
        /// Sets the vehicles parts as stored in the PlayersData array
        /// </summary>
        private void SetVehicleParts()
        {
            //Debug.Log("Setting vehicle parts");
            List<GameObject> Players = new List<GameObject>(GameObject.FindGameObjectsWithTag("Player"));
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
                    }
                }
            }
        }

        void Awake()
        {
            StartCoroutine(Wait());
        }

        // called first
        void OnEnable()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
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
