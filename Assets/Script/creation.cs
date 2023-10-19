using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Unity.VisualScripting;




public class creation : MonoBehaviour
{
    // Start is called before the first frame update
    public bool Debug;


    public bool MapCree = false;
    public List<GameObject> roadBlockPrefabs;
    public Vector2 terrainSize = new Vector2(100f, 100f);
    public Vector2 blockSize = new Vector2(10f, 10f);
    public int rows = 10;
    public int columns = 10;
    public List<float> roadBlockRotation;
    public bool pause;
     private bool start = false;
    public bool AllCollisionDetected = false;
    public Transform dossierBlocParent;
    public List<GameObject> allBlock = new List<GameObject>();
    public List<GameObject> allCubeCollision;
    public List<GameObject> allEntre;




    public static creation instance;

    void Awake()
    {
        instance = this;
    }
    void Start()
    {

        StartCoroutine(PlaceRoadBlocksInGrid());
    }

    private void Update()
    {




    }


    IEnumerator wait(float temps)
    {
        // Code avant la pause

        yield return new WaitForSeconds(temps); // Pause pendant 2 secondes
        print(temps + " temps apres la coroutine");
        // Code après la pause
    }



    IEnumerator waitForCollision()
    {

        yield return new WaitForSeconds(1f);


    }



    // Est ce que si je suis dans le start je peux accédes au onCollision 
    // Start trop tot ?
    // Le faire dans l'update
    IEnumerator PlaceRoadBlocksInGrid()
    {

        start = false;
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


                        bool ConnecteurAllFalse;
                        List<bool> listBool = new List<bool>();
                        List<string> listStringAllCol = new List<string>();

                        // On instancie le nous block qui va être ajouté 
                        GameObject selectedRoadBlockPrefab = roadBlockPrefabs[Random.Range(0, roadBlockPrefabs.Count)];
                        roadBlock = Instantiate(selectedRoadBlockPrefab, position, Quaternion.identity);
                        roadBlock.transform.parent = dossierBlocParent;
                        roadBlock.transform.Rotate(0f, roadBlockRotation[Random.Range(0, roadBlockRotation.Count)], 0f);
                        roadBlock.name = roadBlock.name + "_Row:" + row + "_Col:" + col;

                        // Pause de 1 seconde
                        yield return new WaitForSeconds(0.02f);


                        // On ajoute les connecteurs dans la liste
                        int childCount = roadBlock.transform.childCount;

                        for (int i = 0; i < childCount; i++)
                        {
                            Transform child = roadBlock.transform.GetChild(i);
                            if (child.CompareTag("connected") || child.CompareTag("notConnected"))
                            {
                                ListcubeDeCollision.Add(child.gameObject);
                            }

                        }




                        // On ajoute dans la liste toute les variables pour savoir si le bloc est autorisé a être connecté
                        foreach (GameObject connectedCube in ListcubeDeCollision)
                        {
                            if (connectedCube.CompareTag("connected"))
                            {
                                // On verifie les route
                                //  print(connectedCube.GetComponent<testCollisionConnected>().notConnected + "- -" + roadBlock.name);
                                listBool.Add(connectedCube.GetComponent<testCollisionConnected>().notConnected);
                                listStringAllCol.Add(connectedCube.GetComponent<testCollisionConnected>().connectionDetected);
                            }
                            else if (connectedCube.CompareTag("notConnected"))
                            {
                                // print(connectedCube.GetComponent<testNotConnected>().notConnected + "- -" + roadBlock.name);
                                listBool.Add(connectedCube.GetComponent<testNotConnected>().notConnected);
                                listStringAllCol.Add(connectedCube.GetComponent<testNotConnected>().connectionDetected);
                            }
                        }

                        if (listBool.Any(b => b == true))
                        {

                            ConnecteurAllFalse = false;
                        }
                        else
                        {

                            ConnecteurAllFalse = true;
                        }

                        // Verifie si le bloc est bien posé 
                        if (ConnecteurAllFalse)
                        {
                            previousBlock = roadBlock;
                            blockGood = true;
                        }
                        else
                        {
                            DestroyImmediate(roadBlock);
                        }

                    }
                    else
                    {
                        print("PREMIER BLOCK");
                        // Connecter le point de sortie du bloc à un point de sortie en dehors de la zone de jeu
                        GameObject selectedRoadBlockPrefab = roadBlockPrefabs[Random.Range(0, roadBlockPrefabs.Count)];
                        roadBlock = Instantiate(selectedRoadBlockPrefab, position, Quaternion.identity);
                        roadBlock.transform.Rotate(0f, 90f, 0f);
                        roadBlock.transform.parent = dossierBlocParent;
                        roadBlock.name = roadBlock.name + "_" + row + "_" + col;
                        previousBlock = roadBlock;
                        blockGood = true;

                    }

                }
            }

        }
        GameObject[] allObjects = GameObject.FindObjectsOfType<GameObject>();

        foreach (GameObject obj in allObjects)
        {
            if (obj.name == "New Game Object" && obj.transform.childCount == 0)
            {
                Destroy(obj);
                // Ou utilisez DestroyImmediate(obj) pour une destruction immédiate
            }
        }


        int nombreEnfants = dossierBlocParent.childCount;

        for (int i = 0; i < nombreEnfants; i++)
        {
            Transform enfant = dossierBlocParent.GetChild(i);
            allBlock.Add(enfant.gameObject); // Ajoutez l'enfant à la liste.
        }

        for (int i = 0; i < allBlock.Count; i++)
        {

            int childCount = allBlock[i].transform.childCount;

            for (int y = 0; y < childCount; y++)
            {
                Transform child = allBlock[i].transform.GetChild(y);
                if (child.CompareTag("connected"))
                {
                    // On ajoute dans la liste toute les connections de route potentiel pour être une entré
                    allCubeCollision.Add(child.gameObject);
                }

            }

        }


        // On ajoute dans la liste toute les variables pour savoir si le bloc est autorisé a être connecté
        foreach (GameObject connectedCube in allCubeCollision)
        {
            if (connectedCube.CompareTag("connected"))
            {
                if (connectedCube.GetComponent<testCollisionConnected>().notConnected == false && connectedCube.GetComponent<testCollisionConnected>().connectionDetected == "pas detecté" && connectedCube.GetComponent<testCollisionConnected>().connected == false)
                {
                    allEntre.Add(connectedCube);
                }

            }
        }




        MapCree = true;
        print("La map a été crée !");
    }

}



