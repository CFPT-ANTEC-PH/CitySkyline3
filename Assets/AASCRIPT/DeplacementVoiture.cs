using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplacementVoiture : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform[] waypoints;

    public Transform pointIntermediaire;
    public Transform pointSortie;


    public float vitesse = 5.0f;
    public float vitesseRotation = 2.0f;

    private void Update()
    {




        // D�placer la voiture vers le point interm�diaire
        transform.position = Vector3.MoveTowards(transform.position, pointIntermediaire.position, vitesse * Time.deltaTime);

        // Tourner la voiture vers le point interm�diaire
        Vector3 direction = (pointIntermediaire.position - transform.position).normalized;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, vitesseRotation * Time.deltaTime);

        // Si la voiture est proche du point interm�diaire, passer au point de sortie
        if (Vector3.Distance(transform.position, pointIntermediaire.position) < 0.1f)
        {
            pointIntermediaire = pointSortie; // Changer le point interm�diaire vers le point de sortie
        }
    }
}
