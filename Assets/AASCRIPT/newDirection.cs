using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class newDirection : MonoBehaviour
{
    public Transform[] waypoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {


        
        if (other.gameObject.CompareTag("car"))
        {

            other.gameObject.GetComponent<car>().currentWaypointIndex = 0;
            other.gameObject.GetComponent<car>().aUneSortie = false;
            other.gameObject.GetComponent<car>().waypoints.Clear();
            other.gameObject.GetComponent<car>().transform.LookAt(waypoint[0]);

            other.gameObject.GetComponent<car>().waypoints.Add(gameObject.transform);

            for (int i = 0; i < waypoint.Length; i++)
            {
                if (waypoint[i])
                {
                    other.gameObject.GetComponent<car>().waypoints.Add(waypoint[i]);


                }
            }

            other.gameObject.GetComponent<car>().waypoints.Add(waypoint[waypoint.Length - 1]);





        }
        
    }
}
