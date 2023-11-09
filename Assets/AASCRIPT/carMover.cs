using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class carMover : MonoBehaviour
{

    public bool start = false;

    public float maxSpeed = 5.0f; // Vitesse maximale que le véhicule peut atteindre
    public float acceleration = 1.0f; // Taux d'accélération
    public float currentSpeed = 1.0f; // Vitesse actuelle du véhicule
    private float deceleration = 1.5f; // Taux de décélération
    public float minSpeed = 5.0f;


    public List<Transform> waypoints;
    public int currentWaypointIndex = 0;
    public bool startMovement = false;
    public bool aUneSortie = false;
    void Start()
    {
        // Initialiser les waypoints (ajoutez les waypoints dans l'inspecteur Unity)

    }

    void Update()
    {
        if (start)
        {
            start = false;
            startMovement = true;
        }

        if (startMovement)
        {
            MoveTowardsWaypoint();
        }
        // Implémentez le mouvement du véhicule ici

    }

    void MoveTowardsWaypoint()
    {
        if (currentWaypointIndex < waypoints.Count)
        {
            Vector3 direction = (waypoints[currentWaypointIndex].position - transform.position).normalized;
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = rotation;

            // Si la distance au waypoint est supérieure à la distance de décélération, accélérer
            if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position) > deceleration)
            {
                if (currentSpeed < maxSpeed)
                {
                    currentSpeed += acceleration * Time.deltaTime;
                }
            }
            else // Sinon, décélérer
            {
                if (currentSpeed > 0.2f)
                {
                    currentSpeed -= deceleration * Time.deltaTime;
                }
                else
                {
                    currentSpeed = 0.2f;
                }
            }

            // Déplacez le véhicule avec la vitesse actuelle
            transform.Translate(direction * currentSpeed * Time.deltaTime, Space.World);

            if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position) < 0.1f)
            {
                currentWaypointIndex++;
               
            }
        }
        else
        {
            currentWaypointIndex = 0;
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (currentWaypointIndex > 1)
        {
            if (other.gameObject.CompareTag("sortie"))
            {
                Destroy(gameObject);
            }
        }
    }

}
