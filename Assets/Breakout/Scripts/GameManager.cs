using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Breakout
{
    public class GameManager : MonoBehaviour
    {
        public int width = 20;
        public int height = 20;
        public Vector2 spacing = new Vector2(25f, 10f);
        public GameObject[] blockPrefabs;
        public Vector2 offset = new Vector2(25f, 10f);
        [Header("Debug")]
        public bool isDebugging = false;
        private GameObject[,] spawnedBlocks;
        void Start()
        {
            GenerateBlocks();
        }
        GameObject GetRandomBlock()
        {
            int randomIndex = Random.Range(0, blockPrefabs.Length);
            GameObject randomPrefab = blockPrefabs[randomIndex];
            GameObject clone = Instantiate(randomPrefab);
            return clone;
        }
        void GenerateBlocks()
        {
            spawnedBlocks = new GameObject[width, height];
            // Loop through the x
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    GameObject block = GetRandomBlock();
                    Vector3 pos = new Vector3(x * spacing.x, y * spacing.y);
                    block.transform.position = pos;
                    //Add spawned blocks to array
                    spawnedBlocks[x, y] = block;
                }
            }
        }
        void UpdateBlocks()
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    // update pos
                    GameObject currentBlock = spawnedBlocks[x, y];
                    // create new pos
                    Vector2 pos = new Vector2(x * spacing.x, y * spacing.y);
                    pos += offset;
                    //set currentBlock's position to new pos
                    currentBlock.transform.position = pos;
                }
            }
        }
        void Update()
        {
            if (isDebugging)
            {
                UpdateBlocks();
            }
        }
    }
}
