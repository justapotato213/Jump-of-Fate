using UnityEngine;

namespace Assets.Scripts.Level
{

    /// <summary>
    /// Class which maps a color to a prefab.
    /// </summary>
    [System.Serializable] public class ColorToObject
    {
        public Color ObjectColor;
        public GameObject GamePrefab;
    }
}
