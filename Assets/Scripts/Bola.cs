using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bola : MonoBehaviour
{
    Rigidbody myRigidbody;
    Transform originalTransform;

    void Start()
    {
        originalTransform = transform;
        myRigidbody = GetComponent<Rigidbody>();
        
    }

    void Update()
    {
        
    }

    void resetBola()
    {
        myRigidbody.isKinematic = true;
        transform.position = originalTransform.position;
        transform.rotation = originalTransform.rotation;
        myRigidbody.isKinematic = false;
    }
}
