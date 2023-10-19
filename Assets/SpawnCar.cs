using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnCar : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private creation scriptCreation;

    public List<GameObject> entranceCar;
    public List<GameObject> carPrefab;
    public Transform DossierParentCar;
    private int nbCar;
    private int nbEntre;
    private bool canCarspawn;
    public float timeSpawnInterval;

    void Start()
    {
        nbCar = 0;
        canCarspawn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (scriptCreation.MapCree)
        {
            if (canCarspawn)
            {
                nbEntre = scriptCreation.allEntre.Count;
                StartCoroutine(spawnCar());
            }
        }
    }


    IEnumerator spawnCar()
    {
        canCarspawn = false;
     
        yield return new WaitForSeconds(timeSpawnInterval);
        GameObject car;
        GameObject entre = scriptCreation.allEntre[Random.Range(0, scriptCreation.allEntre.Count)];
        nbCar++;
        Vector3 position = entre.transform.position;
        car = Instantiate(carPrefab[0], position, Quaternion.identity);
        car.transform.parent = DossierParentCar;
        car.transform.position += new Vector3(0f,0.6f,0f);

        car.name = car.name + "_" + nbCar;
        canCarspawn = true;

    }

}
