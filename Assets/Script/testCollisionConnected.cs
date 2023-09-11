using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class testCollisionConnected : MonoBehaviour
{

    public bool isConnected;
    // Start is called before the first frame update
    private void Awake()
    {
        Debug.Log(" LA!");

    }

    private void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("UNE COL EST LA!");
        // Vérifier si la collision concerne un autre cube
        if (collision.gameObject.CompareTag("connected"))
        {
            isConnected = true;
            Debug.Log("Collision entre deux cubes détectée !");

            // Vous pouvez effectuer ici d'autres actions en réponse à la collision
        }
    }


}
