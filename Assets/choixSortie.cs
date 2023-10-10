using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class choixSortie : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Transform> choix;
 
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
            if (other.gameObject.GetComponent<carMover>().aUneSortie == false)
            {

        
            other.gameObject.GetComponent<carMover>().aUneSortie = true;
            other.gameObject.GetComponent<carMover>().waypoints.RemoveAt(other.gameObject.GetComponent<carMover>().waypoints.Count - 1);
            
            other.gameObject.GetComponent<carMover>().waypoints.Add(choix[Random.Range(0, choix.Count)]);

            }

        }
    }
}
