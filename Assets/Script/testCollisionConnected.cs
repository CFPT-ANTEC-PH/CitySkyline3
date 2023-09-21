using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class testCollisionConnected : MonoBehaviour
{

    public bool connected = true;
    public bool notConnected;
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
          //  Debug.Log("Connected between 2 route" + "---" + gameObject.transform.parent.name);

            // Vous pouvez effectuer ici d'autres actions en réponse à la collision
        }
        else if (collision.gameObject.CompareTag("notConnected"))
        {
            notConnected = true;
            connected = false;
        }
    }
}



