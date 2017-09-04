using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Minesweeper2D
{
public class Tile : MonoBehaviour {
//store x and y for as array for later use
public int x = 0;
public int y = 0;
public bool isMine = false; // is current tile mine?
public bool isRevealed = true; // has tile been revealed?
[Header("References")]
public Sprite[] emptySprites; // list of empty sprites i.e empty, 1, 2, 3, 4, etc
public Sprite[] mineSprites; // the mine sprites
private SpriteRenderer rend; // reference the renderer
	// Use this for initialization
	void Awake () {
	// grab reference to sprite renderer
		rend  = GetComponent<SpriteRenderer>();
	}
	void Start()
	{
	// randomly decide if its a mine or not
	isMine = Random.value < .05f;
	}
	public void Reveal(int adjacentMines, int mineState = 0)
	{
	//flag as removed
	isRevealed = true;
	//checks if mine
	if (isMine)
	{
	//sets sprite to mine sprite
	rend.sprite = mineSprites[mineState];
	}
	else
	{
	//sets sprite to appropriate texture based on adjacent mines
	rend.sprite = emptySprites[adjacentMines];
	}
	}
	// Update is called once per frame
	void Update () {
		
	}
}
}