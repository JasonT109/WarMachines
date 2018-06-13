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
        private UIButtonFeedback uibf;

        void OnEnable()
        {
            FirstSelectable.Select();
            uibf = FirstSelectable.GetComponent<UIButtonFeedback>();
            uibf.OnFirstSelect();
            UIMenuFlow.canGoBack = canGoBack;
        }
    }
}
