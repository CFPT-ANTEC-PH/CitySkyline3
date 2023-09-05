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

        GameObject previousBlock = null;

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                float x = startX + col * blockSize.x;
                float z = startZ + row * blockSize.y;
                Vector3 position = new Vector3(x, 0f, z);

                GameObject roadBlock = new GameObject();

                List<GameObject> connectedCubes = new List<GameObject>();
                List<GameObject> notConnectedCubes = new List<GameObject>();



                if (previousBlock != null)
                {
                    // Instancier le prefab dans la scène
                    GameObject instantiatedRoad = Instantiate(previousBlock);

                    // Récupérer les enfants du prefab
                    Transform prefabTransform = instantiatedRoad.transform;
                    int childCount = prefabTransform.childCount;

                    for (int i = 0; i < childCount; i++)
                    {
                        Transform child = prefabTransform.GetChild(i);
                        if (child.CompareTag("connected"))
                        {
                            connectedCubes.Add(child.gameObject);
                        }
                        else if (child.CompareTag("notConnected"))
                        {
                            notConnectedCubes.Add(child.gameObject);
                        }
                    }

                    foreach (var item in connectedCubes)
                    {
                        print(item);
                        if(item.gameObject != null)
                        {
                            bool isConnected = item.GetComponent<testCollisionConnected>().isConnected;

                        }
                    }

                // ALALAL C DUR
                    // Vous avez maintenant vos listes de cubes connectés et non connectés prêtes à être utilisées



                    // Choisissez aléatoirement un prefab de bloc de route
                    GameObject selectedRoadBlockPrefab = roadBlockPrefabs[Random.Range(0, roadBlockPrefabs.Count)];
                    roadBlock = Instantiate(selectedRoadBlockPrefab, position, Quaternion.identity);

                }
                else
                {
                    // Connecter le point de sortie du bloc à un point de sortie en dehors de la zone de jeu
                    GameObject selectedRoadBlockPrefab = roadBlockPrefabs[0];

                    roadBlock = Instantiate(selectedRoadBlockPrefab, position, Quaternion.identity);

                }

                roadBlock.name = roadBlock.name + "_" + row + "_" + col;

                previousBlock = roadBlock;

                // Rotate the road block if necessary
                // roadBlock.transform.Rotate(0f, Random.Range(0, 4) * 90f, 0f);
            }
        }
    }


}
