using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.UIElements;

public class car : MonoBehaviour
{
    // Start is called before the first frame update

    public List<Transform> waypoints;

    public Transform pointIntermediaire;
    public Transform pointSortie;

    public bool aUneSortie = false;
    public int currentWaypointIndex = 0;

    public bool estEntrainDeTourner = false;
    public bool peuxEtreDestroy = false;

    public int AngleRotaVit = 0;

    public string direction;

    public float rotaY;

    public float rota = 0;
    public float rotaDeBase;


    public float valeurPlus90 = 90;
    public float valeurMoin90 = -90;

    public string emplacementDepart;



    void Update()
    {

        // Calculer 
        if (AngleRotaVit != 0)
        {
            if (direction == "droite")
            {
                Debug.Log(" A DROIITTTEEE");

               // Debug.Log(" Y " + transform.rotation.y * 100 + " ---- rota de base : " + rotaDeBase);


                if (transform.rotation.y * 100 >= rotaDeBase + 69 && transform.rotation.y * 100 <= rotaDeBase + 72)
                {
                    Debug.Log(" STOP");
                    Quaternion rotation = transform.rotation;

                    Quaternion newRotation = Quaternion.Euler(rotation.eulerAngles.x, 90, rotation.eulerAngles.z);

                    transform.rotation = newRotation;


                  //  gameObject.GetComponent<avancer>().vitesse = 0;

                    AngleRotaVit = 0;
                }
            }
            else if (direction == "gauche")
            {
                Debug.Log(" A GAUCHHEEEE");
                if (transform.rotation.y * 100 <= rotaDeBase - 69 && transform.rotation.y * 100 >= rotaDeBase - 72)
                {
                  //  Debug.Log(" STOP");

                    Quaternion rotation = transform.rotation;

                    Quaternion newRotation = Quaternion.Euler(rotation.eulerAngles.x, -90, rotation.eulerAngles.z);

                    transform.rotation = newRotation;


                   // gameObject.GetComponent<avancer>().vitesse = 0;

                    // transform.rotation = new Vector3(transform.rotation.x, rotaDeBase - 90, transform.rotation.z);

                    AngleRotaVit = 0;
                }
            }
        }
        else
        {

           // Debug.Log(" Y " + transform.rotation.y * 100 + " ---- rota de base : " + rotaDeBase);

            rotaDeBase = transform.rotation.y * 100;
        }


        rotaY = transform.rotation.y ;



        gameObject.GetComponent<tourner>().vitesseRotation = AngleRotaVit;


    }


    private void OnTriggerEnter(Collider other)
    {
        if (peuxEtreDestroy)
        {
            if (other.gameObject.CompareTag("sortie"))
            {
                Destroy(gameObject);
            }
        }
    }
}



