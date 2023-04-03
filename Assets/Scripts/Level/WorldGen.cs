using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Assets.Scripts.Level
{
    public class WorldGen : MonoBehaviour
    {
        /// <summary>
        /// Level as a Texture2D (png) 
        /// </summary>
        public Texture2D GameMap;
        /// <summary>
        /// Maps a colour to a specific tile
        /// </summary>
        public ColorToTile[] ColorTileMapping;
        /// <summary>
        /// Maps a colour to a specific prefab
        /// </summary>
        public ColorToObject[] ColorPrefabMapping;
        /// <summary>
        /// Position of tile in the world
        /// </summary>
        private Vector3Int _worldPos;
        /// <summary>
        /// Tilemap being modified
        /// </summary>
        private Tilemap _tilemap;
        /// <summary>
        /// Current tile
        /// </summary>
        private Tile _tile;
        /// <summary>
        /// Colour of current pixel
        /// </summary>
        private Color _colorPixel;
        

        // Use this for initialization
        void Start()
        {
            CreateLevels();
        }

        private void CreateLevels()
        {
            // loop through all 
            for (int i = 0; i < GameMap.width; i++)
            {
                for (int j = 0; j < GameMap.height; j++)
                {
                    GenerateObject(i, j);
                }
            }
        }

        private void GenerateObject(int xPos, int yPos)
        {
            _colorPixel = GameMap.GetPixel(xPos, yPos);
            if (_colorPixel == new Color(255, 255, 255, 1)) return;
            // loop through each color map there is for tiles
            foreach (ColorToTile colorMapping in ColorTileMapping)
            {
                // check if it equals the current color
                if (colorMapping.color.Equals(_colorPixel))
                {
                    // set world position to be what we are now
                    _worldPos = new Vector3Int(xPos, yPos, 0);
                    // get tilemap
                    _tilemap = GetComponent<Tilemap>();
                    // create tile
                    _tile = ScriptableObject.CreateInstance<Tile>();
                    // change sprite to correct one
                    _tile.sprite = colorMapping.sprite;
                    
                    // check if the tilemap already has a tile
                    if (!_tilemap.HasTile(_worldPos))
                    {
                        // set it to be the new tile
                        _tilemap.SetTile(_worldPos, _tile);
                        // Debug.Log($"Created ground at: {_worldPos}");
                    }
                }
            }

                
            // loop through each color map there is for tiles
            foreach (ColorToObject colorMapping in ColorPrefabMapping)
            {
                // Debug.Log($"{colorMapping.ObjectColor}, {_colorPixel}, {xPos}, {yPos}");
                // check if it equals the current color
                if (colorMapping.ObjectColor.Equals(_colorPixel))
                {
                    // set position to be where we are now
                    _worldPos = new Vector3Int(xPos, yPos, 0);
                    // create prefab
                    Instantiate(colorMapping.GamePrefab, _worldPos, Quaternion.identity, transform);
                    Debug.Log($"Created prefab at {_worldPos}");

                }
            }
        }
    }
}