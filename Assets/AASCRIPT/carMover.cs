using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class carMover : MonoBehaviour
{

    public bool start = false;

    public float maxSpeed = 5.0f; // Vitesse maximale que le v�hicule peut atteindre
    public float acceleration = 1.0f; // Taux d'acc�l�ration
    public float currentSpeed = 1.0f; // Vitesse actuelle du v�hicule
    private float deceleration = 1.5f; // Taux de d�c�l�ration
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
        // Impl�mentez le mouvement du v�hicule ici

    }

    void MoveTowardsWaypoint()
    {
        if (currentWaypointIndex < waypoints.Count)
        {
            Vector3 direction = (waypoints[currentWaypointIndex].position - transform.position).normalized;
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = rotation;

            // Si la distance au waypoint est sup�rieure � la distance de d�c�l�ration, acc�l�rer
            if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position) > deceleration)
            {
                if (currentSpeed < maxSpeed)
                {
                    currentSpeed += acceleration * Time.deltaTime;
                }
            }
            else // Sinon, d�c�l�rer
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

            // D�placez le v�hicule avec la vitesse actuelle
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
