using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public bool Debug;



    public List<GameObject> roadBlockPrefabs;
    public Vector2 terrainSize = new Vector2(100f, 100f);
    public Vector2 blockSize = new Vector2(10f, 10f);
    public int rows = 10;
    public int columns = 10;

    void Start()
    {
        PlaceRoadBlocksInGrid();
    }

    void PlaceRoadBlocksInGrid()
    {
        float startX = -(terrainSize.x / 2) + (blockSize.x / 2);
        float startZ = -(terrainSize.y / 2) + (blockSize.y / 2);

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                float x = startX + col * blockSize.x;
                float z = startZ + row * blockSize.y;
                Vector3 position = new Vector3(x, 0f, z);

                GameObject selectedRoadBlockPrefab = roadBlockPrefabs[Random.Range(0, roadBlockPrefabs.Count)];
                GameObject roadBlock = Instantiate(selectedRoadBlockPrefab, position, Quaternion.identity);

                // Rotate the road block if necessary
                // roadBlock.transform.Rotate(0f, Random.Range(0, 4) * 90f, 0f);
            }
        }
    }


}
