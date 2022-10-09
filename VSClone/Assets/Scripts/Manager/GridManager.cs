using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public static GridManager instance;

    [SerializeField] private int width, height;        //When upgrading the shop, make this public?
    //[SerializeField] private BaseBuildTile tilePrefab;
    [SerializeField] private Transform cam;

    //Add more paremeter of more tiles that will be walls, maybe make some of them occupied

    public Transform TileFolder;     //JustToOrganizeTiles

    //private Dictionary<Vector2, BaseBuildTile> tiles;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        cam.transform.position = new Vector3((float)width / 2 - 0.5f, (float)height / 2 - 0.5f, -10);
        GenerateGrid();
    }

    //Do i need to make another one for the shop?  Will the shop and the personal room be in the same scene?
    private void GenerateGrid()
    {
    //    tiles = new Dictionary<Vector2, BaseBuildTile>();
    //    for (int x = 0; x < width; x++)
    //    {
    //        for (int y = 0; y < height; y++)
    //        {
    //            BaseBuildTile spawnedTile = Instantiate(tilePrefab, new Vector3(x, y), Quaternion.identity);
    //            spawnedTile.x = x;
    //            spawnedTile.y = y;
    //            spawnedTile.name = $"Tile {x} {y}";
    //            spawnedTile.transform.SetParent(TileFolder, true);

    //            bool isOffset = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0);      //Every other tile will have diff color

    //            spawnedTile.Init(isOffset);
    //            tiles[new Vector2(x, y)] = spawnedTile;
    //        }
    //    }
    }

    //public BaseBuildTile GetTileAtPosition(Vector2 pos)
    //{
    //    if (tiles.TryGetValue(pos, out BaseBuildTile tile)) return tile;
    //    return null;
    //}

    public void TurnOffTiles() { TileFolder.gameObject.SetActive(false); }

    public void TurnOnTiles() { TileFolder.gameObject.SetActive(true); }
}