using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

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

        Vector3 newPosition = car.transform.position;
        Quaternion newRotation = car.transform.rotation;

        car.name = "Voiture" + "_" + nbCar;

        Debug.Log(car.name + " : " + car.transform.position + " --- " + car.transform.localPosition);

      
        // VALEUR A MODIFIER SI LA MAP CHANGE DE TAILLE

        if (car.transform.localPosition.z < -26)
        {
            // Spawn en bas
            newPosition += new Vector3(0.35f, 0.5f, 0f);
            car.GetComponent<car>().emplacementDepart = "En bas";
        }
        else if (car.transform.localPosition.z > 1)
        {
            // Spawn en haut
            newPosition += new Vector3(-0.35f, 0.5f, 0f);
            newRotation = Quaternion.Euler(0f, 180f, 0f);

            car.GetComponent<car>().emplacementDepart = "En haut";
        }
        else
        {
            // Spawn à gauche ou à droite
            if (car.transform.localPosition.x < -10)
            {
                // Spawn à gauche
                newPosition += new Vector3(0f, 0.5f, -0.40f);
                newRotation = Quaternion.Euler(0f, 90, 0f);

                car.GetComponent<car>().emplacementDepart = "À gauche";
            }
            else
            {
                // Spawn à droite
                newPosition += new Vector3(0f, 0.5f, 0.40f);
                newRotation = Quaternion.Euler(0f, -90, 0f);

                car.GetComponent<car>().emplacementDepart = "À droite";
            }
        }

        car.transform.position = newPosition;
        car.transform.rotation = newRotation;




        canCarspawn = true;

    }

}
