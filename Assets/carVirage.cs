using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carVirage : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform sortie;

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
            if (other.gameObject.GetComponent<car>().aUneSortie == false)
            {

                other.gameObject.GetComponent<car>().aUneSortie = true;

                other.gameObject.GetComponent<car>().peuxEtreDestroy = true;

  

                Vector3 direction = sortie.position - other.transform.position; // Vecteur de direction entre les deux GameObjects
                Vector3 droite = other.transform.right; // Vecteur "droite" par rapport à l'orientation de votre GameObject

                float produitScalaire = Vector3.Dot(direction, droite);

                if (produitScalaire > 0.1f)
                {
                    other.gameObject.GetComponent<car>().AngleRotaVit = 35;
                    other.gameObject.GetComponent<car>().direction = "droite";


                    Debug.Log("On tourne a droite");

                }
                else if (produitScalaire < -0.1f)
                {
                    other.gameObject.GetComponent<car>().AngleRotaVit = -20;
                    other.gameObject.GetComponent<car>().direction = "gauche";

                    Debug.Log("On tourne à gauche");

                }
                else
                {
                    other.gameObject.GetComponent<car>().AngleRotaVit = 0;
                    other.gameObject.GetComponent<car>().direction = "devant";

                    Debug.Log("On va tout droit");


                }



            }

        }
    }

}
