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

    public string direction;
    
    
    
    public float rota = 0;
    public float rotaDeBase;


    public float valeurPlus90 = 90;
    public float valeurMoin90 = -90;


    private void Update()
    {

       // Calculer 

        if(AngleRotaVit  == 0)
        {
            // On avance tout droit
           
           
        }
        else if(AngleRotaVit > 5)
        {
            // on va a droite 
        }
        else
        {
            // on va a gauche
        }



        gameObject.GetComponent<tourner>().vitesseRotation = AngleRotaVit;


    }
}
