using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tourner : MonoBehaviour
{
    // Start is called before the first frame update
    public int vitesseRotation = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(transform.position, Vector3.up, vitesseRotation * Time.deltaTime);

    }
}
