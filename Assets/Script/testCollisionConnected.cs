using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class testCollisionConnected : MonoBehaviour
{

    public bool connected = false;
    public bool notConnected = false;
    public string connectionDetected = "pas detecté";
    // Start is called before the first frame update
    private void Awake()
    {
        //  Debug.Log(" LA!");
       
       
    }

    private void Update()
    {

    }


    void OnCollisionEnter(Collision collision)
    {

        // Vérifier si la collision concerne un autre cube
        if (collision.gameObject.CompareTag("connected"))
        {
            connected = true;
            notConnected = false;
            connectionDetected = "detecte";
            //  Debug.Log("Connected between 2 route" + "---" + gameObject.transform.parent.name);

            // Vous pouvez effectuer ici d'autres actions en réponse à la collision
        }
        else if (collision.gameObject.CompareTag("notConnected"))
        {
            notConnected = true;
            connected = false;
            connectionDetected = "detecte";

        }
    }
}



