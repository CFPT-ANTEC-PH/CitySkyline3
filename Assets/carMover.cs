using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class carMover : MonoBehaviour
{

    public bool start = false;

    public float speed = 1.0f;
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
            // Obtenez la direction du waypoint actuel
            Vector3 direction = (waypoints[currentWaypointIndex].position - transform.position).normalized;
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = rotation;
            // Déplacez le véhicule vers le waypoint
            transform.Translate(direction * speed * Time.deltaTime, Space.World);

            // Si le véhicule est proche du waypoint, passez au suivant
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
