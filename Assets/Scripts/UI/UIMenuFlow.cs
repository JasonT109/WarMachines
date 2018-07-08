using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using Rewired;

namespace WarMachines
{
    public class UIMenuFlow : MonoBehaviour
    {
        public bool QuickStart = false;
        public int playerId = 0;
        public bool canGoBack = true;
        //Main Panels
        public RectTransform MenuRoot;
        public GameObject MainMenuPanel;
        public GameObject VehicleModPanel;
        public GameObject ArenaSelectPanel;
        public GameObject StartMenuPanel;
        public GameObject TwoPlayerPanel;
        public GameObject MultiplayerPanel;
        public GameObject StartGamePanel;
        public GameObject CreateProfilePanel;
        public GameObject LoadProfilePanel;
        public GameObject WorkInProgressPanel;
        public float LeftPosition = -547f;
        public float RightPosition = 547f;
        public UILevelFader LevelFader;

        private List<string> PreviousMenu = new List<string>();
        private string ProfileInputString = "player1profile";
        private bool RecordThisPanel = true;
        private float XPosition = 0;
        private Player player;
        private int LevelToLoad = 1;

        private Dictionary<string, bool> UIVisibility = new Dictionary<string, bool>
        {
            {"none", false },
            {"mainmenu", true },
            {"vehiclemodmenu", false },
            {"arenaselectmenu", false },
            {"startmenu", false },
            {"twoplayermenu", false },
            {"multiplayermenu", false },
            {"startgamemenu", false },
            {"createprofilemenu", false },
            {"loadprofilemenu", false },
            {"workinprogressmenu", false },
        };

        /// <summary>
        /// Changes UI panel visibility to the required panel (newPanel).
        /// </summary>
        /// <param name="newPanel"></param>
        public void SwitchPanel(string newPanel)
        {
            bool outTest;
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
                            PreviousMenu.Add(p);
                    }
                    else
                        PreviousMenu.Add(p);
                }
                UIVisibility[p] = false;
            }
            if (newPanel == PreviousMenu[PreviousMenu.Count - 1])
                PreviousMenu.RemoveAt(PreviousMenu.Count - 1);

            if (RecordThisPanel == false)
                RecordThisPanel = true;

            //set the one we want visible to true
            UIVisibility[newPanel] = true;

            //set all gameobject active states
            foreach (string p in list)
            {
                if (UIVisibility.TryGetValue(p, out outTest))
                {
                    if (p == "mainmenu")
                    {
                        MainMenuPanel.SetActive(outTest);
                        if (outTest)
                            DOTween.To(() => XPosition, x => XPosition = x, 0, 1);
                    }
                    else if (p == "vehiclemodmenu")
                        VehicleModPanel.SetActive(outTest);
                    else if (p == "arenaselectmenu")
                        ArenaSelectPanel.SetActive(outTest);
                    else if (p == "startmenu")
                        StartMenuPanel.SetActive(outTest);
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

        /// <summary>
        /// Allows the user to go back to previous panel
        /// </summary>
        public void GoBack()
        {
            RecordThisPanel = false;
            string LastVisitedMenu = PreviousMenu[PreviousMenu.Count - 1];
            SwitchPanel(LastVisitedMenu);
        }

        public void UpdateProfileInput(string input)
        {
            ProfileInputString = input;
        }

        public void CreateSaveProfile()
        {
            SwitchPanel("mainmenu");
            //TODO add profile creation here for save files
        }

        public void LoadSaveProfile()
        {
            SwitchPanel("mainmenu");
            //TODO add profile loading here for save files
        }

        public void ChooseArenaMenu()
        {
            RecordThisPanel = false;
            SwitchPanel("startgamemenu");
            //TODO add arena selection logic here
        }

        public void StartGame()
        {
            Debug.Log("Loading level");
            LevelFader.FadeToLevel(LevelToLoad);
        }

        void Awake()
        {
            DOTween.Init();
            player = ReInput.players.GetPlayer(playerId);

            if (QuickStart)
                StartGame();
        }

        void Start()
        {
            PreviousMenu.Add("startmenu");
            SwitchPanel("startmenu");
        }

        void Update()
        {
            MenuRoot.anchoredPosition = new Vector2(XPosition, 0);
            if (player.GetButtonDown("BButton") && canGoBack)
                GoBack();
        }
    }
}

