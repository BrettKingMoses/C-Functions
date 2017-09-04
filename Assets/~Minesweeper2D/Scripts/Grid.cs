using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Minesweeper2D
{
public class Grid : MonoBehaviour {
public GameObject tilePrefab;
public int width = 10;
public int height
public float spacing = .155f;
private Tile [,] tiles;
//spawn tile function
Tile SpawnTile(Vector3 pos)
{
//clone tile prefab
GameObject clone = Instantiate(tilePrefab);
clone.transform.position = pos; //position tile
Tile currentTile = clone.GetComponent<Tile>(); // get tile component
return currentTile
}
//spawn tiles in grid like pattern
void GenerateTiles()
{
//create new 2D array of size width x height
tiles = new Tile [width, height];
//loop through entire tile list
for (int x = 0; x < width; x++)
{
for (int y = 0; y < height; y++)
{
//store half size for later
Vector2 halfSize = new Vector (width / 2, height / 2);
//pivot tiles around grid
Vector2 pos = new Vector2(x - halfSize.x, y - halfSize.y);

//apply searching
pos *= spacing;ttttttttttttttttttttttttttttttttttttttt
//spawn tttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttt
}
}
}
 }
}