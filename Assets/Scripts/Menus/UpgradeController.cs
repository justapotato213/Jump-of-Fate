using UnityEngine;
using Assets.Scripts.Menu;

namespace Assets.Scripts.Menus
{
    public class UpgradeController : MonoBehaviour
    {
        /// <summary>
        /// The upgrade menu object
        /// </summary>
        public GameObject upgrade;
        private void Start()
        {
            // disable the menu 
            var upgradeCode = upgrade.GetComponent<UpgradeMenu>();
            if (upgrade.activeSelf)
            {
                upgradeCode.Disable();
            }
        }
    }
}
