using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int _width, _height;

    [SerializeField] private Tile _tilePrefab;

    [SerializeField] private Transform _cameraTransform;
    /*[SerializeField] private float cellSize;
    [SerializeField] private LayerMask unwalkableMask;
    [SerializeField] private LayerMask walkableMask;
    [SerializeField] private LayerMask enemyMask;
    [SerializeField] private LayerMask playerMask;
    [SerializeField] private LayerMask itemMask;
    [SerializeField] private LayerMask obstacleMask;
    [SerializeField] private LayerMask interactableMask;
    [SerializeField] private LayerMask portalMask;
    [SerializeField] private LayerMask bossMask;
    [SerializeField] private LayerMask bossRoomMask;
    */
    private Dictionary<Vector2, Tile> _tiles;
    private void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        _tiles = new Dictionary<Vector2, Tile>();
        for (int x = 0; x < _width; x++)
        {
            for (int y = 0; y < _height; y++)
            {
                Tile spawnedTile = Instantiate(_tilePrefab, new Vector3(x,y), Quaternion.identity);
                spawnedTile.transform.SetParent(transform);
                
                spawnedTile.name = $"Tile {x} {y}";
                
                var isOffset  = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0); 
                
                spawnedTile.Init(isOffset);
                
                _tiles[new Vector2(x,y)] = spawnedTile;
                
            }
        }
        
        _cameraTransform.position = new Vector3((float)_width / 2 - 0.5f,(float) _height / 2 - 0.5f, -10);
    }
    
    public Tile GetTileAtPosition(Vector2 position)
    {
        if (_tiles.TryGetValue(position,out var tile))
        {
            return tile;
        }

        return null;
    }

}
