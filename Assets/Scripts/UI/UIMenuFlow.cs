using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace WarMachines
{
    public class UIMenuFlow : MonoBehaviour
    {
        //Main Panels
        public RectTransform MenuRoot;
        public GameObject MainMenuPanel;
        public GameObject VehicleModPanel;
        public GameObject ArenaSelectPanel;
        public GameObject SinglePlayerPanel;
        public GameObject TwoPlayerPanel;
        public GameObject MultiplayerPanel;
        public GameObject StartGamePanel;
        public GameObject CreateProfilePanel;
        public GameObject LoadProfilePanel;
        public GameObject WorkInProgressPanel;
        public float LeftPosition = -547f;
        public float RightPosition = 547f;

        private List<string> PreviousMenu = new List<string>();
        private string ProfileInputString = "player1profile";
        private bool RecordThisPanel = true;
        private bool RemoveLastEntry = false;
        private float XPosition = 0;

        private Dictionary<string, bool> UIVisibility = new Dictionary<string, bool>
        {
            {"none", false },
            {"mainmenu", true },
            {"vehiclemodmenu", false },
            {"arenaselectmenu", false },
            {"singleplayermenu", false },
            {"twoplayermenu", false },
            {"multiplayermenu", false },
            {"startgamemenu", false },
            {"createprofilemenu", false },
            {"loadprofilemenu", false },
            {"workinprogressmenu", false },
        };

        public void SwitchPanel(string newPanel)
        {
            bool outTest;
            //if (UIVisibility.TryGetValue(newPanel, out outTest))
            //return;

            List<string> list = new List<string>(UIVisibility.Keys);

            //set all values to false
            foreach (string p in list)
            {
                //get currently active menu and add to breadcrumb trail if it is not already there
                if (UIVisibility[p] == true && RecordThisPanel == true)
                {
                    if (PreviousMenu.Count > 0)
                    {
                        if (PreviousMenu[PreviousMenu.Count - 1] != p)
                        {
                            PreviousMenu.Add(p);
                            Debug.Log("Adding " + PreviousMenu.Count + " " + p);
                        }
                    }
                    else
                    {
                        PreviousMenu.Add(p);
                        //Debug.Log("Adding first item" + PreviousMenu.Count + " " + p);
                    }
                    Debug.Log("Breadcrumb trail: " + PreviousMenu.Count + " = " + PreviousMenu[PreviousMenu.Count - 1]);
                }
                UIVisibility[p] = false;
            }
            if (newPanel == PreviousMenu[PreviousMenu.Count - 1])
            {
                Debug.Log("We are transitioning to this panel. Removing from breadcrumb " + PreviousMenu[PreviousMenu.Count - 1]);
                PreviousMenu.RemoveAt(PreviousMenu.Count - 1);
            }
            if (RecordThisPanel == false)
            {
                RecordThisPanel = true;
                if (RemoveLastEntry)
                {
                    //RemoveLastEntry = false;
                    //Debug.Log("Removing " + PreviousMenu[PreviousMenu.Count - 1]);
                    //PreviousMenu.RemoveAt(PreviousMenu.Count - 1);
                }
            }

            //set the one we want visible to true
            UIVisibility[newPanel] = true;

            //set all gameobject active states
            foreach (string p in list)
            {
                if (UIVisibility.TryGetValue(p, out outTest))
                {
                    if (p == "mainmenu")
                        MainMenuPanel.SetActive(outTest);
                    else if (p == "vehiclemodmenu")
                        VehicleModPanel.SetActive(outTest);
                    else if (p == "arenaselectmenu")
                        ArenaSelectPanel.SetActive(outTest);
                    else if (p == "singleplayermenu")
                    {
                        SinglePlayerPanel.SetActive(outTest);
                        if(outTest)
                            DOTween.To(() => XPosition, x => XPosition = x, 0, 1);
                    }
                    else if (p == "twoplayermenu")
                        TwoPlayerPanel.SetActive(outTest);
                    else if (p == "multiplayermenu")
                        MultiplayerPanel.SetActive(outTest);
                    else if (p == "startgamemenu")
                    {
                        StartGamePanel.SetActive(outTest);
                        if (outTest)
                            DOTween.To(() => XPosition, x => XPosition = x, LeftPosition, 1);
                    }
                    else if (p == "createprofilemenu")
                        CreateProfilePanel.SetActive(outTest);
                    else if (p == "loadprofilemenu")
                        LoadProfilePanel.SetActive(outTest);
                    else if (p == "workinprogressmenu")
                        WorkInProgressPanel.SetActive(outTest);
                }
            }
        }

        public void GoBack()
        {
            //get last visited menu
            RecordThisPanel = false;
            string LastVisitedMenu = PreviousMenu[PreviousMenu.Count - 1];
            //go to last visited menu
            SwitchPanel(LastVisitedMenu);
        }

        public void UpdateProfileInput(string input)
        {
            ProfileInputString = input;
        }

        public void CreateSaveProfile()
        {
            //string LastVisitedMenu = PreviousMenu[PreviousMenu.Count - 1];
            RecordThisPanel = false;
            SwitchPanel("startgamemenu");
            //TODO add profile creation here for save files
        }

        public void LoadSaveProfile()
        {
            //string LastVisitedMenu = PreviousMenu[PreviousMenu.Count - 1];
            RecordThisPanel = false;
            SwitchPanel("startgamemenu");
            //TODO add profile loading here for save files
        }

        public void ChooseArenaMenu()
        {
            //string LastVisitedMenu = PreviousMenu[PreviousMenu.Count - 1];
            RecordThisPanel = false;
            RemoveLastEntry = true;
            SwitchPanel("startgamemenu");
            //TODO add arena selection logic here
        }

        public void StartGame()
        {
            Debug.Log("Loading level");
        }

        void Awake()
        {
            DOTween.Init();
        }

        // Use this for initialization
        void Start()
        {
            PreviousMenu.Add("mainmenu");
            SwitchPanel("mainmenu");
        }

        // Update is called once per frame
        void Update()
        {
            MenuRoot.anchoredPosition = new Vector2(XPosition, 0);
        }
    }
}

