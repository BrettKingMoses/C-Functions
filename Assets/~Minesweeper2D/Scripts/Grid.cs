using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Minesweeper2D
{
    public class Grid : MonoBehaviour
    {
        public enum { LOSS = 0, WIN = 1 };
        public GameObject tilePrefab;
        public int width = 10;
        public int height;
        public float spacing = .155f;
        private Tile[,] tiles;
        public Vector2 offset = new Vector2(0.1f, 0.1f);
        //spawn tile function
        void Start()
        {
            GenerateTiles();
        }
        void FixedUpdate()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
                if (hit.collider != null)
                {

                }
            }
        }
        Tile SpawnTile(Vector3 pos)
        {
            //clone tile prefab
            GameObject clone = Instantiate(tilePrefab);
            clone.transform.position = pos; //position tile
            Tile currentTile = clone.GetComponent<Tile>(); // get tile component
            return currentTile;
        }
        //spawn tiles in grid like pattern
        void GenerateTiles()
        {

            //create new 2D array of size width x height
            tiles = new Tile[width, height];
            //loop through entire tile list
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    //store half size for later
                    Vector2 halfSize = new Vector2(width / 2, height / 2);
                    //pivot tiles around grid
                    Vector2 pos = new Vector2(x - halfSize.x, y - halfSize.y);
                    pos += offset;
                    //apply searching
                    pos *= spacing;
                    //spawn tile
                    Tile tile = SpawnTile(pos);
                    //attach newly spawned tile to
                    tile.transform.SetParent(transform);
                    //store its array coordinates within itself
                    tile.x = x;
                    tile.y = y;
                    //store tile in array
                    tiles[x, y] = tile;
                }
            }
        }
        //count adjacent mines
        public int GetAdjacentMineCountAt(Tile t)
        {
            int count = 0;
            //loop through all elements and have each axis go between -1 to 1
            for (int x = -1; x <= 1; x++)
            {
                for (int Y = -1; Y <= 1; Y++)
                {


                    //calculate desired coordinates from ones attained
                    int desiredX = t.x + x;
                    int desiredY = t.y + Y;
                    //IF desiredx is within range of array length
                    if (desiredX >= 0 && desiredY >= 0 && desiredX < width && desiredY < height)
                    {
                        Tile tile = tiles[desiredX, desiredY];
                        if (tile.isMine)
                        {
                            count++;
                        }
                    }
                    //IF the element at index is a mine
                    //increment cont by 1
                }
            }
            return count;
        }
        public void FFuncover(int x, int y, bool[,] visited)
        {
            if (x >= 0 && y >= 0 && y < width && x < height)
            {
                //let tile = tiles[x,y]
                //let adjacentMines = GetAdMineC(tile)
                //call tile.reveal(adjacentmines)

            //if adjacentmines > 0
            //returm

            //set visited [x,y] = true

            //call FFuncover (x - 1, y, visited)
            //call FFuncover (x +1, y, visited) 
            //call FFuncover (x, y - 1 visited)
            //call FFuncover (x, y + 1 visited)
            }
        }
        public void UncoverMines()
        {
            // for x = 0 to x < width
            // for y = 0 to y < heigh
            // let currenttile = Tiles [x,y]
            // if currenttile ismine
            // let adjacentmines = getadjacentat
            // call currenttile.reveal (adjacentMines, mineState)
        }
        public void SelectTile(Tile selectedTile)
        {
            // let adjacentmines = getadjacentminecountat(selectedtile)
            //call selectedtile.reveal
            //if selected is mine
            // call uncovermines
            //[extra] perform game over logic
            //else if adjacent mines == 0
            //let x = se;ectedtile.x
            //let y = selectedTile.y
            //call ffuncover (x,y,new bool[width,height])
            //if nomoreempty
            //call uncovermines
            //[extra]perform win logic
        }
        bool NoMoreEmptyTiles()
        {
            int emptyTileCount = 0;
            // for x = 0 to x < width
            // for y = 0 to y < height
            //let currenttiles = tiles[x,y]
            //if !currenttile.isrevealed and !currenttile.ismine
            //set emptytilecount = emptytilecount + 1
            return emptyTileCount == 0;
        }
    }
}