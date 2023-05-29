using UnityEngine;
using Assets.Scripts.Menu;

namespace Assets.Scripts.Menus
{
    /// <summary>
    /// This class controls the upgrade menu, mostly being used to enable the menu.
    /// </summary>
    public class UpgradeController : MonoBehaviour
    {
        /// <summary>
        /// The upgrade menu object
        /// </summary>
        public GameObject upgrade;

        /// <summary>
        /// Represents the current state of the upgrade menu
        /// </summary>
        public bool isDisabled = false;

        /// <summary>
        /// Disables the upgrade menu
        /// </summary>
        public void DisableMenu()
        {
            isDisabled = true;  
            upgrade.SetActive(false);
        }

        /// <summary>
        /// Enable the menu
        /// </summary>
        public void EnableMenu()
        {
            isDisabled = false;
            upgrade.SetActive(true);
        }
    }
}
