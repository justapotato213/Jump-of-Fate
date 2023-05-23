using UnityEngine;

namespace Assets.Scripts.Level
{

    /// <summary>
    /// Class which maps a color to a prefab.
    /// </summary>
    [System.Serializable] public class ColorToObject
    {
        /// <summary>
        /// RGB code of the texture colour
        /// </summary>
        public Color ObjectColor;
        /// <summary>
        /// The prefab to summon
        /// </summary>
        public GameObject GamePrefab;
    }
}
