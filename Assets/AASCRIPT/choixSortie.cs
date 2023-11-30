using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class choixSortie : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Transform> choix;


    public List<GameObject> VirageSortie;

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
            /*
            if (other.gameObject.GetComponent<carMover>().aUneSortie == false)
            {


                other.gameObject.GetComponent<carMover>().aUneSortie = true;
                other.gameObject.GetComponent<carMover>().waypoints.RemoveAt(other.gameObject.GetComponent<carMover>().waypoints.Count - 1);

                random = Random.Range(0, choix.Count);


                string nameSortie = choix[random].name;

                
                if (nameSortie == "sortie2")
                {
                    if (this.name == "waypont1")
                    {
                        for (int i = 0; i < VirageSortie.Count; i++)
                        {

                        }
                    }
                }
                
                other.gameObject.GetComponent<carMover>().waypoints.Add(choix[random]);

            }
            */

        }
    }
}
