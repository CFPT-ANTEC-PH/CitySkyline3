using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newChoix : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Transform> choix;




    private int random;

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
               

                random = Random.Range(0, choix.Count);

                Transform sortie = choix[random];

            
                Vector3 direction = sortie.position - other.transform.position; // Vecteur de direction entre les deux GameObjects
                Vector3 droite = other.transform.right; // Vecteur "droite" par rapport à l'orientation de votre GameObject

                float produitScalaire = Vector3.Dot(direction, droite);

                if (produitScalaire > 0.1f)
                {
                    other.gameObject.GetComponent<car>().AngleRotaVit = 100;
                }
                else if (produitScalaire < -0.1f)
                {
                    other.gameObject.GetComponent<car>().AngleRotaVit = -100;

                }
                else
                {
                    other.gameObject.GetComponent<car>().AngleRotaVit = 0;

                }



            }

        }
    }
}
