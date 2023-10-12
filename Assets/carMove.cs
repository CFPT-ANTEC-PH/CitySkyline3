using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.UIElements;

public class carMove : MonoBehaviour
{

    public Transform waypointsParent; // Référence à l'objet "Waypoints" parent.
    public float vitesse = 5.0f;     // Vitesse de la voiture.

    private Transform[] waypoints;    // Tableau des waypoints.
    private int waypointIndex = 0;    // Indice du waypoint actuel.
    private Quaternion targetRotation; // Rotation cible pour la voiture.

    private float transformOriginalX;
    private bool rotate = false;


    private void Start()
    {
        // Récupérez les waypoints de l'objet parent.
        waypoints = new Transform[waypointsParent.childCount];
        for (int i = 0; i < waypoints.Length; i++)
        {
            waypoints[i] = waypointsParent.GetChild(i);
        }

        // Placez la voiture au premier waypoint.
        transform.position = waypoints[0].position;

        transformOriginalX = transform.position.x;
    }

    private void Update()
    {
        if (waypointIndex < waypoints.Length)
        {
            // Déplacez la voiture vers le waypoint actuel.
            //Vector3 direction = waypoints[waypointIndex].position - transform.position;
            //transform.Translate(direction.normalized * vitesse * Time.deltaTime);
            transform.position += Vector3.forward * vitesse * -Time.deltaTime;



            // Si la voiture est suffisamment proche du waypoint, passez au suivant.

            // Vérifiez si la position X diminue et ajustez la rotation si nécessaire.

        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        waypointIndex++;

        /*
        if (transform.position.x < transformOriginalX && rotate == false)
        {
            // Mettez la rotation Y à 90 degrés (rotation vers le haut).
            transform.Rotate(0f, 90f, 0f);
            rotate = true;
        }
        */
    }
}