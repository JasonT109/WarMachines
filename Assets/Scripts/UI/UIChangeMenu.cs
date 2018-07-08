using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace WarMachines
{
    public class UIChangeMenu : MonoBehaviour
    {
        public Button FirstSelectable;
        public UIMenuFlow UIMenuFlow;
        public bool canGoBack = true;
        private UIButtonFeedback ButtonFeedback;

        public void EnableMe()
        {
            FirstSelectable.Select();
            ButtonFeedback = FirstSelectable.GetComponent<UIButtonFeedback>();
            ButtonFeedback.OnFirstSelect();
            UIMenuFlow.canGoBack = canGoBack;
        }

        void OnEnable()
        {
            FirstSelectable.Select();
            ButtonFeedback = FirstSelectable.GetComponent<UIButtonFeedback>();
            ButtonFeedback.OnFirstSelect();
            UIMenuFlow.canGoBack = canGoBack;
        }
    }
}
