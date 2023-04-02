using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMapTest : MonoBehaviour
{
    Vector3Int m_Position;
    Tilemap m_Tilemap;
    Tile m_Tile;

    // Start is called before the first frame update
    void Start()
    {
        m_Position = new Vector3Int(1, 0, -2);
        m_Tilemap = GetComponent<Tilemap>();
        m_Tile = ScriptableObject.CreateInstance<Tile>();
        m_Tile.sprite = Resources.Load<Sprite>("Sprites/Ground");

    }

    // Update is called once per frame
    void Update()
    {
        if (!m_Tilemap.HasTile(m_Position))
            m_Tilemap.SetTile(m_Position, m_Tile);
        
    }
}
