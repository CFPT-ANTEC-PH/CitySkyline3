using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class avancer : MonoBehaviour
{

    public int vitesse = 1;
    

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward *  vitesse * Time.deltaTime;

    }
}
