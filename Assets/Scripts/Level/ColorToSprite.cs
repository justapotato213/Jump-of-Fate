using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Assets.Scripts.Level
{
    /// <summary>
    /// Class which maps a color, to a sprite
    /// </summary>
    [System.Serializable] public class ColorToSprite
    {
        /// <summary>
        /// RGB texture colour
        /// </summary>
        public Color color;
        /// <summary>
        /// Unity sprite
        /// </summary>
        public Sprite sprite;
    }
}

// Citations: 
// “Unity documentation,” Unity Documentation, https://docs.unity.com/ 
// B. Chhetri, “Level generator using image texture in unity - Yarsa devblog,” Yarsa Labs DevBlog, https://blog.yarsalabs.com/level-generator-using-image-texture-in-unity/