using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;
// TODO: Document
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