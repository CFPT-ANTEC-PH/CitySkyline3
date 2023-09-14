using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testNotConnected : MonoBehaviour
{
    public bool isConnected = false;
    // Start is called before the first frame update
    void OnCollisionEnter(Collision collision)
    {
        // Vérifier si la collision concerne un autre cube
        if (collision.gameObject.CompareTag("notConnected"))
        {
            isConnected = true;
            Debug.Log("Collision entre deux cubes détectée !");

            // Vous pouvez effectuer ici d'autres actions en réponse à la collision
        }
    }
}
