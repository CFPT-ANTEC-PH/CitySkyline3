using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public bool Debug;



    public List<GameObject> roadBlockPrefabs; // Liste de modèles de blocs
    public Vector2 terrainSize = new Vector2(100f, 100f);
    public Vector2 blockSize = new Vector2(10f, 10f);
    public int rows = 10;
    public int columns = 10;

    void Start()
    {
        PlaceRoadBlocks();
    }

    void PlaceRoadBlocks()
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

                GameObject selectedRoadBlockPrefab = roadBlockPrefabs[Random.Range(0, roadBlockPrefabs.Count)];

                GameObject roadBlock = Instantiate(selectedRoadBlockPrefab, position, Quaternion.identity);

                if (previousBlock != null)
                {
                    // Aligner le point de sortie du nouveau bloc avec le point d'entrée du bloc précédent
                    // Assurez-vous de tenir compte de la rotation des blocs si nécessaire
                    AlignRoadBlocks(previousBlock, roadBlock);
                }
                else
                {
                    // Connecter le point de sortie du bloc à un point de sortie en dehors de la zone de jeu
                    ConnectToOutside(roadBlock);
                }

                previousBlock = roadBlock;
            }
        }
    }

    void AlignRoadBlocks(GameObject previousBlock, GameObject currentBlock)
    {
        // Récupérez les points de sortie/entrée des blocs
        Transform previousExit = previousBlock.transform.Find("EntrancePoints");
        Transform currentEntrance = currentBlock.transform.Find("ExitPoint");

        if (previousExit != null && currentEntrance != null)
        {
            // Alignez le point de sortie du bloc précédent avec le point d'entrée du bloc courant
            currentBlock.transform.position = previousExit.position - currentEntrance.localPosition + currentBlock.transform.position;
        }
        else
        {
            
        }
    }

    void ConnectToOutside(GameObject roadBlock)
    {
        // Récupérez le point de sortie du bloc
        Transform exitPoint = roadBlock.transform.Find("ExitPoint");

        if (exitPoint != null)
        {
            // Placez le point de sortie à l'extérieur de la zone de jeu (par exemple, à la limite du terrain)
            float terrainHalfWidth = terrainSize.x / 2;
            float terrainHalfHeight = terrainSize.y / 2;

            Vector3 exitPosition = exitPoint.position;
            exitPosition.x = Mathf.Clamp(exitPosition.x, -terrainHalfWidth, terrainHalfWidth);
            exitPosition.z = Mathf.Clamp(exitPosition.z, -terrainHalfHeight, terrainHalfHeight);

            exitPoint.position = exitPosition;
        }
        else
        {
            
        }
        
    }


}
