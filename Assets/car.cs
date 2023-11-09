using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car : MonoBehaviour
{
    // Start is called before the first frame update

    public List<Transform> waypoints;

    public Transform pointIntermediaire;
    public Transform pointSortie;

    public bool aUneSortie = false;
    public int currentWaypointIndex = 0;

    public bool estEntrainDeTourner = false;

    public int AngleRotaVit = 0;

    public float rota = 0;
    public float rotaDeBase;

    private void Update()
    {

       // Calculer 

        if(AngleRotaVit > 0)
        {
            if(rotaDeBase > transform.rotation.y)
            {
                rota =  rotaDeBase - transform.rotation.y;
            }
            else
            {
                rota = transform.rotation.y - rotaDeBase;
            }
           
        }
        else
        {
            rotaDeBase = transform.rotation.y;
        }

        if(rota > 0.9)
        {
            AngleRotaVit = 0;
        }

        gameObject.GetComponent<tourner>().vitesseRotation = AngleRotaVit;


    }
}
