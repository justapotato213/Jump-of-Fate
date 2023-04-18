using UnityEngine;
using UnityEngine.Tilemaps;

namespace Assets.Scripts.Level
{
    /// <summary>
    /// Generates the world, converting from a texture to a world using tiles and prefabs.
    /// </summary>
    public class WorldGen : MonoBehaviour
    {
        /// <summary>
        /// Level as a Texture2D (png) 
        /// </summary>
        public Texture2D GameMap;
        /// <summary>
        /// Maps a colour to a specific tile
        /// </summary>
        public ColorToSprite[] ColorTileMapping;
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
        
        void Start()
        {
            CreateLevels();
        }

        /// <summary>
        /// Main function which loops through all pixels in GameMap
        /// </summary>
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

        /// <summary>
        /// Generates objects or tiles based on the colour of the pixel
        /// </summary>
        /// <param name="xPos">X position of the object</param>
        /// <param name="yPos">Y position of the object</param>
        private void GenerateObject(int xPos, int yPos)
        {
            // get current colour
            _colorPixel = GameMap.GetPixel(xPos, yPos);
            if (_colorPixel == new Color(255, 255, 255, 1)) return;
            // loop through each color map there is for tiles
            foreach (ColorToSprite colorMapping in ColorTileMapping)
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

                
            // loop through each color map there is for gameObjects
            foreach (ColorToObject colorMapping in ColorPrefabMapping)
            {
                // Debug.Log($"{colorMapping.ObjectColor}, {_colorPixel}, {xPos}, {yPos}");
                // check if it equals the current color
                if (colorMapping.ObjectColor.Equals(_colorPixel))
                {
                    // set position to be where we are now
                    _worldPos = new Vector3Int(xPos, yPos, 0);
                    // create prefab, y is offset by 0.5 to due to the point being in the center of the object
                    Instantiate(colorMapping.GamePrefab, new Vector3(xPos, (float)(yPos + 0.4), 0), Quaternion.identity, transform);
                    //Debug.Log($"Created prefab at {_worldPos}");

                } 
            }
        }
    }
}