using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;



public class GameManager1 : MonoBehaviour
{
    // Start is called before the first frame update
    public bool Debug;



    public List<GameObject> roadBlockPrefabs;
    public Vector2 terrainSize = new Vector2(100f, 100f);
    public Vector2 blockSize = new Vector2(10f, 10f);
    public int rows = 10;
    public int columns = 10;
    public List<float> roadBlockRotation;
    public bool pause;
    void Start()
    {
        PlaceRoadBlocksInGrid();
    }

    // Est ce que si je suis dans le start je peux accédes au onCollision 
    // Start trop tot ?
    // Le faire dans l'update
    void PlaceRoadBlocksInGrid()
    {
        float startX = -(terrainSize.x / 2) + (blockSize.x / 2);
        float startZ = -(terrainSize.y / 2) + (blockSize.y / 2);

        GameObject previousBlock = null;

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                bool blockGood = false;
                while (!blockGood)
                {

                    float x = startX + col * blockSize.x;
                    float z = startZ + row * blockSize.y;
                    Vector3 position = new Vector3(x, 0f, z);

                    GameObject roadBlock = new GameObject();

                    List<GameObject> ListcubeDeCollision = new List<GameObject>();





                    if (previousBlock != null)
                    {
                        print("------------------------------------");

                        bool ConnecteurAllFalse;

                        List<bool> listBool = new List<bool>();


                        // Instancier le prefab dans la scène
                        //  GameObject instantiatedRoad = Instantiate(previousBlock);

                        // On instancie le nous block qui va être ajouté 





                        GameObject selectedRoadBlockPrefab = roadBlockPrefabs[Random.Range(0, roadBlockPrefabs.Count)];
                        roadBlock = Instantiate(selectedRoadBlockPrefab, position, Quaternion.identity);
                        roadBlock.transform.Rotate(0f, roadBlockRotation[Random.Range(0, roadBlockRotation.Count)], 0f);

                        roadBlock.name = roadBlock.name + "_" + row + "_" + col;



                        // Récupérer les enfants de l'ancien block
                        Transform BlocPrefabTransform = roadBlock.transform;
                        int childCount = BlocPrefabTransform.childCount;

                        for (int i = 0; i < childCount; i++)
                        {
                            Transform child = BlocPrefabTransform.GetChild(i);
                            if (child.CompareTag("connected") || child.CompareTag("notConnected"))
                            {
                                ListcubeDeCollision.Add(child.gameObject);
                            }

                        }




                        foreach (GameObject connectedCube in ListcubeDeCollision)
                        {
                            if (connectedCube.CompareTag("connected"))
                            {
                                // On verifie les route
                                print(connectedCube.GetComponent<testCollisionConnected>().notConnected + "- -" + roadBlock.name);
                                listBool.Add(connectedCube.GetComponent<testCollisionConnected>().notConnected);

                            }
                            else if (connectedCube.CompareTag("notConnected"))
                            {
                                print(connectedCube.GetComponent<testNotConnected>().notConnected + "- -" + roadBlock.name);
                                listBool.Add(connectedCube.GetComponent<testNotConnected>().notConnected);

                            }


                        }

                        print("List " + listBool.Count);

                        if (listBool.Any(b => b == true))
                        {
                            print("Au moins un élément est vrai" + " " + roadBlock.name);
                            ConnecteurAllFalse = false;
                        }
                        else
                        {
                            print("Aucun élément n'est vrai " + roadBlock.name);
                            ConnecteurAllFalse = true;
                        }




                        if (ConnecteurAllFalse)
                        {


                            previousBlock = roadBlock;

                            blockGood = true;

                        }
                        else
                        {
                            Destroy(roadBlock);

                        }
                        print("------------------------------------");


                    }
                    else
                    {
                        print("PREMIER BLOCK");
                        // Connecter le point de sortie du bloc à un point de sortie en dehors de la zone de jeu
                        GameObject selectedRoadBlockPrefab = roadBlockPrefabs[0];

                        roadBlock = Instantiate(selectedRoadBlockPrefab, position, Quaternion.identity);
                        roadBlock.transform.Rotate(0f, 90f, 0f);
                        roadBlock.name = roadBlock.name + "_" + row + "_" + col;
                        previousBlock = roadBlock;
                        blockGood = true;



                    }

                }



                // Rotate the road block if necessary
                // roadBlock.transform.Rotate(0f, Random.Range(0, 4) * 90f, 0f);
            }
        }
    }




}



