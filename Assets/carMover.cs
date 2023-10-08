using UnityEngine;

public class carMover : MonoBehaviour
{

    public bool start = false;

    public float speed = 1.0f;
    public Transform[] waypoints;
    private int currentWaypointIndex = 0;
    public bool startMovement = false;
    void Start()
    {
        // Initialiser les waypoints (ajoutez les waypoints dans l'inspecteur Unity)
     
    }

    void Update()
    {
        if (start)
        {
            start = false;
          
            for (int i = 0; i < waypoints.Length; i++)
            {
                waypoints[i] = transform.GetChild(i);
            }
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
        if (currentWaypointIndex < waypoints.Length)
        {
            // Obtenez la direction du waypoint actuel
            Vector3 direction = (waypoints[currentWaypointIndex].position - transform.position).normalized;

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
            Destroy(gameObject);
        }
    }

}
