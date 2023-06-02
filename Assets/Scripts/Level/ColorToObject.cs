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

// Citations: 
// “Unity documentation,” Unity Documentation, https://docs.unity.com/ 
// B. Chhetri, “Level generator using image texture in unity - Yarsa devblog,” Yarsa Labs DevBlog, https://blog.yarsalabs.com/level-generator-using-image-texture-in-unity/