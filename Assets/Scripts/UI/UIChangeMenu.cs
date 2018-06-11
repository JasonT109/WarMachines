using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WarMachines
{
    public class UIChangeMenu : MonoBehaviour
    {
        [SerializeField]
        public string MenuToChangeTo;
        public UIMenuFlow UIMenuFlowScript;
	    
        public void ChangeMenu()
        {
            UIMenuFlowScript.SwitchPanel(MenuToChangeTo);
        }
    }
}
