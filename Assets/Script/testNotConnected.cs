using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class testNotConnected : MonoBehaviour
{
    public bool isConnected = false;
    public bool notConnected = false;
    public string connectionDetected = "pas detect�";


    private void Awake()
    {
        // Debug.Log(" LA!");

    }

    private void Update()
    {

    }

  
    
    // Start is called before the first frame update
    void OnCollisionEnter(Collision collision)
    {
       // Debug.Log("Connected between 2 object");

        // V�rifier si la collision concerne un autre cube
        if (collision.gameObject.CompareTag("notConnected"))
        {
            isConnected = true;
            notConnected = false;
            connectionDetected = "detecte";

            //  Debug.Log("Connected between 2 vide");

            // Vous pouvez effectuer ici d'autres actions en r�ponse � la collision
        }
        else if(collision.gameObject.CompareTag("connected"))
        {
            isConnected = false;
            notConnected = true;
            connectionDetected = "detecte";

        }
    }
}
