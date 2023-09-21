using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class testNotConnected : MonoBehaviour
{
    public bool isConnected = false;
    public bool notConnected = false;


    private void Awake()
    {
        //  Debug.Log(" LA!");

    }

    private void Update()
    {

    }

    private void OnCollisionStay(Collision collision)
    {
        // Vérifier si la collision concerne un autre cube
        // Debug.Log("Connected between 2 object");

        // Vérifier si la collision concerne un autre cube
        if (collision.gameObject.CompareTag("notConnected"))
        {
            isConnected = true;
            //  Debug.Log("Connected between 2 vide");

            // Vous pouvez effectuer ici d'autres actions en réponse à la collision
        }
        else if (collision.gameObject.CompareTag("connected"))
        {
            isConnected = false;
            notConnected = true;
        }
    }
    // Start is called before the first frame update
    void OnCollisionEnter(Collision collision)
    {
       // Debug.Log("Connected between 2 object");

        // Vérifier si la collision concerne un autre cube
        if (collision.gameObject.CompareTag("notConnected"))
        {
            isConnected = true;
          //  Debug.Log("Connected between 2 vide");

            // Vous pouvez effectuer ici d'autres actions en réponse à la collision
        }
        else if(collision.gameObject.CompareTag("connected"))
        {
            isConnected = false;
            notConnected = true;
        }
    }
}
