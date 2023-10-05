using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class direction : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform next;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("car"))
        {


            Debug.Log("TOUCHE " + other.gameObject.name);
            other.gameObject.GetComponent<carMover>().endPoint = next;
            other.gameObject.GetComponent<carMover>().startPoint = gameObject.transform;
           
            other.gameObject.GetComponent<carMover>().start = true;



        }
    }*/
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("car"))
        {
            other.gameObject.GetComponent<carMover>().distCovered = 0;
            other.gameObject.GetComponent<carMover>().fracJourney = 0;

            Debug.Log("TOUCHE " + other.gameObject.name);
            other.gameObject.GetComponent<carMover>().endPoint = next;
            other.gameObject.GetComponent<carMover>().startPoint = gameObject.transform;

    


            other.gameObject.GetComponent<carMover>().start = true;



        }
    }

}
