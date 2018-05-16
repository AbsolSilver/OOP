using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Minesweeper2D
{
    public class Grid : MonoBehaviour
    {
        public GameObject tilePrefab;
        public int width = 10;
        public int height = 10;
        public float spacing = .155f;
        private RaycastHit2D hit;
        private Tile hitTile;
        private int adjacentMines;

        private Tile[,] tiles;

        Tile SpawnTile(Vector3 pos)
        {
            GameObject clone = Instantiate(tilePrefab);
            clone.transform.position = pos;
            Tile currentTile = clone.GetComponent<Tile>();
            return currentTile;
        }

        void GenerateTiles()
        {
            tiles = new Tile[width, height];

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Vector2 halfSize = new Vector2(width / 2, height / 2);

                    Vector2 pos = new Vector2(x - halfSize.x, y - halfSize.y);

                    pos *= spacing;

                    Tile tile = SpawnTile(pos);

                    tile.transform.SetParent(transform);

                    tile.x = x;
                    tile.y = y;

                    tiles[x, y] = tile;
                }
            }
        }

        // Use this for initialization
        void Start()
        {
            GenerateTiles();
        }

        public int GetAdjacentMineCountAt(Tile tile)
        {
            int count = 0;

            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    int desiredX = tile.x + x;
                    int desiredY = tile.y + y;

                    Tile currentTile = tiles[desiredX, desiredY];

                    if (currentTile.isMine)
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        public void FFuncover(int x, int y, bool[,] visited)
        {
            if (x >= 0 && y >= 0 && x < width && y < height)
            {
                if (visited[x, y])
                {
                    return;
                }
            }

            tile = tiles[x, y];
            adjacentMines = GetAdjacentMineCountAt(tile);
            Tile.Reveal(adjacentMines);

            if (adjacentMines > 0)
            {
                return;
            }

            visited[x, y] = true;

            FFuncover(x - 1, y, visited);
            FFuncover(x + 1, y, visited);
            FFuncover(x, y - 1, visited);
            FFuncover(x, y + 1, visited);
        }

        public void UncoverMines(int mineState)
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    currentTile = tiles[x, y];
                    
                    if (currentTile == isMine)
                    {
                        adjacentMines = GetAdjacentMineCountAt(currentTile);
                        currentTile.Reveal(adjacentMines, mineState);
                    } 
                }
            }
        }

        bool NoMoreEmptyTiles()
        {
            int emptyTileCount = 0;

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    currentTile = tiles[x, y];

                    if (!currentTile.isRevealed && !currentTile.isMine)
                    {
                        emptyTileCount = emptyTileCount + 1;
                    }
                }
            }

            return emptyTileCount == 0;
        }

        public void SelectTile(Tile selectedTile)
        {
            adjacentMines = GetAdjacentMineCountAt(selectedTile);
            selectedTile.Reveal(adjacentMines);
            if (selectedTile == isMine)
            {
                UncoverMines(0);
            }
            else if (adjacentMines == 0)
            {
                x = selectedTile.x;
                y = selectedTile.y;
                FFuncover(x, y, new bool[width, height]);

                if (NoMoreEmptyTiles)
                {
                    UncoverMines(1);
                }
            }
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
               Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            }



            /*
            
            hit = Physics2D.Raycast(mouseRay.origin, mouseRay.direction);
            if (hit.collider != null)
            {
                hitTile = hit.collider.GetComponent<Tile>();
                if (hitTile != null)
                {
                    adjacentMines = GetAdjacentMineCountAt(hitTile);
                    hitTile.Reveal(adjacentMines);
                }
            }
            */
        }
    }
}


