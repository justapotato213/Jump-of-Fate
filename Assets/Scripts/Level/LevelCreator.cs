using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Assets.Scripts.Level
{
    public class LevelCreator : MonoBehaviour
    {
        public Texture2D GameMap;
        public ColorToObject[] ColorMapping;
        public Color Ground;
        private Color _colorPixel;
        private Vector3Int _worldPos;
        private Tilemap _tilemap;
        private Tile _ground;

        // Use this for initialization
        void Start()
        {
            CreateLevels();
        }

        private void CreateLevels()
        {
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
            if (_colorPixel.a == 0) return;


            // special case for ground tiles
            if (_colorPixel == Ground)
            {
                _worldPos = new Vector3Int(xPos, yPos, 0);
                _tilemap = GetComponent<Tilemap>();
                _ground = ScriptableObject.CreateInstance<Tile>();
                _ground.sprite = Resources.Load<Sprite>("Sprites/Ground");

                if (!_tilemap.HasTile(_worldPos))
                {
                    _tilemap.SetTile(_worldPos, _ground);
                    Debug.Log($"Created ground at: {_worldPos}");
                }

            }
            else
            {
                foreach (ColorToObject colorMapping in ColorMapping)
                {


                if (colorMapping.ObjectColor.Equals(_colorPixel))
                    {
                        _worldPos = new Vector3Int(xPos, yPos, -2);
                        Instantiate(colorMapping.GamePrefab, _worldPos, Quaternion.identity, transform);
                    }
                }
            }

           
        }
    }
}