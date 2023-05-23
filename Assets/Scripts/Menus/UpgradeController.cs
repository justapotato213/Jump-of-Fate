using UnityEngine;
using Assets.Scripts.Menu;

namespace Assets.Scripts.Menus
{
    public class UpgradeController : MonoBehaviour
    {
        public GameObject upgrade;
        private void Start()
        {
            Debug.Log(upgrade);
            // disable the menu 
            var upgradeCode = upgrade.GetComponent<UpgradeMenu>();
            Debug.Log(upgrade);
            if (upgrade.activeSelf)
            {
                upgradeCode.Disable();
            }
        }
    }
}
